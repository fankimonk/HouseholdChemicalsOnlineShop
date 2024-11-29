import "./Header.css";

const Header = () => {
    return (
        <header className="header">
            <div className="left-section">
                <button className="button">Главная</button>
            </div>
            <div className="center-section">
                <input
                    type="text"
                    placeholder="Поиск..."
                    className="search-input"
                />
                <button className="search-button">Поиск</button>
            </div>
            <div className="right-section">
                <button className="button">Вход</button>
                <button className="button">Регистрация</button>
            </div>
        </header>
    );
};

export default Header;
