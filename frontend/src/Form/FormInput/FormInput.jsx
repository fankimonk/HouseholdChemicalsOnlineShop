import FormElement from "../FormElement/FormElement";
import "./FormInput.css";

const FormInput = ({ labelText, placeholderText, type, name, defaultValue, step, accept }) => {
    return (
        <FormElement labelText={labelText}>
            <input
                className="input"
                type={type}
                placeholder={placeholderText || undefined}
                name={name}
                defaultValue={defaultValue || undefined}
                step={step || undefined}
                accept={accept || undefined}
                required
            />
        </FormElement>
    );
}

export default FormInput;