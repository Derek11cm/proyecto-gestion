import { Navigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

export default function ProtectedRoute({ children }) {
  const { token } = useAuth();

  if (!token) {
    // Si no hay token, redirige a la página de login
    return <Navigate to="/login" />;
  }

  // Si hay un token, renderiza el componente hijo (la página solicitada)
  return children;
}