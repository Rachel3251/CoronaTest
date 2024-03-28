import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { addUser } from './apiService';
import { useNavigate } from 'react-router-dom';
import { deleteUser } from './apiService';
import { useParams } from 'react-router-dom';

const DeleteUser = () => {
    const navigate = useNavigate();
    const { ID } = useParams();
  
    useEffect(() => {
        const deleteUserAsync = async () => {
          try {
            await deleteUser(ID);
            console.log('User deleted successfully');
            alert('User deleted successfully');
            navigate('/');
          } catch (error) {
            console.error('Error deleting user:', error);
          }
        };
      
        deleteUserAsync();
      }, [ID, navigate]);
      
  
    return null; // או תצוגה ריקה, במקרה שלך אין צורך בתוכן
  };

export default DeleteUser;
