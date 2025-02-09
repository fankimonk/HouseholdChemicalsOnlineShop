import "./ProductCard.css";
import AddToCartButton from "./AddToCartButton/AddToCartButton";
import { useEffect } from "react";
import { deleteProduct } from "../../Services/Products";

const ProductCard = ({ product, user, isInCart, onOpenEditPanel, onAddToCart, onDeleteFromCart, onDeleteProduct, animationDelay }) => {
    const { id, name, description, imagePath, price, stockQuantity } = product;

    const imageUrl = `/images${imagePath}`;

    const onEditPanel = () => {
        onOpenEditPanel(product);
    }

    const onDeleteClick = async () => {
        await deleteProduct(id);
        await onDeleteProduct();
    }

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
                {user && user.role == "Admin" &&
                    <button className="edit-product-btn" onClick={onEditPanel}>
                        Изменить
                    </button>}
                {user && user.role == "Admin" &&
                    <button className="delete-product-btn" onClick={onDeleteClick}>
                        Удалить
                    </button>}
            </div>
        </div>
    );
};

export default ProductCard;