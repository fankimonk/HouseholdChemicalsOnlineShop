
const CategoryCheckbox = ({ category, onCategoryChange }) => {
    const { id, name } = category;

    const onChange = (e) => {
        onCategoryChange(id, e.target.checked);
    };

    return (
        <label>
            <input type="checkbox" onChange={onChange} /> {name}
        </label>
    );
}

export default CategoryCheckbox;