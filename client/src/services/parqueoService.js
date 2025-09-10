import api from './api';

const getParqueos = () => {
  return api.get('/parqueos');
};

const createParqueo = (parqueoData) => {
  return api.post('/parqueos', parqueoData);
};

// --- NUEVA FUNCIÓN ---
const assignParqueo = ({ clienteId, parqueoId, tarifaCobrada }) => {
  return api.post('/parqueos/asignar', { clienteId, parqueoId, tarifaCobrada });
};

export default {
  getParqueos,
  createParqueo,
  assignParqueo,
};