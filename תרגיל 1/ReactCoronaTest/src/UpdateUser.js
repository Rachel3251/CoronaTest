import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';
import { updateUser, getUser } from './apiService';
import './UpdateUser.css';


const UpdateUser = () => {
    const [formData, setFormData] = useState({
        UserID:0,
        ID:'',
        FirstName: '',
        LastName: '',
        AddressCity: '',
        AddressStreet: '',
        AddressNumber: '',
        DateOfBirth: null,
        Phone: '',
        MobilePhone: '',
        PositiveResultDate:null,
        RecoveryDate:null
    });

    const { ID } = useParams();
    const navigate = useNavigate();

    //שליפת משתמש נוכחי
    useEffect(() => {
        const fetchUser = async () => {
            try {
                const response = await getUser(ID);
                setFormData(response);
            } catch (error) {
                console.error('Error fetching user:', error);
            }
        };
        fetchUser(); 
    }, [ID]);

    //עריכת המשתמש הנוכחי בנתונים החדשים
    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    //עידכון המשתמש
    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await updateUser(formData);           
            console.log('User updated successfully');
            navigate('/'); 
        } catch (error) {
            console.error('Error updating user:', error);
        }
    };

    return (
        <div className="form-container">
          <h1 className="form-title">Update User</h1>
          <form onSubmit={handleSubmit} className="user-form">
            <label>
              First Name:
              <input
                type="text"
                name="FirstName"
                value={formData.FirstName}
                onChange={handleChange}
                className="form-input"
              />
            </label>
            <br />
            <label>
              Last Name:
              <input
                type="text"
                name="LastName"
                value={formData.LastName}
                onChange={handleChange}
                className="form-input"
              />
            </label>
            <br />
            <label>
              BirthDate:
              <input
                type="date"
                name="DateOfBirth"
                value={formData.DateOfBirth}
                onChange={handleChange}
                className="form-input"
                max={new Date().toISOString().split('T')[0]} 
              />
            </label>
            <br />
            <label>
              City:
              <input
                type="text"
                name="AddressCity"
                value={formData.AddressCity}
                onChange={handleChange}
                className="form-input"
              />
            </label>
            <br />
            <label>
              Street:
              <input
                type="text"
                name="AddressStreet"
                value={formData.AddressStreet}
                onChange={handleChange}
                className="form-input"
              />
            </label>
            <br />
            <label>
              st. number:
              <input
                type="text"
                name="AddressNumber"
                value={formData.AddressNumber}
                onChange={handleChange}
                className="form-input"
              />
            </label>
            <br />
            <label>
              Phone:
              <input
                type="text"
                name="Phone"
                value={formData.Phone}
                onChange={handleChange}
                className="form-input"
                maxLength={10}
              />
            </label>
            <br />
            <label>
              Mobile Phone:
              <input
                type="text"
                name="MobilePhone"
                value={formData.MobilePhone}
                onChange={handleChange}
                className="form-input"
                maxLength={10}
              />
            </label>
            <label>
            PositiveResultDate:
              <input
                type="date"
                name="PositiveResultDate"
                value={formData.PositiveResultDate}
                onChange={handleChange}
                className="form-input"
                max={new Date().toISOString().split('T')[0]} 
              />
            </label>
            <label>
            RecoveryDate:
              <input
                type="date"
                name="RecoveryDate"
                value={formData.RecoveryDate}
                onChange={handleChange}
                className="form-input"
                max={new Date().toISOString().split('T')[0]} 
              />
            </label>
            <br />
            <button type="submit" className="form-button">Update</button>
          </form>
        </div>
      );
};

export default UpdateUser;
