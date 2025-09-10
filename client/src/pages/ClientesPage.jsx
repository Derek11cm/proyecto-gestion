import { useState, useEffect, useCallback } from 'react';
import clienteService from '../services/clienteService';
import Modal from '../components/Modal';
import ClienteForm from '../components/ClienteForm';
import { useAuth } from '../context/AuthContext';

export default function ClientsPage() {
  const [clientes, setClientes] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');
  const [isModalOpen, setIsModalOpen] = useState(false);
  const { logout } = useAuth();

  const fetchClientes = useCallback(async () => {
    try {
      const response = await clienteService.getClientes();
      setClientes(response.data);
    } catch (err) {
      setError('No se pudieron cargar los clientes.');
      if (err.response && err.response.status === 401) logout();
    } finally {
      setLoading(false);
    }
  }, [logout]);

  useEffect(() => {
    fetchClientes();
  }, [fetchClientes]);

  const handleSuccess = () => {
    setIsModalOpen(false);
    fetchClientes(); // Recargar la lista de clientes después de crear uno nuevo
  };

  if (loading) return <p>Cargando clientes...</p>;
  if (error) return <p className="text-red-500">{error}</p>;

  return (
    <div>
      <div className="flex justify-between items-center mb-6">
        <h2 className="text-2xl font-semibold text-gray-800">Gestión de Clientes</h2>
        <button onClick={() => setIsModalOpen(true)} className="bg-blue-500 text-white font-bold py-2 px-4 rounded">
          Agregar Cliente
        </button>
      </div>

      {/* Tabla de Clientes */}
      <div className="bg-white shadow rounded-lg overflow-x-auto">
        <table className="min-w-full leading-normal">
          <thead>
            <tr>
              <th className="px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-left text-xs font-semibold text-gray-600 uppercase tracking-wider">Nombre</th>
              <th className="px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-left text-xs font-semibold text-gray-600 uppercase tracking-wider">Email</th>
              <th className="px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-left text-xs font-semibold text-gray-600 uppercase tracking-wider">Estado</th>
            </tr>
          </thead>
          <tbody>
            {clientes.map(cliente => (
              <tr key={cliente.id}>
                <td className="px-5 py-5 border-b border-gray-200 bg-white text-sm">{cliente.nombreCompleto}</td>
                <td className="px-5 py-5 border-b border-gray-200 bg-white text-sm">{cliente.email}</td>
                <td className="px-5 py-5 border-b border-gray-200 bg-white text-sm">
                  <span className={`relative inline-block px-3 py-1 font-semibold leading-tight ${cliente.activo ? 'text-green-900' : 'text-gray-900'}`}>
                    <span aria-hidden className={`absolute inset-0 ${cliente.activo ? 'bg-green-200' : 'bg-gray-200'} opacity-50 rounded-full`}></span>
                    <span className="relative">{cliente.activo ? 'Activo' : 'Inactivo'}</span>
                  </span>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      {/* Modal para crear cliente */}
      <Modal isOpen={isModalOpen} onClose={() => setIsModalOpen(false)} title="Agregar Nuevo Cliente">
        <ClienteForm onSuccess={handleSuccess} />
      </Modal>
    </div>
  );
}