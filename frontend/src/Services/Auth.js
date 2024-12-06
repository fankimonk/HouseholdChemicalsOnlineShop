export const authCheck = async () => {
    const response = await fetch("/api/auth/check", { method: "GET" });
    if (!response.ok) {
        return null;
    }
    return response.json();
}

export const login = async (loginRequest) => {
    return await fetch("/api/auth/login", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(loginRequest)
    });
}

export const register = async (registerRequest) => {
    return await fetch("/api/auth/register", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(registerRequest)
    })
}

export const logout = async () => {
    await fetch("/api/auth/logout", { method: "POST" });
}