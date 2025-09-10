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

// We can add the register function here later if needed

export default {
  login,
};