import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import UsersList from './UsersList';
import UserDetails from './UserDetails';
import NotFound from './NotFound';
import AddUser from './AddUser';
import axios from "axios"
import UpdateUser from './UpdateUser';
import UserVaccinations from './UserVaccinations';
import AddVaccination from './AddVaccination';
import UpdateVaccination from './UpdateVaccination';

const App = () => {
 
  return (
    <Router>
      <Routes>
        <Route path="/" element={<UsersList/>} />
        <Route path="/user/:ID" element={<UserDetails/>} />
        <Route path="*" element={<NotFound />} />
        <Route path="/adduser" element={<AddUser />} />
        <Route path="/updateuser/:ID" element={<UpdateUser />} />
        <Route path="/uservaccinations/:userID" element={<UserVaccinations  />} />
        <Route path="/addvaccination/:userID" element={< AddVaccination />} />
        <Route path="/updatevaccination/:vaccinationID" element={< UpdateVaccination />} />

      </Routes>
    </Router>
  );
};

export default App;