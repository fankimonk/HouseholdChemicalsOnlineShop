import "./FilterPanel.css";
import CategoryCheckbox from "./CategoryCheckbox";
import BrandCheckbox from "./BrandCheckbox";

const FilterPanel = ({ categories, brands, onCategoryChange, onBrandChange }) => {
    return (
        <aside className="filter-panel">
            <div className="filter-section">
                <h3 className="filter-title">Категории</h3>
                {categories.map((category) => (
                    <CategoryCheckbox
                        key={category.id}
                        category={category}
                        onCategoryChange={onCategoryChange}
                    />
                ))}
            </div>
            <div className="filter-section">
                <h3 className="filter-title">Бренды</h3>
                {brands.map((brand) => (
                    <BrandCheckbox
                        key={brand.id}
                        brand={brand}
                        onBrandChange={onBrandChange}
                    />
                ))}
            </div>
        </aside>
    );
};

export default FilterPanel;
