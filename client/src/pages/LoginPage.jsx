import { useState } from 'react';
import { useAuth } from '../context/AuthContext';
import { Link } from 'react-router-dom';

export default function LoginPage() {
  // State for the form inputs
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  // State for handling loading and errors
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');
  const { login } = useAuth(); //
  
  
  
  const handleSubmit = async (event) => {
    event.preventDefault();
    setLoading(true);
    setError('');
    try {
      await login(username, password);
      // La redirección ahora ocurre dentro de la función login del contexto
    } catch {
      setError('Usuario o contraseña incorrectos.');
      setLoading(false);
    }
  };



  return (
    <div className="min-h-screen bg-gray-100 flex items-center justify-center">
      <div className="max-w-md w-full bg-white rounded-lg shadow-md p-8">
        <h2 className="text-2xl font-bold text-center text-gray-800 mb-6">Iniciar Sesión</h2>
        
        <form onSubmit={handleSubmit}>
          {/* Display error message if it exists */}
          {error && <p className="bg-red-100 text-red-700 p-3 rounded mb-4">{error}</p>}
          
          <div className="mb-4">
            <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="username">
              Usuario
            </label>
            <input
              id="username"
              type="text"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              required
            />
          </div>

          <div className="mb-6">
            <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="password">
              Contraseña
            </label>
            <input
              id="password"
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline"
              required
            />
          </div>

          <div className="flex items-center justify-between">
            <button
              type="submit"
              disabled={loading}
              className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline disabled:bg-blue-300"
            >
              {loading ? 'Ingresando...' : 'Ingresar'}
            </button>
            {/* --- NUEVO ENLACE --- */}
            <Link to="/register" className="mt-4 text-sm text-blue-500 hover:underline">
              ¿No tienes una cuenta? Regístrate aquí
            </Link>
          </div>
        </form>
      </div>
    </div>
  );
}