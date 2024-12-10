import "./Header.css";
import LoginButton from "./LoginButton/LoginButton"
import RegisterButton from "./RegisterButton/RegisterButton";
import SearchField from "./SearchField/SearchField";
import user_icon from "../assets/user_icon.svg";
import user_icon_admin from "../assets/user_icon_admin.svg"

const Header = ({ onSearch, user, onCartOpen, onLogout, onLoginClick, onRegisterClick }) => {
    return (
        <header className="header">
            <div className="left-section">
                <SearchField onSearch={onSearch} />
            </div>
            {user ? (
                <div className="right-section">
                    <img className="user-icon" src={user.role == "Admin" ? user_icon_admin : user_icon} alt="user_icon"></img>
                    <p className="username">{user.userName}</p>
                    <button className="button" onClick={onCartOpen}>Корзина</button>
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
