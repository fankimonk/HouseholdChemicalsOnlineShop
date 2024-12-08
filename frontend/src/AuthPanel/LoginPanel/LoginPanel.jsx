import "./LoginPanel.css";
import { useState } from "react";
import FormInput from "../FormInput/FormInput";

const LoginPanel = ({ onLogin, onRegisterPanel, error }) => {
    const [showPassword, setShowPassword] = useState(false);

    return (
        <div className="login-panel" onClick={(e) => e.stopPropagation()}>
            <h2>Авторизация</h2>
            <form onSubmit={onLogin}>
                <FormInput
                    labelText={"Электронная почта"}
                    placeholderText={"Введите вашу почту"}
                    type={"email"}
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