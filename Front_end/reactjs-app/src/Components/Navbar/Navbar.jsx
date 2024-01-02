import React, { useState, useEffect } from 'react'
import { SiYourtraveldottv } from 'react-icons/si'
import { AiFillCloseCircle, AiTwotoneHome } from 'react-icons/ai'
import { GoSearch } from 'react-icons/go'
import { TbGridDots } from 'react-icons/tb'
import { BsPencilFill, BsBellFill } from 'react-icons/bs'

import "./navbar.scss"
import { Link, useNavigate } from "react-router-dom";
import jwt from 'jwt-decode';


function Navbar(props) {
    const [active, setActive] = useState('navBar')
    const showNav = () => {
        setActive('navBar activeNavbar')
    }
    const removeNav = () => {
        setActive('navBar')
    }
    const [transition, setTransition] = useState('header')
    const addBgHeader = () => {
        if (window.scrollY >= 10) {
            setTransition('header activeHeader')
            console.log('add')
        }
        else {
            setTransition('header')
            console.log('no')
        }
    }
    window.addEventListener('scroll', addBgHeader)

    //
    const [isLogin, setIsLogin] = useState(false);
    const [userToken, setUserToken] = useState(localStorage.getItem('userToken') || null)
    const [name, setName] = useState('')
    const [avatar, setAvatar] = useState('')


    useEffect(() => {
        try{
            let token = localStorage.getItem('userToken')
            if (token !== null) {
                setUserToken(token)
                const user = jwt(userToken)
                setName(user.family_name)
                setAvatar(user.given_name)
                setIsLogin(true);
            }
            else {
                setUserToken(null)
                setIsLogin(false);
            }
        }
        catch{
            console.log("abc")
        }
    }, [userToken, isLogin]);

    const navigate = useNavigate();
    const handleLogout = () => {
        if (userToken !== null) {
            localStorage.removeItem('userToken');
        }
        setIsLogin(false)
        navigate('/');
    }
    const [showAccountBlock, setShowAccoutBlock] = useState(false)
    function handleOpenAccount(e) {
        setShowAccoutBlock(!showAccountBlock);
    }


    return (
        <section className='navBarSection'>
            <div className={transition}>
                <div className="logo_Search flex">
                    <div className="logoDiv">
                        <Link to="/" className="logo">
                            <h1><SiYourtraveldottv className="icon"></SiYourtraveldottv>
                                Gody
                            </h1>
                        </Link>
                    </div>
                    <div className="btnSearch">
                        <button className="search" onClick={props.openSearchForm} >
                            <p>Bạn muốn đi đâu</p>
                            <div className="iconSearch">
                                <GoSearch className="icon"></GoSearch>
                            </div>
                        </button>
                    </div>
                </div>

                <div className={active}>
                    <ul className="navList flex">
                        <li className="navItem">
                            <Link to="/" className="navLink">
                                <AiTwotoneHome className="iconNav" />
                                Trang chủ
                            </Link>
                        </li>
                        {/* <li className="navItem">
                            <Link to="/" className="navLink">
                                <BiWorld />
                                Điểm đến
                            </Link>
                        </li> */}
                        <li className="navItem havSub">
                            <Link to="/" className="navLink">
                                <BsPencilFill className="iconNav" />
                                Viết ngay
                            </Link>
                            <ul className="subNavItem" >
                                {/* <li><Link to="/" className="navLink">Viết Review</Link></li> */}
                                <li><Link to="/blog/viet-bai/note" className="navLink">
                                    Viết Blog chia sẻ trải nghiệm
                                </Link>
                                </li>
                                <li><Link to="/hoi-dap" className="navLink">Hỏi đáp du lịch</Link></li>
                                <li><Link to="/photo-blog/dang-bai/note" className="navLink">Chia sẻ hình ảnh</Link></li>
                                <li><Link to="/" className="navLink">Tạo lập lịch trình</Link></li>
                                {/* <li><Link to="/" className="navLink">Đánh dấu điểm đến</Link></li> */}
                                <li><Link to="/cong-tac-vien/viet-bai/note" className="navLink">Chia sẻ, giới thiệu địa điểm mới</Link></li>
                                {/* <li><Link to="/" className="navLink">Thêm dịch vụ mới</Link></li> */}
                            </ul>
                        </li>
                        <li className="navItem">
                            <Link to="/" className="navLink">
                                <BsBellFill className="iconNav" />
                                Thông báo
                            </Link>
                        </li>

                        <div className="headerBtns flex">
                            {
                                isLogin ? <li>
                                    <button onClick={handleOpenAccount} className='btnImgAvt'>
                                        <img src={avatar} alt=""
                                            className='img_avt' />
                                        {name}
                                    </button>
                                    {/* <select onChange={props.onChange} */}
                                    {showAccountBlock ? <div className="user__account">
                                        <ul className="user__account-list">
                                            <li><Link to="/profile">Trang cá nhân</Link></li>
                                            <li><Link to="/danh-dau-diem-den">Đánh dấu điểm đến</Link></li>
                                            <li><Link to="/myCars">Tài khoản</Link></li>
                                            <li><button onClick={props.openChangePw}>Đổi mật khẩu</button></li>
                                            <li><button onClick={handleLogout}>Đăng xuất</button></li>
                                        </ul>
                                    </div> : ''}
                                </li> : <><li>
                                    <button onClick={props.openLogin} className="btn loginBtn">Đăng nhập</button>
                                </li>
                                    <li>
                                        <button onClick={props.openRegister} className="btn">Đăng ký</button>
                                    </li></>
                            }
                        </div>

                    </ul>
                    <div onClick={removeNav}
                        className="closeNavbar">
                        <AiFillCloseCircle className="icon"></AiFillCloseCircle>
                    </div>
                </div>

                <div onClick={showNav}
                    className="toggleNavbar">
                    <TbGridDots className="icon"></TbGridDots>
                </div>
            </div>
        </section>
    )
}

export default Navbar

