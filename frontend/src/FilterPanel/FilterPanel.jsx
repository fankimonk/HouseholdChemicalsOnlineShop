import "./FilterPanel.css";
import CategoryCheckbox from "../CategoryCheckbox/CategoryCheckbox";
import BrandCheckbox from "../BrandCheckbox/BrandCheckbox";

const FilterPanel = ({ categories, brands }) => {
    return (
        <aside className="filter-panel">
            <div className="filter-section">
                <h3 className="filter-title">Категории</h3>
                {categories.map((category) => (
                    <CategoryCheckbox
                        key={category.id}
                        category={category}
                    />
                ))}
            </div>
            <div className="filter-section">
                <h3 className="filter-title">Бренды</h3>
                {brands.map((brand) => (
                    <BrandCheckbox
                        key={brand.id}
                        brand={brand} />
                ))}
            </div>
        </aside>
    );
};

export default FilterPanel;
