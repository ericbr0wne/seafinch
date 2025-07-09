
const DataDisplay = ({ item }) => {
  const formattedDate = new Date(item.date).toLocaleString();
  
  return (
    <div className="data-display-card">
      <div className="current-speed">
        Current Speed: {item.value} {item.unit}
      </div>
      <p><span className="data-label">Quality:</span> <span className="data-value">{item.quality}</span></p>
      <p><span className="data-label">Depth:</span> <span className="data-value">{item.depth} m</span></p>
      <p><span className="data-label">Station:</span> <span className="data-value">{item.stationName}</span></p>
      <p><span className="data-label">Position:</span> <span className="data-value">{item.position}</span></p>
      <p><span className="data-label">Time:</span> <span className="data-value">{formattedDate}</span></p>
    </div>
  );
};