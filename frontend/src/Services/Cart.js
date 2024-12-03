export const addProductToCart = async (productId) => {
    await fetch('/api/carts/' + productId, { method: "POST" });
}

export const deleteProductFromCart = async (productId) => {
    await fetch('/api/carts/' + productId, { method: "DELETE" });
}

export const getProductsInCart = async () => {
    const response = await fetch('/api/carts/getproducts', { method: "GET" });
    return response.json();
}

export const getProductIdsInCart = async () => {
    const response = await fetch('/api/carts/getproductids', { method: "GET" });
    return response.json();
}