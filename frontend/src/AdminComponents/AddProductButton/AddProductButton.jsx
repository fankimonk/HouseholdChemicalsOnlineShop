import React from 'react';
import './AddProductButton.css';

const AddProductButton = ({ onClick }) => {
    return (
        <button className="add-product-button" onClick={onClick}>
            + Добавить
        </button>
    );
};

export default AddProductButton;
