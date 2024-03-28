import React, { useState } from 'react';
import { addVaccinations } from './apiService';
import { useNavigate } from 'react-router-dom';
import { useParams } from 'react-router-dom';
import './AddVaccination.css'

const AddVaccination = () => {
    const { userID } = useParams();
    const navigate = useNavigate();
    const [vaccinationDate, setVaccinationDate] = useState('');
    const [vaccineManufacturer, setVaccineManufacturer] = useState('');
    const [cnt,setCnt] = useState();

    //הוספת חיסון
    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const newVaccination = {
                userID: userID,
                vaccinationDate: vaccinationDate,
                vaccineManufacturer: vaccineManufacturer,
            };
            const response = await addVaccinations(newVaccination);
            //מספ החיסונים למשתמש
            setCnt(response.data);
            if (cnt>0)
                alert('Vaccination added successfully');
            console.log('Vaccination added successfully!');
            navigate(`/uservaccinations/${userID}`)
        } catch (error) {
            console.error('Error adding vaccination:', error);
        }
    };

    return (
       <div className='vaccination-form-container'>
        <form onSubmit={handleSubmit} className='vaccination-form'>
              <h1 className="vaccination-list-h1">Add Vaccination</h1>
              <br/>
            <div>
                <label htmlFor="vaccinationDate"className='vaccination-form-label'>date: </label>
                <input type="date" id="vaccinationDate" value={vaccinationDate} onChange={(event) => setVaccinationDate(event.target.value)} max={new Date().toISOString().split('T')[0]} className='vaccination-form-input'/>
            </div>
            <br/>
            <div>
                <label htmlFor="vaccinationManufacturer"  className='vaccination-form-label'> manufacturer: </label>
                <input type="text" id="vaccinationManufacturer" value={vaccineManufacturer} onChange={(event) => setVaccineManufacturer(event.target.value)}className='vaccination-form-input'/>
            </div>
            <br/>
            <button type="submit" className='vaccination-form-submit'>add vaccination</button>
        </form>
        </div>
    );
};

export default AddVaccination;
