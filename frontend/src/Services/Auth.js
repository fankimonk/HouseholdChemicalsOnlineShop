export const authCheck = async () => {
    const response = await fetch("/api/auth/check", { method: "GET" });
    if (!response.ok) {
        return null;
    }
    return response.json();
}

export const logout = async () => {
    await fetch("/api/auth/logout", { method: "POST" });
}