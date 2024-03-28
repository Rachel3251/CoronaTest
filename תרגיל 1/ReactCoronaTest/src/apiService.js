import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';


const baseURL = 'https://localhost:7074/api';

export const getAllUsers = async () => {
    try {
        const response = await axios.get(`${baseURL}/User/getallusers`);
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.error('Error fetching users:', error);
        throw error;
    }
}

export const getUser = async (ID) => {
    try {
        debugger
        const response = await axios.get(`${baseURL}/user/getuserbyid/${ID}`);
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.error('Error fetching user:', error);
        throw error;
    }
}

export const addUser = async (user) => {
    try {
        console.log(user)
        const response = await axios.post(`${baseURL}/user/adduser/`,user);
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.error('Error adding user:', error);
        throw error;
    }
}

export const deleteUser = async (ID) => {
    try { 
        debugger;
        const response = await axios.post(`${baseURL}/user/delete/?userID=${ID}`);
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.error('Error deleting user:', error);
        throw error;
    }
}

export const updateUser = async (user) => {
    try {
        console.log(user)
        const response = await axios.post(`${baseURL}/user/update/`,user);
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.error('Error update user:', error);
        throw error;
    }
}

export const getVaccinations = async (userID) => {
    try {
        const response = await axios.get(`${baseURL}/vaccination/getvaccinationbyuserid/${userID}`);
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.error('Error fetching vaccinations:', error);
        throw error;
    }
}
export const getVaccination = async (vaccinationID) => {
    try {
        debugger
        const response = await axios.get(`${baseURL}/vaccination/getvaccinationbyid/${vaccinationID}`);
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.error('Error fetching vaccinations:', error);
        throw error;
    }
}

export const addVaccinations = async (vaccination) => {
    try {
        debugger
        const response = await axios.post(`${baseURL}/vaccination/add`,vaccination);
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.error('Error fetching vaccinations:', error);
        throw error;
    }
}

export const deleteVaccination = async (vaccinationID) => {
    try {
        debugger
        const response = await axios.delete(`${baseURL}/vaccination/delete/${vaccinationID}`);
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.error('Error fetching vaccinations:', error);
        throw error;
    }
}

export const updateVaccination = async (vaccination) => {
    try {
        debugger
        const response = await axios.post(`${baseURL}/vaccination/update`,vaccination);
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.error('Error updating vaccinations:', error);
        throw error;
    }
}