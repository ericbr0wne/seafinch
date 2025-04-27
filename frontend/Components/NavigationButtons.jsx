import React from "react";

const NavigationButtons = ({ nextItem, previousItem, currentIndex, dataLength }) => {
  return (
    <div 
      className="navigation-buttons" 
      style={{ 
        display: "flex", 
        justifyContent: "center", 
        width: "100%", 
        margin: "0 auto" 
      }}
    >
      <button onClick={previousItem} disabled={currentIndex === 0}>
        Previous
      </button>
      <button onClick={nextItem} disabled={currentIndex === dataLength - 1}>
        Next
      </button>
    </div>
  );
};

export default NavigationButtons;