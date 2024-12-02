import "./RegisterButton.css";

const RegisterButton = ({ onClick }) => {
    return (
        <button className="register-button" onClick={onClick}>Регистрация</button>
    );
}

export default RegisterButton;