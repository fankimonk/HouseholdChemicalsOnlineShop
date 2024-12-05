import "./SearchField.css"
import { useRef } from "react";

const SearchField = ({ onSearch }) => {
    const inputRef = useRef(null);

    const onSearchClick = () => {
        const searchQuery = inputRef.current.value;
        console.log(searchQuery, "search");
        onSearch(searchQuery);
    };

    return (
        <div className="search-field">
            <input
                type="text"
                placeholder="Поиск..."
                className="search-input"
                ref={inputRef}
            />
            <button className="search-button" onClick={onSearchClick}>Поиск</button>
        </div>
    );
}

export default SearchField;