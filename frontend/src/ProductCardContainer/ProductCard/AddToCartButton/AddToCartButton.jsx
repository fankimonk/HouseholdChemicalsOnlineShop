import "./AddToCartButton.css";

const AddToCartButton = ({ productId, user, isInCart, onAddToCart, onDeleteFromCart }) => {
    const onAdd = async () => {
        await onAddToCart(productId);
    };

    const onDelete = async () => {
        await onDeleteFromCart(productId);
    };

    return (
        <div>
            {user ? (
                <div>
                    {isInCart ? (
                        <button className="addtocart-button-in-cart" onClick={onDelete}>✓В корзине</button>
                    ) : (
                        <button className="addtocart-button" onClick={onAdd}>В корзину</button>
                    )}
                </div>
            ) : (
                <button className="addtocart-button-unauth">Вы не вошли в аккаунт</button>
            )}
        </div>
    );
}

export default AddToCartButton;