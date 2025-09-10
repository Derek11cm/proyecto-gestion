
/* eslint-disable react-refresh/only-export-components */
import { createContext, useState, useContext, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import authService from '../services/authService';

// 1. Crear el Contexto
const AuthContext = createContext(null);

// 2. Crear el Proveedor (Provider)
export const AuthProvider = ({ children }) => {
  const [token, setToken] = useState(localStorage.getItem('authToken'));
  const navigate = useNavigate();

  // Efecto para sincronizar el token con el Local Storage
  useEffect(() => {
    if (token) {
      localStorage.setItem('authToken', token);
    } else {
      localStorage.removeItem('authToken');
    }
  }, [token]);

  // Función de Login
  const login = async (username, password) => {
    const response = await authService.login(username, password);
    setToken(response.token);
    navigate('/'); // Redirige al dashboard después del login
  };

  // Función de Logout
  const logout = () => {
    setToken(null);
    navigate('/login');
  };

  // El valor que se comparte con toda la app
  const value = {
    token,
    login,
    logout,
  };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};

// 3. Crear un Hook personalizado para usar el contexto fácilmente
export const useAuth = () => {
  return useContext(AuthContext);
};