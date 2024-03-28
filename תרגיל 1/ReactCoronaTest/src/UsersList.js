import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { getAllUsers } from './apiService';
import './UsersList.css';

const UsersList = ({ users }) => {
    const [usersList, setUserslist] = useState([]);
    const [loading, setLoading] = useState(true);

    //שליפת כל המתשתמשים
    useEffect(() => {
        async function fetchUsers() {
            try {
                const data = await getAllUsers();
                setUserslist(data);
                setLoading(false);
            } catch (error) {
                console.error('Error fetching users:', error);
            }
        }
        fetchUsers();
    }, []);

    return (
        <div id="users-list-container">
            <h1 id="users-list-h1">Users List</h1>
            {loading ? (
                <div>
                    <h2 id="users-list-h2">Users list</h2>
                </div>
            ) : (
                <div id="users-list">
                    <ul>
                        {usersList.map(user => (
                            <li key={user.userID}>
                                <Link to={`/user/${user.id}`} id="user-link">
                                    {user.firstName} {user.lastName}
                                </Link>
                            </li>
                        ))}
                        <Link to="/adduser" id='user-link-add'>add user</Link >
                    </ul>
                </div>
            )}
        </div>
    );
};

export default UsersList;
