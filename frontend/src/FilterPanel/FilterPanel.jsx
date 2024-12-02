import "./FilterPanel.css";
import CategoryCheckbox from "./CategoryCheckbox";
import { useState, useEffect } from 'react'
import { getAllCategories } from '../Services/Categories'
import { getAllBrands } from '../Services/Brands'
import BrandCheckbox from "./BrandCheckbox";

const FilterPanel = ({ onCategoryChange, onBrandChange }) => {
    const [categories, setCategories] = useState([]);
    const [categoriesLoading, setCategoriesLoading] = useState(true);

    const [brands, setBrands] = useState([]);
    const [brandsLoading, setBrandsLoading] = useState(true);

    useEffect(() => {
        const getCategories = async () => {
            setCategoriesLoading(true);
            const response = await getAllCategories();
            setCategories(response);
            setCategoriesLoading(false);
        }

        getCategories();
    }, []);

    useEffect(() => {
        const getBrands = async () => {
            setBrandsLoading(true);
            const response = await getAllBrands();
            setBrands(response);
            setBrandsLoading(false);
        }

        getBrands();
    }, []);

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
