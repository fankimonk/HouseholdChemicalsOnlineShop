import "./FormInput.css";

const FormInput = ({ labelText, placeholderText, type, name }) => {
    return (
        <div className="form-group">
            <label>{labelText}</label>
            <input
                type={type}
                placeholder={placeholderText}
                name={name}
                required
            />
        </div>
    );
}

export default FormInput;