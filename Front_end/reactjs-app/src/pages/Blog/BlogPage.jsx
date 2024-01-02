import React from 'react'
import './blogPage.scss'
import Navbar from '../../Components/Navbar/Navbar'
import BlogHeader from '../../Components/LayoutBlog/BlogHeader/BlogHeader '
import { useState, useRef } from 'react';
import BlogInfo from '../../Components/LayoutBlog/BlogInfo/BlogInfo';
import Footer from '../../Components/Footer/Footer'
import Login from '../../Components/Forms/Login/Login'
import Register from '../../Components/Forms/Register/Register'
import Search from '../../Components/Forms/Search/Search';

function BlogPage() {
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

  const [photo, setPhoto] = useState(null);
  const [title, setTitle] = useState("");

  return (
    <div className="blogPage">
      <Navbar openLogin={handleLogin} openRegister={handleRegister} openSearchForm={toggleForm} />
      <>
        {openLogin ? <Login btnClose={handleLogin} /> : ''}
        {openRegister ? <Register btnClose={handleRegister} /> : ''}
      </>
      {openSearchForm && (
        <Search toggleOutsideForm={toggleForm} />
      )}
      <BlogHeader placeholder="Tên tiêu đề" onCoverPhotoChange={setPhoto} onTitleChange={setTitle} />
      <BlogInfo photo={photo} title={title} />
      <Footer />
    </div>
  )
}

export default BlogPage