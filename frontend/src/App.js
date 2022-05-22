import logo from './logo.svg';
import './App.css';
import {Cities} from './Cities.js';
import {Regions} from './Regions.js';
import {BrowserRouter, Route, Routes, NavLink} from 'react-router-dom'

function App() {
  return (
    <BrowserRouter>
    <div className="App">
      <nav className='navbar navbar-expand-lg navbar-dark bg-dark'>
      <a className="navbar-brand bg-dark ms-2" href="#">University Shedule</a>
        <ul className='navbar-nav'>
          <li className='nav-item m-1'>
            <NavLink className='btn btn-dark' to='/regions'>
              Regions
            </NavLink>
          </li>
          <li className='nav-item m-1'>
            <NavLink className='btn btn-dark' to='/cities'>
              Cities
            </NavLink>
          </li>
        </ul>
      </nav>

      <Routes>
        <Route path='/regions' element={<Regions/>}/>
        <Route path='/cities' element={<Cities/>}/>
      </Routes>
    </div>
    </BrowserRouter>
  );
}

export default App;
