export const getAllBrands = async () => {
    const response = await fetch("/api/brands", { method: "GET" });
    return await response.json();
} 