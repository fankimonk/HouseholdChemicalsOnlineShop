import './App.css'
import FilterPanel from './FilterPanel/FilterPanel'
import Header from './Header/Header'
import ProductCardContainer from './ProductCardContainer/ProductCardContainer'
import { useState, useEffect } from 'react'
import AuthPanel from './AuthPanel/AuthPanel'
import { authCheck, logout } from './Services/Auth'
import CartPanel from './CartPanel/CartPanel'
import { getProductsInCart } from './Services/Cart'
import { getAllProducts } from "./Services/Products";
import { getAllCategories } from './Services/Categories'
import { getAllBrands } from './Services/Brands'
import { addProductToCart, deleteProductFromCart } from "./Services/Cart";
import AddProductButton from './AdminComponents/AddProductButton/AddProductButton'
import EditProductPanel from './AdminComponents/EditProductPanel/EditProductPanel'
import AddProductPanel from './AdminComponents/AddProductPanel/AddProductPanel'

function App() {
  //#region Categories and Brands
  const [categories, setCategories] = useState([]);
  const [categoriesLoading, setCategoriesLoading] = useState(true);

  const [brands, setBrands] = useState([]);
  const [brandsLoading, setBrandsLoading] = useState(true);

  useEffect(() => {
    const fetchCategories = async () => {
      setCategoriesLoading(true);
      const response = await getAllCategories();
      setCategories(response);
      setCategoriesLoading(false);
    }

    fetchCategories();
  }, []);

  useEffect(() => {
    const fetchBrands = async () => {
      setBrandsLoading(true);
      const response = await getAllBrands();
      setBrands(response);
      setBrandsLoading(false);
    }

    fetchBrands();
  }, []);
  //#endregion

  //#region Selected Categories and Brands
  const [selectedCategories, setSelectedCategories] = useState([]);

  const onCategoryChange = (categoryId, isChecked) => {
    const index = selectedCategories.indexOf(categoryId);
    if (!isChecked) {
      if (index !== -1)
        selectedCategories.splice(index, 1);
    }
    else {
      if (index === -1)
        selectedCategories.push(categoryId);
    }

    setSelectedCategories(selectedCategories);
    fetchProducts();
  };

  const [selectedBrands, setSelectedBrands] = useState([]);

  const onBrandChange = (brandId, isChecked) => {
    const index = selectedBrands.indexOf(brandId);
    if (!isChecked) {
      if (index !== -1)
        selectedBrands.splice(index, 1);
    }
    else {
      if (index === -1)
        selectedBrands.push(brandId);
    }

    setSelectedBrands(selectedBrands);
    fetchProducts();
  };
  //#endregion

  //#region Products
  const [products, setProducts] = useState([]);
  const [productsLoading, setProductsLoading] = useState(true);
  const [searchQuery, setSearchQuery] = useState(null);

  useEffect(() => {
    if (searchQuery !== null) {
      fetchProducts();
    }
  }, [searchQuery]);

  const fetchProducts = async () => {
    setProductsLoading(true);
    const response = await getAllProducts({
      searchQuery: searchQuery,
      categoryIds: selectedCategories,
      brandIds: selectedBrands
    });
    setProducts(response);
    setProductsLoading(false);
  };

  const onSearch = (searchQuery) => {
    setSearchQuery(searchQuery);
  };

  useEffect(() => {
    fetchProducts();
  }, []);
  //#endregion

  //#region User
  const [user, setUser] = useState(null);

  const fetchUser = async () => {
    const userResponse = await authCheck();
    setUser(userResponse);
  };

  useEffect(() => {
    fetchUser();
  }, []);

  const onLogin = async () => {
    closeAuthPanel();
    fetchUser();
  }

  useEffect(() => {
    fetchCartProducts();
  }, [user]);

  const onLogout = async () => {
    await logout();
    fetchUser();
    setCartProducts([]);
  };
  //#endregion

  //#region Cart
  const [isCartPanelOpen, setIsCartPanelOpen] = useState(false);
  const [cartProducts, setCartProducts] = useState([]);
  const [cartProductsLoading, setCartProductsLoading] = useState(true);

  const fetchCartProducts = async () => {
    if (user) {
      setCartProductsLoading(true);
      const response = await getProductsInCart();
      setCartProducts(response);
      setCartProductsLoading(false);
    }
  };

  const addCartProduct = async (id) => {
    await addProductToCart(id);
    fetchCartProducts();
  };

  const deleteCartProduct = async (id) => {
    await deleteProductFromCart(id);
    fetchCartProducts();
  };

  const openCartPanel = async () => {
    setIsCartPanelOpen(true);
  };

  const closeCartPanel = () => {
    setIsCartPanelOpen(false);
  };
  //#endregion

  //#region AuthPanel
  const [isAuthPanelOpen, setIsAuthPanelOpen] = useState(false);
  const [isLogin, setIsLogin] = useState(true);

  const openLoginPanel = () => {
    setIsAuthPanelOpen(true);
    setIsLogin(true);
  };

  const openRegisterPanel = () => {
    setIsAuthPanelOpen(true);
    setIsLogin(false);
  };

  const closeAuthPanel = () => {
    setIsAuthPanelOpen(false);
  };
  //#endregion

  //#region EditProduct
  const [isAddProductPanelOpen, setIsAddProductPanelOpen] = useState(false);
  const [isEditProductPanelOpen, setIsEditProductPanelOpen] = useState(false);
  const [selectedProduct, setSelectedProduct] = useState(null);

  const openAddProductPanel = () => {
    setIsAddProductPanelOpen(true);
  }

  const openEditProductPanel = (product) => {
    setSelectedProduct(product);
    setIsEditProductPanelOpen(true);
  }

  const closeProductPanel = () => {
    setIsAddProductPanelOpen(false);
    setIsEditProductPanelOpen(false);
  }

  //#endregion

  return (
    <>
      <Header
        onSearch={onSearch}
        user={user}
        onCartOpen={openCartPanel}
        onLogout={onLogout}
        onLoginClick={openLoginPanel}
        onRegisterClick={openRegisterPanel}
      />
      {isAuthPanelOpen && (<AuthPanel isLogin={isLogin} onLogin={onLogin} onClose={closeAuthPanel} />)}
      {isCartPanelOpen && (
        <CartPanel
          products={cartProducts}
          onClose={closeCartPanel}
          onDeleteFromCart={deleteCartProduct}
        />)}
      < FilterPanel
        user={user}
        categories={categories}
        brands={brands}
        onCategoryChange={onCategoryChange}
        onBrandChange={onBrandChange}
      />
      <ProductCardContainer
        products={products}
        cartProducts={cartProducts}
        user={user}
        onAddToCart={addCartProduct}
        onDeleteFromCart={deleteCartProduct}
        onDeleteProduct={fetchProducts}
        onOpenEditPanel={openEditProductPanel}
      />
      {user && user.role == "Admin" && (<AddProductButton onClick={openAddProductPanel} />)}
      {isAddProductPanelOpen &&
        <AddProductPanel
          header={"Добавить товар"}
          submitButtonText={"Добавить"}
          categories={categories}
          brands={brands}
          onAdd={fetchProducts}
          onClose={closeProductPanel}
        />}
      {isEditProductPanelOpen &&
        <EditProductPanel
          product={selectedProduct}
          header={"Изменить товар"}
          submitButtonText={"Изменить"}
          categories={categories}
          brands={brands}
          onEdit={fetchProducts}
          onClose={closeProductPanel}
        />}
    </>
  )
}

export default App
