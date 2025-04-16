import React from 'react';
import logo from './logo.svg';
import './App.css';
import { useDispatch, useSelector } from 'react-redux';
import { decrement, increment, reset } from './redux/actionCreator';
import { DECREMENT, INCREMENT,RESET } from './redux/actions';

function App() {
  return (
    <div className='App'>
    <Counter/>
    </div>
  );
}

function Counter()
{
  const count = useSelector((state:any)=>state.count);
  const dispatch:any =
   useDispatch();

  return(
    <div className = "counter">
    <a className="number">{count}</a><br/>
    <div>
      <button onClick={()=>dispatch(increment())}>+1</button>
      <button onClick={()=>dispatch(decrement())}>-1</button>
      <button onClick={()=>dispatch(reset())}>Сбросить</button>

    </div>
  </div>
  )

}
export default App;
