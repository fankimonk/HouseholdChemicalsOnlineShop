import React from "react";
import "./ProductCardContainer.css";
import ProductCard from "../ProductCard/ProductCard";

const ProductCardContainer = ({ products }) => {
    return (
        <div className="product-card-container">
            {products.map((product) => (
                <ProductCard
                    key={product.id}
                    product={product}
                />
            ))}
        </div>
    );
};

export default ProductCardContainer;
