import { useState, useEffect, useCallback } from 'react';
import parqueoService from '../services/parqueoService';
import Modal from '../components/ui/Modal';
import ParqueoAssignForm from '../components/parqueos/ParqueoAssignForm';
import { useAuth } from '../context/AuthContext';

export default function ParqueosPage() {
  const [parqueos, setParqueos] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');
  const [isAssignModalOpen, setIsAssignModalOpen] = useState(false);
  const [selectedParqueo, setSelectedParqueo] = useState(null);
  const { logout } = useAuth();

  const fetchParqueos = useCallback(async () => {
    setLoading(true);
    try {
      const response = await parqueoService.getParqueos();
      setParqueos(response.data);
    } catch (err) {
      setError('No se pudieron cargar los parqueos.');
      if (err.response && err.response.status === 401) logout();
    } finally {
      setLoading(false);
    }
  }, [logout]);

  useEffect(() => {
    fetchParqueos();
  }, [fetchParqueos]);

  const openAssignModal = (parqueo) => {
    setSelectedParqueo(parqueo);
    setIsAssignModalOpen(true);
  };

  const handleAssignSuccess = () => {
    setIsAssignModalOpen(false);
    fetchParqueos(); // Recargar la lista para ver el estado actualizado
  };

  if (loading) return <p>Cargando parqueos...</p>;
  if (error) return <p className="text-red-500">{error}</p>;

  return (
    <div>
      <h2 className="text-2xl font-semibold text-gray-800 mb-6">Gestión de Parqueos</h2>

      {/* Tabla de Parqueos */}
      <div className="bg-white shadow rounded-lg overflow-x-auto">
        <table className="min-w-full leading-normal">
          <thead>
            <tr>
              <th className="px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-left text-xs font-semibold text-gray-600 uppercase">Código</th>
              <th className="px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-left text-xs font-semibold text-gray-600 uppercase">Descripción</th>
              <th className="px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-left text-xs font-semibold text-gray-600 uppercase">Estado</th>
              <th className="px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-left text-xs font-semibold text-gray-600 uppercase">Acciones</th>
            </tr>
          </thead>
          <tbody>
            {parqueos.map(parqueo => (
              <tr key={parqueo.id}>
                <td className="px-5 py-5 border-b border-gray-200 bg-white text-sm">{parqueo.codigo}</td>
                <td className="px-5 py-5 border-b border-gray-200 bg-white text-sm">{parqueo.descripcion}</td>
                <td className="px-5 py-5 border-b border-gray-200 bg-white text-sm">
                  <span className={`font-semibold ${parqueo.estado === 'Disponible' ? 'text-green-600' : 'text-red-600'}`}>
                    {parqueo.estado}
                  </span>
                </td>
                <td className="px-5 py-5 border-b border-gray-200 bg-white text-sm">
                  {parqueo.estado === 'Disponible' && (
                    <button 
                      onClick={() => openAssignModal(parqueo)}
                      className="bg-green-500 hover:bg-green-700 text-white text-xs font-bold py-1 px-2 rounded"
                    >
                      Asignar
                    </button>
                  )}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      {/* Modal para Asignar Parqueo */}
      {selectedParqueo && (
        <Modal isOpen={isAssignModalOpen} onClose={() => setIsAssignModalOpen(false)} title={`Asignar Parqueo ${selectedParqueo.codigo}`}>
          <ParqueoAssignForm 
            parqueoId={selectedParqueo.id} 
            onSuccess={handleAssignSuccess} 
          />
        </Modal>
      )}
    </div>
  );
}