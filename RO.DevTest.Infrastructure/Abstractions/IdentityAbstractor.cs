﻿using Microsoft.AspNetCore.Identity;
using RO.DevTest.Application.Contracts.Infrastructure;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Domain.Enums;
using RO.DevTest.Domain.Exceptions;
using System.Net;

namespace RO.DevTest.Infrastructure.Abstractions;

public class IdentityAbstractor : IIdentityAbstractor 
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public IdentityAbstractor(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task<User?> FindUserByEmailAsync(string email) 
        => await _userManager.FindByEmailAsync(email);

    public async Task<User?> FindUserByIdAsync(string userId) 
        => await _userManager.FindByIdAsync(userId);

    public async Task<IList<string>> GetUserRolesAsync(User user) 
        => await _userManager.GetRolesAsync(user);

    public async Task<IdentityResult> CreateUserAsync(User user, string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException($"{nameof(password)} cannot be null or empty", nameof(password));

        if (string.IsNullOrEmpty(user.Email))
            throw new ArgumentException($"{nameof(User.Email)} cannot be null or empty", nameof(user));

        return await _userManager.CreateAsync(user, password);
    }

    public async Task<SignInResult> PasswordSignInAsync(User user, string password)
        => await _signInManager.PasswordSignInAsync(user, password, false, false);

    public async Task<IdentityResult> DeleteUserAsync(User user) 
        => await _userManager.DeleteAsync(user);

    public async Task<IdentityResult> AddToRoleAsync(User user, UserRoles role)
    {
        if (await _roleManager.RoleExistsAsync(role.ToString()) is false)
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
        }

        return await _userManager.AddToRoleAsync(user, role.ToString());
    }

    public async Task<IdentityResult> UpdateUserAsync(User user, CancellationToken cancellationToken)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        // Verifica se o usuário existe antes de atualizar
        var existingUser = await _userManager.FindByIdAsync(user.Id);
        if (existingUser == null)
            throw new NotFoundException($"User with ID {user.Id} not found");

        // Atualiza as propriedades do usuário
        existingUser.UserName = user.UserName;
        existingUser.Email = user.Email;

        return await _userManager.UpdateAsync(existingUser);
    }
}