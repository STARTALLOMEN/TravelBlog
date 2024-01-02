import React, { useState, useEffect, useRef } from 'react'
import Search from '../../Components/Forms/Search/Search'
import HomeSearch from '../../Components/HomeSearch/HomeSearch'
import Navbar from '../../Components/Navbar/Navbar'
import Popular from '../../Components/Popular/Popular'
import AccomodationRestaurant from '../../Components/AccomodationRestaurant/AccomodationRestaurant'
import About from '../../Components/About/About'
import Blog from '../../Components/Blog/Blog'
import Footer from '../../Components/Footer/Footer'
import QuestionHome from '../../Components/QuestionHome/QuestionHome'
import './home.scss'
import Login from '../../Components/Forms/Login/Login'
import Register from '../../Components/Forms/Register/Register'
const Home = () => {
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
    <>
      <Navbar openLogin={handleLogin} openRegister={handleRegister} openSearchForm={toggleForm} />
      <>
        {openLogin ? <Login btnClose={handleLogin} /> : ''}
        {openRegister ? <Register btnClose={handleRegister} /> : ''}
      </>
      <HomeSearch openSearchForm={toggleForm} />
      {openSearchForm && (
        <Search toggleOutsideForm={toggleForm} />
      )}
      <Popular />
      <AccomodationRestaurant />
      <About />
      <Blog />
      <QuestionHome />
      <Footer />
    </>
  )
}

export default Home