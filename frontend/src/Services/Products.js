const apiBaseUrl = import.meta.env.VITE_API_BASE_URL;

export const getAllProducts = async (query) => {
    const { pageNumber, pageSize, searchQuery, categoryIds, brandIds } = query;

    let queryParams = [];
    if (pageNumber) {
        queryParams.push(`PageNumber=${pageNumber}`);
    }
    if (pageSize) {
        queryParams.push(`PageSize=${pageSize}`);
    }
    if (searchQuery) {
        queryParams.push(`SearchQuery=${searchQuery}`);
    }
    if (categoryIds && categoryIds.length > 0) {
        categoryIds.forEach((id, index) => {
            queryParams.push(`CategoryIds[${index}]=${id}`);
        });
    }
    if (brandIds && brandIds.length > 0) {
        brandIds.forEach((id, index) => {
            queryParams.push(`BrandIds[${index}]=${id}`);
        });
    }

    const queryString = queryParams.length > 0 ? `?${queryParams.join("&")}` : "";
    const uri = `${apiBaseUrl}/api/products${queryString}`;
    const response = await fetch(uri, { method: "GET" });
    return await response.json();
}

export const createProduct = async (createProductForm) => {
    return await fetch(`${apiBaseUrl}/api/products`, {
        method: "POST",
        body: createProductForm,
        headers: {}
    });
}

export const updateProduct = async (id, updateProductForm) => {
    return await fetch(`${apiBaseUrl}/api/products/${id}`, {
        method: "PUT",
        headers: {},
        body: updateProductForm
    });
}

export const deleteProduct = async (id) => {
    return await fetch(`${apiBaseUrl}/api/products/${id}`, { method: "DELETE" });
}