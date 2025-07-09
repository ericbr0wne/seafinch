import React from "react";

const DataDisplay = ({ item }) => {
  const formattedDate = new Date(item.date).toLocaleString();
  
  return (
    <div>
      <p>Current speed: {item.value} {item.unit}</p>
      <p>Quality: {item.quality}</p>
      <p>Depth: {item.depth} m</p>
      <p>{item.stationName}</p>
      <p>{item.position}</p>
      <p>{formattedDate}</p>
    </div>
  );
};

export default DataDisplay;