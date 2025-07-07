import React, { useState, useEffect } from "react";
import FishAnimation from "../Components/FishAnimation";
import useSmhiData from "../Components/useSmhiData";
import DataDisplay from "../Components/DataDisplay";
import NavigationButtons from "../Components/NavigationButtons";

const SmhiData = () => {
  const { data, error } = useSmhiData();
  const [currentIndex, setCurrentIndex] = useState(0);

  useEffect(() => {
    console.log("Current speed value:", data[currentIndex]?.value);
  }, [data, currentIndex]);

  const nextItem = () => {
    if (currentIndex < data.length - 1) {
      setCurrentIndex(currentIndex + 1);
    }
  };

  const previousItem = () => {
    if (currentIndex > 0) {
      setCurrentIndex(currentIndex - 1);
    }
  };

  if (error) {
    return <p>Error loading data: {error}</p>;
  }

  if (!data || data.length === 0) {
    return <p>Loading data...</p>;
  }

  const currentItem = data[currentIndex];

return (
  <div>
  <>
  <h1>Seafinch</h1>
  <h2>Real-time Ocean Current</h2>
</>
    <FishAnimation currentSpeed={currentItem.value} />
    <DataDisplay item={currentItem} />
    <NavigationButtons
      nextItem={nextItem}
      previousItem={previousItem}
      currentIndex={currentIndex}
      dataLength={data.length}
    />
  </div>
);
};

export default SmhiData;
