import { createBrowserRouter } from "react-router-dom";
import RootLayout from "../components/layout/RootLayout";
import ProtectedRoute from "./ProtectedRoute";

// Layout y Páginas
import MainLayout from "../components/layout/MainLayout";
import LoginPage from "../pages/LoginPage";
import DashboardPage from "../pages/DashboardPage";
import ClientsPage from "../Pages/ClientesPage";

export const router = createBrowserRouter([
  {
    element: <RootLayout />, // 👈 Todo envuelto en AuthProvider
    children: [
      {
        path: "/login",
        element: <LoginPage />,
      },
      {
        path: "/",
        element: (
          <ProtectedRoute>
            <MainLayout />
          </ProtectedRoute>
        ),
        children: [
          {
            index: true,
            element: <DashboardPage />,
          },
          {
            path:"clientes",
            element: <ClientsPage />,
          },
        ],
      },
    ],
  },
]);
