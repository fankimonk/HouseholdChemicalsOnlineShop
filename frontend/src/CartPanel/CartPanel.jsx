import "./CartPanel.css"
import CartProductCard from "./CartProductCard/CartProductCard";
import FormInput from "../Form/FormInput/FormInput";
import { createOrder } from "../Services/Orders";

const CartPanel = ({ products, onClose, onDeleteFromCart }) => {
    const onOrder = async (e) => {
        e.preventDefault();

        if (products.some(product => product.stockQuantity == 0)) {
            alert("Одного из товаров нет в наличии. Удалите его из корзины и попробуйте еще раз.")
            return;
        }

        products.forEach(async (product) => {
            await onDeleteFromCart(product.id);
        });

        const formData = new FormData(e.target);
        const createOrderRequest = {
            shippingAddress: formData.get('shippingAddress'),
            productIds: products.map(p => p.id)
        }
        console.log(createOrderRequest);

        await createOrder(createOrderRequest);
        alert('Товары заканы!');
    };

    return (
        <div className="overlay" onClick={onClose}>
            <div className="cart-panel" onClick={(e) => e.stopPropagation()}>
                <h2 className="cart-title">Корзина</h2>
                <div className="products">
                    {products.length == 0 ? (
                        <p style={{ color: "grey" }}>Корзина пуста</p>
                    ) : (
                        products.map((product) => (
                            <CartProductCard
                                key={product.id}
                                product={product}
                                onDeleteFromCart={onDeleteFromCart}
                            />
                        ))
                    )}
                </div>
                {products.length != 0 &&
                    <form onSubmit={onOrder}>
                        <FormInput
                            labelText={"Адрес доставки"}
                            placeholderText={"Введите адрес"}
                            type={"text"}
                            name={"shippingAddress"}
                        />
                        <button className="order-button" type="submit">Заказать</button>
                    </form>}
            </div>
        </div>
    );
}

export default CartPanel;