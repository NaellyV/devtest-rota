import React, { useState } from 'react';
import { registerUser } from '../services/authService';
import { useRouter } from 'next/router';

export default function RegisterForm() {
  const router = useRouter();
  const [formData, setFormData] = useState({
    userName: '',
    name: '',
    email: '',
    password: '',
    passwordConfirmation: '',
    role: ''
  });
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState('');

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: value
    }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setIsLoading(true);
    setError('');

    try {
      const result = await registerUser(formData);
      console.log('Sucesso:', result);
      router.push('/login?registered=true');
    } catch (error) {
      let errorMessage = 'Erro durante o registro';
      if (error instanceof Error) {
        errorMessage = error.message.split('(Status:')[0].trim();
      }
      setError(errorMessage);
      console.error('Erro completo:', error);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-background px-4">
      <div className="w-full max-w-md bg-white rounded-2xl shadow-md p-8">
        <div className="text-center mb-6">
          <h1 className="text-3xl font-bold text-primary">Crie sua conta</h1>
          <p className="text-muted-foreground mt-2">Preencha os campos para se registrar</p>
        </div>

        {error && (
          <div className="mb-4 p-3 bg-red-100 text-red-700 rounded-lg text-sm">
            {error}
          </div>
        )}

        <form className="space-y-5" onSubmit={handleSubmit}>
          {/* Nome de usuário */}
          <div className="flex flex-col gap-1">
            <label htmlFor="username" className="text-sm font-medium text-foreground">
              Nome de Usuário *
            </label>
            <input
              id="username"
              name="userName"
              type="text"
              placeholder="mariasilva"
              className="input"
              required
              value={formData.userName}
              onChange={handleChange}
            />
          </div>

          {/* Nome completo */}
          <div className="flex flex-col gap-1">
            <label htmlFor="name" className="text-sm font-medium text-foreground">
              Nome Completo *
            </label>
            <input
              id="name"
              name="name"
              type="text"
              placeholder="Maria Silva"
              className="input"
              required
              value={formData.name}
              onChange={handleChange}
            />
          </div>

          {/* Email */}
          <div className="flex flex-col gap-1">
            <label htmlFor="email" className="text-sm font-medium text-foreground">
              Email *
            </label>
            <input
              id="email"
              name="email"
              type="email"
              placeholder="seu@email.com"
              className="input"
              required
              value={formData.email}
              onChange={handleChange}
            />
          </div>

          {/* Senha */}
          <div className="flex flex-col gap-1">
            <label htmlFor="password" className="text-sm font-medium text-foreground">
              Senha *
            </label>
            <input
              id="password"
              name="password"
              type="password"
              placeholder="••••••••"
              className="input"
              required
              value={formData.password}
              onChange={handleChange}
            />
            <p className="text-xs text-muted-foreground mt-1">
              Mínimo 8 caracteres com letras e números
            </p>
          </div>

          {/* Confirmar senha */}
          <div className="flex flex-col gap-1">
            <label htmlFor="passwordConfirmation" className="text-sm font-medium text-foreground">
              Confirme sua Senha *
            </label>
            <input
              id="passwordConfirmation"
              name="passwordConfirmation"
              type="password"
              placeholder="••••••••"
              className="input"
              required
              value={formData.passwordConfirmation}
              onChange={handleChange}
            />
          </div>

          {/* Tipo de conta */}
          <div className="flex flex-col gap-1">
            <label htmlFor="role" className="text-sm font-medium text-foreground">
              Tipo de Conta *
            </label>
            <select
              id="role"
              name="role"
              className="input"
              required
              value={formData.role}
              onChange={handleChange}
            >
              <option value="">Selecione um tipo</option>
              <option value="0">Administrador</option>
              <option value="1">Cliente</option>
            </select>
          </div>

          {/* Botão */}
          <button
            type="submit"
            className="btn-primary mt-2"
            disabled={isLoading}
          >
            {isLoading ? 'Registrando...' : 'Registrar'}
          </button>
        </form>

        <div className="mt-6 text-center">
          <p className="text-sm text-muted-foreground">
            Já tem uma conta?{' '}
            <a href="/login" className="text-primary hover:underline font-medium">
              Faça login
            </a>
          </p>
        </div>
      </div>
    </div>
  );
}
