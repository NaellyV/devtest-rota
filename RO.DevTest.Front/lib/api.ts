const API_BASE_URL = 'http://localhost:5087'; 

export const fetchApi = async (endpoint: string, options?: RequestInit) => {
  const response = await fetch(`${API_BASE_URL}/api/${endpoint}`, {
    headers: {
      'Content-Type': 'application/json',
      ...options?.headers,
    },
    ...options,
  });

  if (!response.ok) {
    throw new Error('Erro na requisição');
  }

  return response;
};