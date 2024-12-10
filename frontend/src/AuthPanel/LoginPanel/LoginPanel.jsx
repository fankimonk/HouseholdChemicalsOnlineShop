import "./LoginPanel.css";
import { useState } from "react";
import FormInput from "../../Form/FormInput/FormInput";
import FormElement from "../../Form/FormElement/FormElement";

const LoginPanel = ({ onRegisterPanel, error }) => {
    const [showPassword, setShowPassword] = useState(false);

    return (
        <>
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
            <FormElement>
                <div>
                    <label>Показать пароль</label>
                    <input
                        type="checkbox"
                        checked={showPassword}
                        onChange={() => setShowPassword(!showPassword)}
                    />
                </div>
            </FormElement>
            <p>
                Нет аккаунта?{" "}
                <span className="link" onClick={onRegisterPanel}>
                    Зарегистрироваться
                </span>
            </p>
            {error && (
                <p className="error-text">{error}</p>
            )}
        </>
    );
}

export default LoginPanel;