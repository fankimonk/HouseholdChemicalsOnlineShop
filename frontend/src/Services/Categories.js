const apiBaseUrl = import.meta.env.VITE_API_BASE_URL;

export const getAllCategories = async () => {
    const response = await fetch(`${apiBaseUrl}/api/categories`, { method: "GET" });
    return await response.json();
}