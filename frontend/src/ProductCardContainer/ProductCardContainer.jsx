import React from "react";
import "./ProductCardContainer.css";
import ProductCard from "./ProductCard/ProductCard";

const ProductCardContainer = ({ products, cartProducts, user, onOpenEditPanel, onAddToCart, onDeleteFromCart, onDeleteProduct }) => {
    return (
        <div className="product-card-container">
            {products.map((product, index) => (
                <ProductCard
                    key={product.id}
                    product={product}
                    user={user}
                    isInCart={cartProducts.some(cartProduct => cartProduct.id === product.id)}
                    onAddToCart={onAddToCart}
                    onDeleteFromCart={onDeleteFromCart}
                    onOpenEditPanel={onOpenEditPanel}
                    onDeleteProduct={onDeleteProduct}
                    animationDelay={`${index * 0.1}s`} // Передаём задержку
                />
            ))}
        </div>
    );
};

export default ProductCardContainer;