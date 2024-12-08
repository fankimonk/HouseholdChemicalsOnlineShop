import React, { useState } from "react";
import "./AuthPanel.css";
import LoginPanel from "./LoginPanel/LoginPanel";
import RegisterPanel from "./RegisterPanel/RegisterPanel";
import { login, register } from "../Services/Auth";

const AuthPanel = ({ isLogin, onLogin, onClose }) => {
    const [isLoginPanel, setIsLoginPanel] = useState(isLogin);
    const [errorText, setErrorText] = useState(null);

    const onLoginClick = async (e) => {
        e.preventDefault();

        const formData = new FormData(e.target);
        const loginRequest = {
            email: formData.get('email'),
            password: formData.get('password'),
        };

        const response = await login(loginRequest);
        if (!response.ok) {
            const errorText = await response.text();
            setErrorText(errorText);
            return;
        }

        onLogin();
        setErrorText(null);
    };

    const onRegisterClick = async (e) => {
        e.preventDefault();

        const formData = new FormData(e.target);
        const registerRequest = {
            userName: formData.get('userName'),
            email: formData.get('email'),
            password: formData.get('password'),
        };

        const registerResponse = await register(registerRequest);
        if (!registerResponse.ok) {
            const errorText = await registerResponse.text();
            setErrorText(errorText);
            return;
        }

        await onLoginClick(e);
    };

    const openLoginPanel = () => {
        setIsLoginPanel(true);
    }

    const openRegisterPanel = () => {
        setIsLoginPanel(false);
    }

    return (
        <div className="auth-container" onClick={onClose}>
            {isLoginPanel ? (
                <LoginPanel onLogin={onLoginClick} onRegisterPanel={openRegisterPanel} error={errorText} />
            ) : (
                <RegisterPanel onRegister={onRegisterClick} onLoginPanel={openLoginPanel} error={errorText} />
            )}
        </div>
    );
};

export default AuthPanel;
