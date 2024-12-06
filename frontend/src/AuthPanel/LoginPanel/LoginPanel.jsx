import "./LoginPanel.css";
import { useState } from "react";
import { login } from "../../Services/Auth";
import FormInput from "../FormInput/FormInput";

const LoginPanel = ({ onLogin, onRegisterPanel }) => {
    const [showPassword, setShowPassword] = useState(false);
    const [error, setError] = useState(null);

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
            setError(errorText);
            return;
        }

        onLogin();
        setError(null);
    };

    return (
        <div className="login-panel" onClick={(e) => e.stopPropagation()}>
            <h2>Авторизация</h2>
            <form onSubmit={onLoginClick}>
                <FormInput
                    labelText={"Электронная почта"}
                    placeholderText={"Введите вашу почту"}
                    type={"text"}
                    name={"email"}
                />
                <FormInput
                    labelText={"Пароль"}
                    placeholderText={"Введите ваш пароль"}
                    type={showPassword ? "text" : "password"}
                    name={"password"}
                />
                <div className="form-group">
                    <label>Показать пароль</label>
                    <input
                        type="checkbox"
                        checked={showPassword}
                        onChange={() => setShowPassword(!showPassword)}
                    />
                </div>
                {error && (<p className="error-text">{error}</p>)}
                <button type="submit" className="btn">
                    Авторизоваться
                </button>
            </form>
            <p>
                Нет аккаунта?{" "}
                <span className="link" onClick={onRegisterPanel}>
                    Зарегистрироваться
                </span>
            </p>
        </div >
    );
}

export default LoginPanel;