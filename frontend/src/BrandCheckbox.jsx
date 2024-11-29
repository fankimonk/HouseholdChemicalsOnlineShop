
const BrandCheckbox = ({ brand }) => {
    const {
        id,
        name
    } = brand;

    return (
        <label>
            <input type="checkbox" /> {name}
        </label>
    );
}

export default BrandCheckbox;