import api from './api'; // Importamos nuestra instancia configurada de Axios

const getDashboardStats = async () => {
  // Hacemos todas las llamadas en paralelo para mayor eficiencia
  const [clientesRes, parqueosRes, habitacionesRes] = await Promise.all([
    api.get('/clientes'),
    api.get('/parqueos'),
    api.get('/habitaciones'),
  ]);

  // Procesamos los datos para obtener las métricas que nos interesan
  const stats = {
    totalClientes: clientesRes.data.length,
    parqueosDisponibles: parqueosRes.data.filter(p => p.estado === 'Disponible').length,
    parqueosOcupados: parqueosRes.data.filter(p => p.estado === 'Ocupado').length,
    habitacionesDisponibles: habitacionesRes.data.filter(h => h.estado === 'Disponible').length,
    habitacionesOcupadas: habitacionesRes.data.filter(h => h.estado === 'Ocupada').length,
  };

  return stats;
};

export default {
  getDashboardStats,
};