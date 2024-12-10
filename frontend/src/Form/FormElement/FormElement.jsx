import "./FormElement.css"

const FormElement = ({ labelText, children }) => {
    return (
        <div className="form-element">
            {labelText && <label className="label">{labelText}</label>}
            {children}
        </div>
    );
}

export default FormElement;