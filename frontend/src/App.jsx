import React, { useState, useEffect } from "react";
import FishAnimation from "../Components/FishAnimation";
import useSmhiData from "../Components/useSmhiData";
import DataDisplay from "../Components/DataDisplay";
import NavigationButtons from "../Components/NavigationButtons";
import "./App.css";

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
    <h1>SeaFinch</h1>
    <h2>Real-time Ocean Data</h2>
    <p>This data comes from SMHI's open API, showing real-time ocean current measurements from monitoring station in the Baltic Sea.</p>
    <p>Each hour contains measurements at depths from 1m to 12m.</p>
    <p>Use the navigation buttons to browse through the data.</p>
    <div className="infobox">
    <FishAnimation currentSpeed={currentItem.value} />
    <DataDisplay item={currentItem} />
    <NavigationButtons
    nextItem={nextItem}
    previousItem={previousItem}
    currentIndex={currentIndex}
    dataLength={data.length}
    />
    </div>
</div>
);
};

export default SmhiData;
