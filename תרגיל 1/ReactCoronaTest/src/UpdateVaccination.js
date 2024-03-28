import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { getVaccination, updateVaccination } from './apiService';
import { useNavigate } from 'react-router-dom';
import './UpdateVaccination.css';
import { Link } from 'react-router-dom';

const UpdateVaccination = () => {
    const navigate = useNavigate();
    const { vaccinationID } = useParams();
    const [vaccination, setVaccination] = useState(null);
    const [vaccinationDate, setVaccinationDate] = useState('');
    const [vaccineManufacturer, setVaccineManufacturer] = useState('');

    //שליפת החיסון הנוכחי
    useEffect(() => {
        const fetchVaccination = async () => {
            try {
                const data = await getVaccination(vaccinationID);
                setVaccination(data[0]);
                setVaccinationDate(data[0].vaccinationDate);
                setVaccineManufacturer(data[0].vaccineManufacturer);
            } catch (error) {
                console.error('Error fetching vaccination:', error);
            }
        };
        fetchVaccination();
    }, [vaccinationID]);

    //עידכון החיסון 
    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const updatedVaccination = {
                ...vaccination,
                vaccinationDate: vaccinationDate,
                vaccineManufacturer: vaccineManufacturer
            };
            await updateVaccination(updatedVaccination);
            alert('Vaccination updated successfully');
            navigate(`/uservaccinations/${vaccination.userID}`)
        } catch (error) {
            console.error('Error updating vaccination:', error);
        }
    };

    return (
        <div className='update-vaccination-container'>
            <h2 className='update-vaccination-title'>Update Vaccination</h2>
            <form onSubmit={handleSubmit} className='update-vaccination-form'>
                <div>
                    <label htmlFor="vaccinationDate">Vaccination Date:</label>
                    <input type="date" id="vaccinationDate" value={vaccinationDate} onChange={(event) => setVaccinationDate(event.target.value)}max={new Date().toISOString().split('T')[0]}  />
                </div>
                <div>
                    <label htmlFor="vaccineManufacturer">Vaccine Manufacturer:</label>
                    <input type="text" id="vaccineManufacturer" value={vaccineManufacturer} onChange={(event) => setVaccineManufacturer(event.target.value)} />
                </div>
                <button type="submit">Update Vaccination</button>
            </form>
        </div>
    );
};

export default UpdateVaccination;
