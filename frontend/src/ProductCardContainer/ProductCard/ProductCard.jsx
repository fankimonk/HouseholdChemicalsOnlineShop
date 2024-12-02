import React from "react";
import "./ProductCard.css";

const ProductCard = ({ product, user }) => {
    const {
        id,
        name,
        description,
        image,
        price,
        stockQuantity
    } = product;

    return (
        <div className="product-card">
            <img src={image} alt={name} className="product-image" />
            <div className="product-info">
                <h2 className="product-title">{name}</h2>
                <p className="product-description">{description}</p>
            </div>
            <div className="product-actions">
                <p className="product-price">{price} ₽</p>
                {user ? (
                    <button className="add-to-cart-button">В корзину</button>
                ) : (
                    <button className="add-to-cart-button-unauth">Вы не вошли в аккаунт</button>
                )}

            </div>
        </div>
    );
};

export default ProductCard;
