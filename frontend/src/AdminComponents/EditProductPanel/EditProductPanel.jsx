import ComboBox from "../../Form/ComboBox/ComboBox";
import Form from "../../Form/Form";
import FormInput from "../../Form/FormInput/FormInput";
import Overlay from "../../Overlay/Overlay";
import { useState } from "react";
import { updateProduct } from "../../Services/Products";

const EditProductPanel = ({ header, submitButtonText, categories, brands, product, onEdit, onClose }) => {
    const [selectedCategoryId, setSelectedCategoryId] = useState(product.categoryId);
    const [selectedBrandId, setSelectedBrandId] = useState(product.brandId);

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
        console.log(formData);
        console.log(product.id);
        const response = await updateProduct(product.id, formData);
        if (response.ok) {
            await onEdit();
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
                    defaultValue={product.name}
                />
                <FormInput
                    labelText={"Описание"}
                    placeholderText={"Введите описание"}
                    type={"text"}
                    name={"description"}
                    defaultValue={product.description}
                />
                <FormInput
                    labelText={"Цена"}
                    placeholderText={"Введите цену"}
                    type={"number"}
                    step={".01"}
                    name={"price"}
                    defaultValue={product.price}
                />
                <FormInput
                    labelText={"Кол-во на складе"}
                    placeholderText={"Введите кол-во товаров на складе"}
                    type={"number"}
                    step={"1"}
                    name={"stockQuantity"}
                    defaultValue={product.stockQuantity}
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

export default EditProductPanel;