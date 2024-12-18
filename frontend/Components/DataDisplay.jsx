// DataDisplay.jsx
import React from "react";

const DataDisplay = ({ item }) => {
  return (
    <div>
      <p>{item.name}</p>
      <p>{item.value} {item.unit}</p>
      <p>Station: {item.stationName}</p>
      <p>Position: {item.position}</p>
      <p>Date: {item.date}</p>
    </div>
  );
};

export default DataDisplay;
