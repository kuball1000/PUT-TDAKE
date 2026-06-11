import { useState, useEffect } from 'react'
import { createBrowserRouter, RouterProvider } from 'react-router-dom'
import './App.css'
import ProductList from './ProductList'
import ProductDetails from './ProductDetails'

function App() {
  const [products, setProducts] = useState([]);

  useEffect(() => {
      fetch('https://dummyjson.com/products')
          .then(res => res.json())
          .then(data => {
              setProducts(data.products);
          })
          .catch(err => console.error("Error fetching products:", err));
  }, []);

  const router = createBrowserRouter([
    {
      path: "/",
      element: <ProductList products={products} />,
    },
    {
      path: "details/:id",
      element: <ProductDetails products={products} />,
    }
  ]);

  return <RouterProvider router={router} />
}
export default App
