import './App.css';
import React, { useState } from 'react';
function App() {

  return (
    <div className="App">
      <Counter/>
    </div>
  );
}

function Button({title,onClick,disabled})
{
  return (<button onClick={onClick} disabled = {disabled}>{title}</button>);
}

function Counter()
{
  const [num,setState] = useState(0);


  function increment()
  {
    setState(num+1);
  }
  function reset()
  {
    setState(0);
  }
  return (<div className = "counter">
    <a className="number">{num}</a><br/>
    <div>
      <Button title = "inc" onClick={increment} disabled={num>=5}/>
        <Button title = "reset" onClick = {reset} disabled={num ===0}/>
    </div>
  </div>
  );
}

export default App;
