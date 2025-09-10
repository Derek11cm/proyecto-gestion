// In src/components/clientes/ClienteForm.jsx
import { useState } from 'react';
import clienteService from '../services/clienteService';

export default function ClienteForm({ onSuccess }) {
  const [nombres, setNombres] = useState('');
  const [apellidos, setApellidos] = useState('');
  const [email, setEmail] = useState('');
  const [documentoIdentidad, setDocumentoIdentidad] = useState('');
  const [telefono, setTelefono] = useState('');
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError('');
    try {
      await clienteService.createCliente({ nombres, apellidos, email, documentoIdentidad, telefono });
      onSuccess(); // Llama a la función de éxito pasada por props
    } catch (err) {
      setError('Error al crear el cliente.');
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  // El JSX para el formulario puede ser extenso, aquí una versión simplificada.
  // Puedes copiar el estilo de la página de login.
  return (
    <form onSubmit={handleSubmit}>
      {error && <p className="text-red-500 mb-4">{error}</p>}
      <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
        {/* Input para Nombres */}
        <div>
          <label htmlFor="nombres">Nombres</label>
          <input id="nombres" type="text" value={nombres} onChange={e => setNombres(e.target.value)} className="w-full border rounded p-2" required />
        </div>
        {/* Input para Apellidos */}
        <div>
          <label htmlFor="apellidos">Apellidos</label>
          <input id="apellidos" type="text" value={apellidos} onChange={e => setApellidos(e.target.value)} className="w-full border rounded p-2" required />
        </div>
        <div>
          <label htmlFor="email">Email</label>
          <input id="email" type="email" value={email} onChange={e => setEmail(e.target.value)} className="w-full border rounded p-2" required />
        </div>
        <div>
          <label htmlFor="telefono">Telefono</label>
          <input id="telefono" type="number" value={telefono} onChange={e => setTelefono(e.target.value)} className="w-full border rounded p-2" required />
        </div>
         {/* ... Agrega los demás inputs para email, documento y teléfono ... */}
      </div>
      <div>
          <label htmlFor="documento_identificacion">DPI</label>
          <input id="documento_identificacion" type="number" value={documentoIdentidad} onChange={e => setDocumentoIdentidad(e.target.value)} className="w-full border rounded p-2" required />
        </div>
      <button type="submit" disabled={loading} className="mt-4 bg-blue-500 text-white rounded p-2">
        {loading ? 'Guardando...' : 'Guardar Cliente'}
      </button>
    </form>
  );
}