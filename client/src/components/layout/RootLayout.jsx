import { Outlet } from "react-router-dom";
import { AuthProvider } from "../../context/AuthContext";

export default function RootLayout() {
  return (
    <AuthProvider>
      {/* Todas las rutas hijas van aquí */}
      <Outlet />
    </AuthProvider>
  );
}
