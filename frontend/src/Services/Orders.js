export const createOrder = async (createOrderRequest) => {
    await fetch("/api/orders", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(createOrderRequest)
    });
}