import React, { useState, useEffect } from "react";
import FishSVG from "../Components/FishSVG"; 

const FishAnimation = ({ currentSpeed }) => {
    const [animationSpeed, setAnimationSpeed] = useState(10); 

    useEffect(() => {
        setAnimationSpeed(currentSpeed ? 100 / currentSpeed : 10);
    }, [currentSpeed]);

    console.log("Current animation speed:", animationSpeed);

    return (
        <div
            className="fish-container"
            style={{
                "--animation-speed": `${animationSpeed}s`, 
            }}
        >
            <FishSVG />
        </div>
    );
};

export default FishAnimation;