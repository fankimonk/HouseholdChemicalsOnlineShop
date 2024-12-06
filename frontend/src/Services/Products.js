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
    const uri = `/api/products${queryString}`;
    const response = await fetch(uri, { method: "GET" });
    return await response.json();
}