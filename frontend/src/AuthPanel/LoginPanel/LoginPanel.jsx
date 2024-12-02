import "./LoginPanel.css";
import { useState } from "react";

const LoginPanel = ({ onRegisterPanel }) => {
    const [showPassword, setShowPassword] = useState(false);

    return (
        <div className="login-panel" onClick={(e) => e.stopPropagation()}>
            <h2>Авторизация</h2>
            <form>
                <div className="form-group">
                    <label>Электронная почта</label>
                    <input type="email" placeholder="Введите вашу почту" required />
                </div>
                <div className="form-group">
                    <label>Пароль</label>
                    <input
                        type={showPassword ? "text" : "password"}
                        placeholder="Введите ваш пароль"
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Показать пароль</label>
                    <input
                        type="checkbox"
                        checked={showPassword}
                        onChange={() => setShowPassword(!showPassword)}
                    />
                </div>
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