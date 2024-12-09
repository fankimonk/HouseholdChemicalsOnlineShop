const apiBaseUrl = import.meta.env.VITE_API_BASE_URL;

export const getAllBrands = async () => {
    const response = await fetch(`${apiBaseUrl}/api/brands`, { method: "GET" });
    return await response.json();
} 