import './App.css';
import React from "react";
import { AddEmployee } from './components/AddEmployee'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import NavBar from './components/Navbar';

import EmployeeList from './components/EmployeeList';
import { Login } from './components/Login';
import { ProtectedRoute } from './components/ProtectedRoute';
import { UpdateEmployee } from './components/UpdateEmployee';
import { PageNotFound } from './components/PageNotFound';
import { useSelector } from 'react-redux';



function App() {

  const isLoaded = useSelector((state => state.isLoaded));

  return (
    <Router>
      <div>
        <NavBar />
        <div className='App'>
          <Routes>
            <Route path='/login' element={<Login />}></Route>
            {isLoaded &&
              <>
                <Route element={<ProtectedRoute />}>
                  <Route exact path='/' element={<EmployeeList />}>
                  </Route>
                  <Route exact path='/register' element={<AddEmployee />}>
                  </Route>
                  <Route exact path='update/:id' element={<UpdateEmployee />}></Route>
                </Route>
                <Route path='/*' element={<PageNotFound />}></Route>
              </>
            }
            <Route path='/' element={<Login />}></Route>
          </Routes>
        </div>
      </div>
    </Router>

  )
}



export default App;
