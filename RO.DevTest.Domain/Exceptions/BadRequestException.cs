using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace RO.DevTest.Domain.Exceptions
{
    /// <summary>
    /// Represents an exception for bad requests with standardized and semantic error messages.
    /// Returns a <see cref="HttpStatusCode.BadRequest"/> to the client.
    /// </summary>
    public class BadRequestException : ApiException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public BadRequestException(IdentityResult result)
            : base(FormatIdentityErrors(result.Errors)) { }

        public BadRequestException(string error)
            : base(error) { }

        public BadRequestException(ValidationResult validationResult)
            : base(FormatValidationErrors(validationResult.Errors)) { }

        private static string FormatIdentityErrors(IEnumerable<IdentityError> errors)
        {
            var formatted = errors.Select(e => $"{e.Code}: {e.Description}");
            return "Erro de identidade: " + string.Join("; ", formatted);
        }

        private static string FormatValidationErrors(IEnumerable<ValidationFailure> failures)
        {
            var formatted = failures.Select(f => $"{f.PropertyName}: {f.ErrorMessage}");
            return "Erro de validação: " + string.Join("; ", formatted);
        }

        
    }
}
