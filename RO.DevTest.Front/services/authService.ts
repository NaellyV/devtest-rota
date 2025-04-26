import { fetchApi } from '../lib/api';

interface RegisterData {
  userName: string;
  name: string;
  email: string;
  password: string;
  passwordConfirmation: string;
  role: string;
}

export const registerUser = async (data: RegisterData) => {
  try {
    const response = await fetchApi('user', { 
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        userName: data.userName,
        name: data.name,
        email: data.email,
        password: data.password,
        role: parseInt(data.role) 
      })
    });

    if (!response.ok) {
      const errorData = await response.json();
      throw new Error(errorData.message || 'Erro no registro');
    }

    return await response.json();
  } catch (error) {
    console.error('Erro detalhado:', error);
    throw new Error(
      error instanceof Error 
        ? error.message 
        : 'Não foi possível conectar ao servidor. Verifique sua conexão.'
    );
  }
};