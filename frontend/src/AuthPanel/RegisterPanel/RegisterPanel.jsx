import { login, register } from "../../Services/Auth";
import FormInput from "../FormInput/FormInput";
import "./RegisterPanel.css";
import { useState } from "react";

const RegisterPanel = ({ onLogin, onLoginPanel }) => {
    const [showPassword, setShowPassword] = useState(false);
    const [error, setError] = useState(null);

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
            setError(errorText);
            return;
        }

        const loginResponse = await login({
            email: registerRequest.email,
            password: registerRequest.password
        });
        if (!loginResponse.ok) {
            const errorText = await loginResponse.text();
            setError(errorText);
            return;
        }

        onLogin();
        setError(null);
    };

    return (
        <div className="register-panel" onClick={(e) => e.stopPropagation()}>
            <h2>Регистрация</h2>
            <form onSubmit={onRegisterClick}>
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