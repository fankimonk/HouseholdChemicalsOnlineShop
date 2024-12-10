import FormElement from "../FormElement/FormElement";
import "./ComboBox.css"

const ComboBox = ({ labelText, name, items, onChange, value }) => {
    return (
        <FormElement labelText={labelText}>
            <select
                name={name}
                value={value}
                onChange={(e) => onChange(e.target.value)}
                required
            >
                {items.map((item) => (
                    <option key={item.id} value={item.id}>
                        {item.name}
                    </option>
                ))}
            </select>
        </FormElement>
    );
}

export default ComboBox;