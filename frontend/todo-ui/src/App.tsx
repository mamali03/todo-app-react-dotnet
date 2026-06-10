import { useEffect, useState } from "react";

function App()
{
  const API_BASE_URL = "https://fluffy-goggles-q7wr4qwjxpp2wq7-5054.app.github.dev";
  const [data, setData] = useState<any[]>([]);

  useEffect(() => {
    fetch(`${API_BASE_URL}/weatherforecast`)
      .then((res) => res.json())
      //.then(setData);
      .then((data) => {
          console.log(data);
          setData(data);
      });
  }, []);

  return(
    <div>
      <h1>Weather Forecast</h1>
      <pre>{JSON.stringify(data, null, 2)}</pre>
    </div>
  )
}

export default App