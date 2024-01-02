import React, { useState, useEffect } from 'react';
import Login from '../../Components/Forms/Login/Login'
import Register from '../../Components/Forms/Register/Register'
import Navbar from '../../Components/Navbar/Navbar';
import Search from '../../Components/Forms/Search/Search';
import MarkDestination from '../MarkDestination/MarkDestination';
import Profile from '../Profile/Profile';
import './myTravelMap.scss'

function MyTravelMap() {
    const [openLogin, setopenLogin] = useState(false);
    const [openRegister, setopenRegister] = useState(false);
    const [openSearchForm, setopenSearchForm] = useState(false);

    const handleLogin = () => {
        setopenLogin(!openLogin);
    }
    const handleRegister = () => {
        setopenRegister(!openRegister);
    }
    const toggleForm = () => {
        setopenSearchForm(!openSearchForm);
    };
    return (

        <div className="mytravelmap">
            <Navbar openLogin={handleLogin} openRegister={handleRegister} openSearchForm={toggleForm} />
            <>
                {openLogin ? <Login btnClose={handleLogin} /> : ''}
                {openRegister ? <Register btnClose={handleRegister} /> : ''}
            </>
            {openSearchForm && (
                <Search toggleOutsideForm={toggleForm} />
            )}
            <div className="flex-start contentMytravel">
                <div className="proFileDiv">
                    <Profile />
                </div>
                <div className="proDiv">
                    <MarkDestination />
                </div>
            </div>
        </div>
    )
}

export default MyTravelMap