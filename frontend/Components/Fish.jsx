// Fish.jsx
import React from "react";
import './Fish.css'; // Ensure this file exists with your CSS

const Fish = ({ currentSpeed }) => {
  return (
    <div className="fish-container">
      {/* Animated Fish */}
      <div
        className="fish"
        style={{
          animationDuration: `${Math.max(1, 99 - currentSpeed)}s`, // Adjust speed based on sea current
        }}
      ></div>
    </div>
  );
};

export default Fish;
