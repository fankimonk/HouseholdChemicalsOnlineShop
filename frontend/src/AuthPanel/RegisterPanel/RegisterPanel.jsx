import "./RegisterPanel.css";

const RegisterPanel = ({ onLoginPanel }) => {
    return (
        <div className="register-panel" onClick={(e) => e.stopPropagation()}>
            <h2>Регистрация</h2>
            <form>
                <div className="form-group">
                    <label>Имя пользователя</label>
                    <input type="text" placeholder="Введите ваше имя" required />
                </div>
                <div className="form-group">
                    <label>Электронная почта</label>
                    <input type="email" placeholder="Введите вашу почту" required />
                </div>
                <div className="form-group">
                    <label>Пароль</label>
                    <input type="password" placeholder="Введите ваш пароль" required />
                </div>
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