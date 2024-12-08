import "./ProductCard.css";
import AddToCartButton from "./AddToCartButton/AddToCartButton";
import { useEffect } from "react";

const ProductCard = ({ product, user, isInCart, onAddToCart, onDeleteFromCart, animationDelay }) => {
    const { id, name, description, imagePath, price, stockQuantity } = product;

    const imageUrl = `/images${imagePath}`;

    useEffect(() => {
        console.log(imageUrl);
    }, []);

    return (
        <div
            className="product-card"
            style={{
                animationDelay, // Применяем задержку
            }}
        >
            <img src={imageUrl} alt={name} className="product-image" />
            <div className="product-info">
                <h2 className="product-title">{name}</h2>
                <p className="product-description">{description}</p>
            </div>
            <div className="product-actions">
                <p className="product-price">{price} ₽</p>
                <AddToCartButton
                    productId={id}
                    user={user}
                    isInCart={isInCart}
                    onAddToCart={onAddToCart}
                    onDeleteFromCart={onDeleteFromCart}
                />
            </div>
        </div>
    );
};

export default ProductCard;