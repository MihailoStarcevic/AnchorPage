import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './App.css'
import App from './App.tsx'
import { createBrowserRouter, RouterProvider } from "react-router-dom"
import Test from './components/Test.tsx'

const router = createBrowserRouter([
  {path: "/", element: <App />},
  {path: "/test", element: <Test />}
]);

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>,
)
