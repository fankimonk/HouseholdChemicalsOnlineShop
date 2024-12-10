import ComboBox from "../../Form/ComboBox/ComboBox";
import Form from "../../Form/Form";
import FormInput from "../../Form/FormInput/FormInput";
import Overlay from "../../Overlay/Overlay";
import { useState } from "react";
import { createProduct } from "../../Services/Products";

const AddProductPanel = ({ header, submitButtonText, categories, brands, onAdd, onClose }) => {
    const [selectedCategoryId, setSelectedCategoryId] = useState(categories[0]);
    const [selectedBrandId, setSelectedBrandId] = useState(brands[0]);

    const onSelectedCategoryChange = (value) => {
        setSelectedCategoryId(value);
        console.log(value);
    };

    const onSelectedBrandChange = (value) => {
        setSelectedBrandId(value);
        console.log(value);
    }

    const onSendProductForm = async (e) => {
        e.preventDefault();

        const formData = new FormData(e.target);
        const price = formData.get("price");
        formData.set("price", price.replace(".", ","));
        const response = await createProduct(formData);
        if (response.ok) {
            await onAdd();
            onClose();
        }
    };

    return (
        <Overlay onClose={onClose}>
            <Form
                header={header}
                submitButtonText={submitButtonText}
                onSubmit={onSendProductForm}
            >
                <FormInput
                    labelText={"Название"}
                    placeholderText={"Введите название"}
                    type={"text"}
                    name={"name"}
                />
                <FormInput
                    labelText={"Описание"}
                    placeholderText={"Введите описание"}
                    type={"text"}
                    name={"description"}
                />
                <FormInput
                    labelText={"Иконка"}
                    type={"file"}
                    accept={"image/*"}
                    name={"image"}
                />
                <FormInput
                    labelText={"Цена"}
                    placeholderText={"Введите цену"}
                    type={"number"}
                    step={".01"}
                    name={"price"}
                />
                <FormInput
                    labelText={"Кол-во на складе"}
                    placeholderText={"Введите кол-во товаров на складе"}
                    type={"number"}
                    step={"1"}
                    name={"stockQuantity"}
                />
                <ComboBox
                    name={"categoryId"}
                    labelText={"Категория"}
                    items={categories}
                    onChange={onSelectedCategoryChange}
                    value={selectedCategoryId}
                />
                <ComboBox
                    name={"brandId"}
                    labelText={"Бренд"}
                    items={brands}
                    onChange={onSelectedBrandChange}
                    value={selectedBrandId}
                />
            </Form>
        </Overlay>
    );
}

export default AddProductPanel;