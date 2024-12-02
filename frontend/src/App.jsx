import './App.css'
import FilterPanel from './FilterPanel/FilterPanel'
import Header from './Header/Header'
import ProductCardContainer from './ProductCardContainer/ProductCardContainer'
import { useState, useEffect } from 'react'
import AuthPanel from './AuthPanel/AuthPanel'
import { authCheck, logout } from './Services/Auth'

function App() {
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
    console.log(selectedCategories);
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
    console.log(selectedBrands);
  };

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

  const [user, setUser] = useState(null);

  const checkAuth = async () => {
    const userResponse = await authCheck();
    setUser(userResponse);
  };

  useEffect(() => {
    checkAuth();
  }, []);

  const onLogout = async () => {
    await logout();
    checkAuth();
  };

  return (
    <>
      <Header
        user={user}
        onLogout={onLogout}
        onLoginClick={openLoginPanel}
        onRegisterClick={openRegisterPanel}
      />
      {isAuthPanelOpen && (<AuthPanel isLogin={isLogin} onClose={closeAuthPanel} />)}
      < FilterPanel
        onCategoryChange={onCategoryChange}
        onBrandChange={onBrandChange}
      />
      <ProductCardContainer user={user} />
    </>
  )
}

export default App
