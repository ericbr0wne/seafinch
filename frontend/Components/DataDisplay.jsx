// DataDisplay.jsx
import React from "react";

const DataDisplay = ({ item }) => {
  return (
    <div>
      <p>{item.name}</p>
      <p>{item.value} {item.unit}</p>
      <p>{item.stationName}</p>
      <p>{item.position}</p>
      <p>{item.date}</p>
    </div>
  );
};

export default DataDisplay;
