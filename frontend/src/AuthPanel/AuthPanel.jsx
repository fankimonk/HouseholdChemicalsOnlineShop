import React, { useState } from "react";
import "./AuthPanel.css";
import LoginPanel from "./LoginPanel/LoginPanel";
import RegisterPanel from "./RegisterPanel/RegisterPanel";

const AuthPanel = ({ isLogin, onLogin, onClose }) => {
    const [isLoginPanel, setIsLoginPanel] = useState(isLogin);

    const openLoginPanel = () => {
        setIsLoginPanel(true);
    }

    const openRegisterPanel = () => {
        setIsLoginPanel(false);
    }

    return (
        <div className="auth-container" onClick={onClose}>
            {isLoginPanel ? (
                <LoginPanel onLogin={onLogin} onRegisterPanel={openRegisterPanel} />
            ) : (
                <RegisterPanel onLogin={onLogin} onLoginPanel={openLoginPanel} />
            )}
        </div>
    );
};

export default AuthPanel;
