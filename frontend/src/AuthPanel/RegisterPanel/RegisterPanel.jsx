import FormElement from "../../Form/FormElement/FormElement";
import FormInput from "../../Form/FormInput/FormInput";
import "./RegisterPanel.css";
import { useState } from "react";

const RegisterPanel = ({ onLoginPanel, error }) => {
    const [showPassword, setShowPassword] = useState(false);

    return (
        <>
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
                Уже есть аккаунт?{" "}
                <span className="link" onClick={onLoginPanel}>
                    Войти
                </span>
            </p>
            {error && (
                <p className="error-text">{error}</p>
            )}
        </>
    );
}

export default RegisterPanel;