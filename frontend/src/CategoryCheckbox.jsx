
const CategoryCheckbox = ({ category }) => {
    const {
        id,
        name
    } = category;

    return (
        <label>
            <input type="checkbox" /> {name}
        </label>
    );
}

export default CategoryCheckbox;