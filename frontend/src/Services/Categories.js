export const getAllCategories = async () => {
    const response = await fetch("/api/categories", { method: "GET" });
    return await response.json();
}