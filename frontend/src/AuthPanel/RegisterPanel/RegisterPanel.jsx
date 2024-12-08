import FormInput from "../FormInput/FormInput";
import "./RegisterPanel.css";
import { useState } from "react";

const RegisterPanel = ({ onRegister, onLoginPanel, error }) => {
    const [showPassword, setShowPassword] = useState(false);

    return (
        <div className="register-panel" onClick={(e) => e.stopPropagation()}>
            <h2>Регистрация</h2>
            <form onSubmit={onRegister}>
                <FormInput
                    labelText={"Имя пользователя"}
                    placeholderText={"Введите ваше имя"}
                    type={"text"}
                    name={"userName"}
                />
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
                    Зарегистрироваться
                </button>
            </form>
            <p>
                Уже есть аккаунт?{" "}
                <span className="link" onClick={onLoginPanel}>
                    Войти
                </span>
            </p>
        </div>
    );
}

export default RegisterPanel;