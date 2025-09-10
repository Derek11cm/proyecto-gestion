// In src/services/clienteService.js
import api from './api';

const getClientes = () => {
  // El 'data' es devuelto directamente por nuestro interceptor de api
  return api.get('/clientes'); 
};

const createCliente = (clienteData) => {
  return api.post('/clientes', clienteData);
};

// Aquí podríamos agregar updateCliente, deleteCliente, etc. en el futuro

export default {
  getClientes,
  createCliente,
};