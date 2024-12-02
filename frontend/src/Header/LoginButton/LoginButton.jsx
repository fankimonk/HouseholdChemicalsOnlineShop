import "./LoginButton.css";

const LoginButton = ({ onClick }) => {
    return (
        <button className="login-button" onClick={onClick}>Вход</button>
    );
}

export default LoginButton;