import React, { useState, useEffect, useMemo } from "react";
import FishSVG from "../Components/FishSVG"; 

const FishAnimation = ({ currentSpeed }) => {
    const [animationSpeed, setAnimationSpeed] = useState(10); 

    useEffect(() => {
        setAnimationSpeed(currentSpeed ? 100 / currentSpeed : 10);
    }, [currentSpeed]);

    const fishData = useMemo(() => {
        const fish = [];
        for (let i = 0; i < 10; i++) {
            fish.push({
                id: i,
                topPosition: Math.random() * 80 + 10, // Random between 10% and 90%
                delay: (i * 2) + Math.random() * 3, // Stagger starts every 2-5 seconds
                scale: Math.random() * 0.8 + 0.4, // Random scale between 0.4 and 1.2
                speedVariation: Math.random() * 0.6 + 0.7, // Random speed multiplier between 0.7 and 1.3
            });
        }
        return fish;
    }, []);

    return (
        <>
            {fishData.map((fish) => (
                <div
                    key={fish.id}
                    className="fish-container"
                    style={{
                        top: `${fish.topPosition}%`,
                        "--animation-speed": `${animationSpeed * fish.speedVariation}s`,
                        animationDelay: `${fish.delay}s`,
                        transform: `scale(${fish.scale})`
                    }}
                >
                    <FishSVG />
                </div>
            ))}
        </>
    );
};

export default FishAnimation;