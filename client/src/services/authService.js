// In src/services/authService.js
import axios from 'axios';

// Make sure this URL points to your backend's address
const API_URL = 'https://localhost:7114/api/auth';

const login = async (username, password) => {
  const response = await axios.post(`${API_URL}/login`, {
    username,
    password,
  });

  // Axios puts the response data inside a 'data' property
  return response.data;
};

const register = async (username, password) => {
  // No necesitamos un token para registrar, por eso usamos axios directamente
  const response = await axios.post(`${API_URL}/register`, {
    username,
    password,
  });
  return response.data;
};

export default {
  login,
  register, // <-- Exportar la nueva función
};
// We can add the register function here later if needed