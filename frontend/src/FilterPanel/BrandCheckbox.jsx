
const BrandCheckbox = ({ brand, onBrandChange }) => {
    const { id, name } = brand;

    const onChange = (e) => {
        onBrandChange(id, e.target.checked);
    };

    return (
        <label>
            <input type="checkbox" onChange={onChange} /> {name}
        </label>
    );
}

export default BrandCheckbox;