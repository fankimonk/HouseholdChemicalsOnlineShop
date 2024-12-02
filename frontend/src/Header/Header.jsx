import "./Header.css";
import LoginButton from "./LoginButton/LoginButton"
import RegisterButton from "./RegisterButton/RegisterButton";

const Header = ({ user, onLogout, onLoginClick, onRegisterClick }) => {
    return (
        <header className="header">
            <div className="left-section">
                <input
                    type="text"
                    placeholder="Поиск..."
                    className="search-input"
                />
                <button className="button">Поиск</button>
            </div>
            {user ? (
                <div className="right-section">
                    <p className="username">{user.userName}</p>
                    <button className="button">Корзина</button>
                    <button className="button" onClick={onLogout}>Выйти</button>
                </div>
            ) : (
                <div className="right-section">
                    <LoginButton onClick={onLoginClick} />
                    <RegisterButton onClick={onRegisterClick} />
                </div>
            )}
        </header>
    );
};

export default Header;
