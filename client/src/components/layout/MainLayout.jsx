import { Outlet } from 'react-router-dom';

export default function MainLayout() {
  return (
    <div className="min-h-screen bg-gray-100">
      {/* Aquí iría un Navbar o un Sidebar en el futuro */}
      <header className="bg-white shadow">
        <div className="max-w-7xl mx-auto py-6 px-4">
          <h1 className="text-3xl font-bold text-gray-900">Mi Aplicación</h1>
        </div>
      </header>

      <main>
        <div className="max-w-7xl mx-auto py-6 px-4">
          {/* Outlet renderizará el componente de la ruta hija (Dashboard, Clientes, etc.) */}
          <Outlet /> 
        </div>
      </main>
    </div>
  );
}