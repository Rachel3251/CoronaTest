import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { getVaccinations, deleteVaccination } from './apiService';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import './UserVaccinations.css';
import axios from 'axios';

const UserVaccinations = () => {
    const navigate = useNavigate();
    const [vaccinations, setVaccinations] = useState([]);
    const { userID } = useParams();

    //שליפת כל החיסונים לפי UserID
    useEffect(() => {
        const fetchVaccinations = async () => {
            try {
                const data = await getVaccinations(userID);
                debugger;
                setVaccinations(data);
            } catch (error) {
                console.error('Error fetching vaccinations:', error);
            }
        };
        fetchVaccinations();
    }, [userID]);

    //בדיקה האם מערך החיסונים ריק
    if (vaccinations.length === 0) {
        return (
            <div>
                <p className="user-vaccinations-title">No vaccinations available</p>
                <Link to={`/addvaccination/${userID}`} className="user-link">add vaccination</Link>
            </div>
        );
    }
    //מחיקת חיסון לפי vaccinationID
    const handleDelete = async (vaccinationID) => {
        try {
            debugger
            await deleteVaccination(vaccinationID);
            setVaccinations(vaccinations.filter(vaccination => vaccination.id !== vaccinationID));
            alert('vaccination deleted succesfully!');
            navigate('.', { replace: true });
        } catch (error) {
            console.error('Error deleting vaccination:', error);
        }
    };


    return (
        <div className="user-vaccinations-container">
            {vaccinations.map((vaccination, index) => (
                <div>
                    <div key={index}>
                        <h2 className="user-vaccinations-title">Vaccination {index + 1}</h2>
                        <ul className="user-vaccinations-list">
                            <li key={index} className="user-vaccination-item">
                                <div className="user-vaccination-details">
                                    <p><strong>date:</strong> {new Date(vaccination.vaccinationDate).toLocaleDateString()}</p>
                                    <p><strong>Manufacturer:</strong> {vaccination.vaccineManufacturer}</p>
                                </div>
                            </li>
                        </ul>
                    </div>
                    <Link to={`/updatevaccination/${vaccination.vaccinationID}`} className="user-link">update vaccination</Link>
                    <button onClick={() => handleDelete(vaccination.vaccinationID)} className="user-link" id="user-link-delete">delete vaccination</button>
                </div>
            ))}
            <Link to={`/addvaccination/${userID}`} id="user-link-add">add vaccination</Link>
        </div>
    );
};

export default UserVaccinations;
