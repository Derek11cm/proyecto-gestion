import { createBrowserRouter } from 'react-router-dom';

// Layout y Páginas
import MainLayout from '../components/layout/MainLayout';
import LoginPage from '../Pages/LoginPage';
import DashboardPage from '../pages/DashboardPage';
import ClientesPage from '../pages/ClientesPage';

export const router = createBrowserRouter([
  {
    path: '/login',
    element: <LoginPage />,
  },
  {
    path: '/',
    element: <MainLayout />,
    children: [
      {
        index: true, // Esto hace que sea la ruta por defecto del layout
        element: <DashboardPage />,
      },
      {
        path: 'clientes',
        element: <ClientesPage />,
      },
      // ... aquí agregarías más rutas protegidas en el futuro
      // { path: 'parqueos', element: <ParqueosPage /> },
    ],
  },
]);