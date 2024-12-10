import "./Overlay.css";

const Overlay = ({ onClose, children }) => {
    return (
        <div className="overlay" onClick={onClose}>
            {children}
        </div>
    );
}

export default Overlay;