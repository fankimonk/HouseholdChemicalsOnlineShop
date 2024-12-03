import React from "react";
import "./ProductCardContainer.css";
import ProductCard from "./ProductCard/ProductCard";

const ProductCardContainer = ({ products, cartProducts, user, onAddToCart, onDeleteFromCart }) => {
    return (
        <div className="product-card-container">
            {products.map((product) => (
                <ProductCard
                    key={product.id}
                    product={product}
                    user={user}
                    isInCart={cartProducts.some(cartProduct => cartProduct.id === product.id)}
                    onAddToCart={onAddToCart}
                    onDeleteFromCart={onDeleteFromCart}
                />
            ))}
        </div>
    );
};

export default ProductCardContainer;
