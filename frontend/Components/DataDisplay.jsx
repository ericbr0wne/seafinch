import React from "react";

const DataDisplay = ({ item }) => {
  const formattedDate = new Date(item.date).toLocaleString();
  
  return (
    <div className="data-display-container">
      <div className="data-card primary-data">
        <div className="data-item main-value">
          <span className="label">Current Speed</span>
          <span className="value">{item.value} {item.unit}</span>
        </div>
        <div className="data-row">
          <div className="data-item">
            <span className="label">Quality</span>
            <span className="value">{item.quality}</span>
          </div>
          <div className="data-item">
            <span className="label">Depth</span>
            <span className="value">{item.depth} m</span>
          </div>
        </div>
      </div>
      
      <div className="data-card station-info">
        <div className="data-item">
          <span className="label">Station</span>
          <span className="value">{item.stationName}</span>
        </div>
        <div className="data-item">
          <span className="label">Position</span>
          <span className="value">{item.position}</span>
        </div>
        <div className="data-item">
          <span className="label">Time</span>
          <span className="value">{formattedDate}</span>
        </div>
      </div>
    </div>
  );
};

export default DataDisplay;