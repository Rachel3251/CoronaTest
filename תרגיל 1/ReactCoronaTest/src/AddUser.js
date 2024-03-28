import React, { useState } from 'react';
import axios from 'axios';
import { addUser } from './apiService';
import { useNavigate } from 'react-router-dom';
import './AddUser.css';

const AddUser = () => {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    ID:'',
    FirstName: '',
    LastName: '',
    addressCity: '',
    AddressStreet: '',
    AddressNumber: '',
    DateOfBirth:null,
    Phone: '',
    MobilePhone: '',
    PositiveResultDate:null,
    RecoveryDate:null
  });

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  //הוספת משתמש
  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await addUser(formData);
      console.log('User added successfully');
      alert('User added successfully'); 
      navigate('/')
    } catch (error) {
      console.error('Error adding user:', error);
    }
  };

  return (
    <div>
   <div className="user-form-container">
  <h1 className="users-list-h1">Add User</h1>
  <form onSubmit={handleSubmit} className="user-form">
    <label className="user-form-label">
      TZ:
      <input
        type="text"
        name="ID"
        value={formData.ID}
        onChange={handleChange}
        className="user-form-input"
        pattern=".{9}" 
        required
      />
    </label>
    <br />
    <label className="user-form-label">
      First Name:
      <input
        type="text"
        name="FirstName"
        value={formData.FirstName}
        onChange={handleChange}
        className="user-form-input"
        required
      />
    </label>
    <br />
    <label className="user-form-label">
      Last Name:
      <input
        type="text"
        name="LastName"
        value={formData.LastName}
        onChange={handleChange}
        className="user-form-input"
        required
      />
    </label>
    <br />
    <label className="user-form-label">
      City:
      <input
        type="text"
        name="AddressCity"
        value={formData.AddressCity}
        onChange={handleChange}
        className="user-form-input"
        required
      />
    </label>
    <br />
    <label className="user-form-label">
      Street:
      <input
        type="text"
        name="AddressStreet"
        value={formData.AddressStreet}
        onChange={handleChange}
        className="user-form-input"
        required
      />
    </label>
    <br />
    <label className="user-form-label">
      st. number:
      <input
        type="text"
        name="AddressNumber"
        value={formData.AddressNumber}
        onChange={handleChange}
        className="user-form-input"
        required
      />
    </label>
    <br />
    <label className="user-form-label">
      BirthDate:
      <input
        type="date"
        name="DateOfBirth"
        value={formData.DateOfBirth}
        onChange={handleChange}
        className="user-form-input"
        max={new Date().toISOString().split('T')[0]} 
        required
      />
    </label>
    <br />
    <label className="user-form-label">
      Phone:
      <input
        type="text"
        name="Phone"
        value={formData.Phone}
        onChange={handleChange}
        className="user-form-input"
        maxLength="10" 
        required 
      />
    </label>
    <br />
    <label className="user-form-label">
      mobile Phone:
      <input
        type="text"
        name="MobilePhone"
        value={formData.MobilePhone}
        onChange={handleChange}
        className="user-form-input"
        maxLength="10" 
        required 
      />
    </label>
    <label className="user-form-label">
    Positive Result Date:
      <input
        type="date"
        name="PositiveResultDate"
        value={formData.PositiveResultDate}
        onChange={handleChange}
        className="user-form-input"
        max={new Date().toISOString().split('T')[0]} 
   
      />
    </label>
    <label className="user-form-label">
    RecoveryDate:
      <input
        type="date"
        name="RecoveryDate"
        value={formData.RecoveryDate}
        onChange={handleChange}
        className="user-form-input"
        max={new Date().toISOString().split('T')[0]} 
  
      />
    </label>
    <br />
    <button type="submit" className="user-form-submit">Submit</button>
  </form>
</div>

    </div>
  );
};

export default AddUser;
