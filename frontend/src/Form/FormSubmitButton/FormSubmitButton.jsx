import "./FormSubmitButton.css";

const FormSubmitButton = ({ text }) => {
    return (
        <button type="submit" className="btn">
            {text}
        </button>
    );
}

export default FormSubmitButton;