import "./FilterPanel.css";
import CategoryCheckbox from "./CategoryCheckbox";
import BrandCheckbox from "./BrandCheckbox";

const FilterPanel = ({ user, categories, brands, onCategoryChange, onBrandChange }) => {
    return (
        <aside className="filter-panel">
            <div className="filter-section">
                <div className="filter-header">
                    <h3 className="filter-title">Категории</h3>
                    {user && user.role == "Admin" && <button className="add-btn">
                        Добавить
                    </button>}
                </div>
                {categories.map((category) => (
                    <CategoryCheckbox
                        key={category.id}
                        category={category}
                        onCategoryChange={onCategoryChange}
                    />
                ))}
            </div>
            <div className="filter-section">
                <div className="filter-header">
                    <h3 className="filter-title">Бренды</h3>
                    {user && user.role == "Admin" && <button className="add-btn">
                        Добавить
                    </button>}
                </div>
                {brands.map((brand) => (
                    <BrandCheckbox
                        key={brand.id}
                        brand={brand}
                        onBrandChange={onBrandChange}
                    />
                ))}
            </div>
        </aside >
    );
};

export default FilterPanel;
