// In src/components/parqueos/ParqueoAssignForm.jsx
import { useState, useEffect } from 'react';
import clienteService from '../../services/clienteService';
import parqueoService from '../../services/parqueoService';

export default function ParqueoAssignForm({ parqueoId, onSuccess }) {
  const [clientes, setClientes] = useState([]);
  const [selectedClienteId, setSelectedClienteId] = useState('');
  const [tarifaCobrada, setTarifaCobrada] = useState('');
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  useEffect(() => {
    // Cargar la lista de clientes para el dropdown
    const fetchClientes = async () => {
      try {
        const response = await clienteService.getClientes();
        setClientes(response.data);
      } catch {
        setError('No se pudieron cargar los clientes.');
      }
    };
    fetchClientes();
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError('');
    try {
      await parqueoService.assignParqueo({
        clienteId: parseInt(selectedClienteId),
        parqueoId: parqueoId,
        tarifaCobrada: parseFloat(tarifaCobrada)
      });
      onSuccess(); // Notificar al componente padre que la asignación fue exitosa
    } catch (err) {
      setError(err.response?.data || 'Error al asignar el parqueo.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      {error && <p className="text-red-500 mb-4">{error}</p>}
      <div className="mb-4">
        <label htmlFor="cliente" className="block text-sm font-medium text-gray-700">Seleccionar Cliente</label>
        <select
          id="cliente"
          value={selectedClienteId}
          onChange={e => setSelectedClienteId(e.target.value)}
          className="mt-1 block w-full pl-3 pr-10 py-2 text-base border-gray-300 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm rounded-md"
          required
        >
          <option value="">-- Seleccione un cliente --</option>
          {clientes.map(cliente => (
            <option key={cliente.id} value={cliente.id}>{cliente.nombreCompleto}</option>
          ))}
        </select>
      </div>
      <div className="mb-4">
        <label htmlFor="tarifa" className="block text-sm font-medium text-gray-700">Tarifa a Cobrar</label>
        <input
          id="tarifa"
          type="number"
          step="0.01"
          value={tarifaCobrada}
          onChange={e => setTarifaCobrada(e.target.value)}
          className="mt-1 block w-full border rounded-md p-2"
          required
        />
      </div>
      <button type="submit" disabled={loading} className="w-full bg-green-500 text-white rounded p-2">
        {loading ? 'Asignando...' : 'Confirmar Asignación'}
      </button>
    </form>
  );
}