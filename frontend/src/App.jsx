import React, { useState, useEffect } from "react";
import FishSVG from "../Components/FishSVG";  // Import FishSVG correctly
import DataDisplay from "../Components/DataDisplay";
import NavigationButtons from "../Components/NavigationButtons";

const SmhiData = () => {
  const [data, setData] = useState([]);
  const [error, setError] = useState(null);
  const [currentIndex, setCurrentIndex] = useState(0); // State to keep track of the current item index

  useEffect(() => {
    fetch("http://localhost:5025/api/smhi/data")
      .then((response) => {
        if (!response.ok) {
          throw new Error("Error fetching data");
        }
        return response.json();
      })
      .then((data) => {
        setData(data);
      })
      .catch((error) => {
        setError(error.message);
      });
  }, []);

  // Logic to go to the next item
  const nextItem = () => {
    if (currentIndex < data.length - 1) {
      setCurrentIndex(currentIndex + 1);
    }
  };

  // Logic to go to the previous item
  const previousItem = () => {
    if (currentIndex > 0) {
      setCurrentIndex(currentIndex - 1);
    }
  };

  // If there is no data, display a loading message
  if (data.length === 0) {
    return <p>Loading data...</p>;
  }

  const item = data[currentIndex]; // Get the current item based on the current index

  return (
    <div>
      <h1>SMHI Data</h1>
      {error && <p>Error: {error}</p>} {/* Display error message if there's an error */}
      
      {/* Fish Animation */}
      <FishSVG currentSpeed={item.value} /> {/* Adjust fish speed based on sea current */}

      {/* Data Display */}
      <DataDisplay item={item} />

      {/* Navigation Buttons */}
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
