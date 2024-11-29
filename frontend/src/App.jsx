import './App.css'
import FilterPanel from './FilterPanel/FilterPanel'
import Header from './Header/Header'
import ProductCardContainer from './ProductCardContainer/ProductCardContainer'
import { useState, useEffect } from 'react'
import { getAllProducts } from './Services/Products'
import { getAllCategories } from './Services/Categories'
import { getAllBrands } from './Services/Brands'

function App() {
  const [products, setProducts] = useState([]);
  const [productsLoading, setProductsLoading] = useState(true);

  const [categories, setCategories] = useState([]);
  const [categoriesLoading, setCategoriesLoading] = useState(true);

  const [brands, setBrands] = useState([]);
  const [brandsLoading, setBrandsLoading] = useState(true);

  useEffect(() => {
    const getProducts = async () => {
      const response = await getAllProducts();
      setProducts(response);
      setProductsLoading(false);
    }

    getProducts();
  }, []);

  useEffect(() => {
    const getCategories = async () => {
      const response = await getAllCategories();
      setCategories(response);
      setCategoriesLoading(false);
    }

    getCategories();
  }, []);

  useEffect(() => {
    const getBrands = async () => {
      const response = await getAllBrands();
      setBrands(response);
      setBrandsLoading(false);
    }

    getBrands();
  }, []);

  return (
    <>
      <Header />
      <div>
        {categoriesLoading || brandsLoading ? (
          <p style={{ marginTop: "60px" }}>Загрузка...</p>
        ) : (
          < FilterPanel categories={categories} brands={brands} />
        )}
      </div>
      <div>
        {productsLoading ? (
          <p style={{ marginLeft: "20%", padding: "20px" }}>Загрузка...</p>
        ) : (
          <ProductCardContainer products={products} />
        )}
      </div>
    </>
  )
}

export default App
