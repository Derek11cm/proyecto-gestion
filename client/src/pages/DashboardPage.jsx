import { useState, useEffect } from 'react';
import dashboardService from '../services/dashboardService';
import StatCard from '../components/dashboard/StatCard';
import { useAuth } from '../context/AuthContext';

export default function DashboardPage() {
  const [stats, setStats] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');
  const { logout } = useAuth();

  useEffect(() => {
    const fetchStats = async () => {
      try {
        const data = await dashboardService.getDashboardStats();
        setStats(data);
      } catch (err) {
        console.error('Failed to fetch dashboard stats:', err);
        setError('No se pudieron cargar los datos del dashboard. Intente de nuevo.');
        if (err.response && err.response.status === 401) {
          // Si el token no es válido, cerramos la sesión
          logout();
        }
      } finally {
        setLoading(false);
      }
    };

    fetchStats();
  }, [logout]); // Agregamos logout a las dependencias

  if (loading) {
    return <p className="text-center text-gray-500">Cargando dashboard...</p>;
  }

  if (error) {
    return <p className="text-center text-red-500">{error}</p>;
  }

  return (
    <div>
      <h2 className="text-2xl font-semibold text-gray-800 mb-6">Resumen General</h2>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        <StatCard title="Total de Clientes" value={stats.totalClientes} />
        <StatCard title="Parqueos Disponibles" value={stats.parqueosDisponibles} />
        <StatCard title="Parqueos Ocupados" value={stats.parqueosOcupados} />
        <StatCard title="Habitaciones Disponibles" value={stats.habitacionesDisponibles} />
        <StatCard title="Habitaciones Ocupadas" value={stats.habitacionesOcupadas} />
      </div>
    </div>
  );
}