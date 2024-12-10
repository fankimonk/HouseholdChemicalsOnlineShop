import "./Form.css";
import FormSubmitButton from "./FormSubmitButton/FormSubmitButton";

const Form = ({ header, submitButtonText, onSubmit, children }) => {
    return (
        <div
            className="form"
            onClick={(e) => e.stopPropagation()}
        >
            <h2>{header}</h2>
            <form onSubmit={onSubmit}>
                {children}
                <FormSubmitButton text={submitButtonText} />
            </form>
        </div >
    );
}

export default Form;