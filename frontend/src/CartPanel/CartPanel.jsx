import "./CartPanel.css"
import CartProductCard from "./CartProductCard/CartProductCard";

const CartPanel = ({ products, onClose, onDeleteFromCart }) => {
    return (
        <div className="overlay" onClick={onClose}>
            <div className="cart-panel" onClick={(e) => e.stopPropagation()}>
                <h2 className="cart-title">Корзина</h2>
                <div className="products">
                    {products.map((product) => (
                        <CartProductCard
                            key={product.id}
                            product={product}
                            onDeleteFromCart={onDeleteFromCart}
                        />
                    ))}
                </div>
                <button className="order-button" onClick={() => alert("Товары заказаны!")}>Заказать</button>
            </div>
        </div>
    );
}

export default CartPanel;