import React from "react";
import "./ProductCardContainer.css";
import ProductCard from "./ProductCard/ProductCard";
import { useState, useEffect } from "react";
import { getAllProducts } from "../Services/Products";

const ProductCardContainer = ({ user }) => {
    const [products, setProducts] = useState([]);
    const [productsLoading, setProductsLoading] = useState(true);

    const getProducts = async () => {
        setProductsLoading(true);
        const response = await getAllProducts();
        setProducts(response);
        setProductsLoading(false);
    }

    useEffect(() => {
        getProducts();
    }, []);

    return (
        <div className="product-card-container">
            {products.map((product) => (
                <ProductCard
                    key={product.id}
                    product={product}
                    user={user}
                />
            ))}
        </div>
    );
};

export default ProductCardContainer;
