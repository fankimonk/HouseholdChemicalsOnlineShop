export const getAllProducts = async () => {
    const response = await fetch(`/api/products`, { method: "GET" });
    return await response.json();
}