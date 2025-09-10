import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:7114/api', // La URL base de tu API
});

// Esto es un "interceptor": se ejecuta ANTES de cada petición.
api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('authToken');
    if (token) {
      // Si el token existe, lo añade a los encabezados de la petición
      config.headers['Authorization'] = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

export default api;