import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import { getUser, deleteUser } from './apiService';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import './UserDetails.css';

const UserDetails = () => {
  const navigate = useNavigate();
  const [user, setUser] = useState(null);
  const { ID } = useParams();
  const [loading, setLoading] = useState(false);
  const [wasSick, setWasSick] = useState(false);

  //שליפת משתמש לפי ID
  useEffect(() => {
    const fetchUser = async () => {
      setLoading(false);
      try {
        const data = await getUser(ID);
        setUser(data);
      } catch (error) {
        console.error('Error fetching user details:', error);
      } finally {
        setLoading(false);
      }
    }
    fetchUser();
  });

  //מחיקת משתמש לפי ID
  const handleDelete = async () => {
    try {
      await deleteUser(ID);
      console.log('User deleted successfully');
      alert('User deleted successfully');
      navigate('/');
    } catch (error) {
      console.error('Error deleting user:', error);
    }
  };

  return (
    <div className="user-details-container">
      {loading ? (
        <div>Loading...</div>
      ) : user ? (
        <div>
          <h2 className="user-details-title">{user.firstName} {user.lastName}</h2>
          <p>TZ: {user.id}</p>
          <p>Birth Date {new Date(user.dateOfBirth).toLocaleDateString()}</p>
          <p>Address: {user.addressStreet} {user.addressNumber} {user.addressCity}</p>
          <p>Phone: {user.phone}</p>
          <p>Mobile Phone: {user.mobilePhone}</p>
          <div>
            {user.recoveryDate!=null&&(<p>Recovery Date: {new Date(user.recoveryDate).toLocaleDateString()}</p>)}
          </div>
          <div>
          {user.recoveryDate!=null&&( <p>Positive Response Date: {new Date(user.positiveResultDate).toLocaleDateString()}</p>)}
          </div>
          <br />
          <Link to={`/uservaccinations/${user.userID}`} className="user-button">all vaccination</Link>
          <br />
          <Link to={`/updateuser/${user.id}`} className="user-button">update user</Link>
          <br />
          <button onClick={() => handleDelete(user.userID)} id="user-button-delete">delete user</button>
        </div>
      ) : (
        <div>User not found</div>
      )}
    </div>
  );
};

export default UserDetails;
