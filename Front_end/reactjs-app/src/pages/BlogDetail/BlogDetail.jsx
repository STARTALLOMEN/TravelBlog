import React, { useState, useEffect } from 'react';
import Navbar from '../../Components/Navbar/Navbar'
import IntroduceDes from '../../Components/IntroduceDes/IntroduceDes';
import NavbarDetail from '../../Components/NavbarDetail/NavbarDetail';
import './blogDetail.scss'
import { Link } from "react-router-dom";
import { useParams, useLocation } from 'react-router-dom';
import { AiFillCaretRight } from 'react-icons/ai'
import request, { get } from '../../utils/request';
import Login from '../../Components/Forms/Login/Login'
import Register from '../../Components/Forms/Register/Register'
import Search from '../../Components/Forms/Search/Search';

function BlogDetail(props) {
    const params = useParams();
    const blogId = params.id;
    console.log("desId", blogId);

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

    const [data, setData] = useState([])
    useEffect(() => {
        const getData = async () => {
            try {
                const res = await get(`Blog/${blogId}/blogDetail`)
                setData(res)
                // const res = await get('Destination/popular')
                // setData([...res])
                // const url = `https://localhost:7101/api/Destination/popular`;
                // const res = await request.get(url)
                // setData([...res.data])
            }
            catch (error) {
                console.log("Erorr:", error)
            }

        }
        getData()
    }, [blogId])

    //desByProvince
    const [desByProvince, setDesByProvince] = useState([])
    useEffect(() => {
        const getData = async () => {
            try {
                const res = await get(`province/${data.provinceId}/destination`)
                setDesByProvince(res)
            }
            catch (error) {
                console.log("Erorr:", error)
            }

        }
        getData()
    }, [data.provinceId])

    //lấy des là Province
    const [desProvince, setDesProvince] = useState([])
    useEffect(() => {
        const getData = async () => {
            try {
                const res = await get(`province/${data.provinceId}/destinationPro`)
                setDesProvince(res)
            }
            catch (error) {
                console.log("Erorr:", error)
            }

        }
        getData()
    }, [data.provinceId])


    //lấy blogById
    // const [DataBlog, setDataBlog] = useState([])
    // useEffect(() => {
    //     if (blogId != null) {
    //       const getData = async () => {
    //         try {
    //           const res = await get(`Blog/${blogId}/blogDetail`);
    //           setDataBlog(res);
    //         } catch (error) {
    //           console.log("Error:", error);
    //         }
    //       };
    
    //       getData();
    //     }
    //   }, [blogId]);

    console.log("desProvince", desProvince)
    return (
        <div className="intro-des-container">
            <Navbar openLogin={handleLogin} openRegister={handleRegister} openSearchForm={toggleForm} />
            <>
                {openLogin ? <Login btnClose={handleLogin} /> : ''}
                {openRegister ? <Register btnClose={handleRegister} /> : ''}
            </>
            {openSearchForm && (
                <Search toggleOutsideForm={toggleForm} />
            )}
            <div className="imgAv-container">
                <img src={data.imgAvatar} alt="" />
            </div>
            <div className='navDes'>
                <ul className="navList flex">
                    <li className="navItem">
                        {/* <Link to="/gioi-thieu" className="navLink">
                            Việt Nam
                        </Link> */}
                        <span>Việt Nam</span>
                    </li>
                    <li>
                        <AiFillCaretRight className="" />
                    </li>
                    <li className="navItem havSub">
                        <Link to={`/gioi-thieu/${desProvince.id}`} state={desProvince.id} className="navLink">
                            {data.nameProvince}
                        </Link>
                        <ul className="subNavItem" >
                            {
                                desByProvince?.map((travel, index) => {
                                    return (
                                        <li>
                                            <Link to={`/gioi-thieu/${travel.id}`} state={travel.id} className="navLink">
                                                {travel.name}
                                            </Link>
                                        </li>
                                    )
                                })
                            }
                            
                        </ul>
                    </li>
                </ul>
            </div>
            <div className="containerIntroDes flex-start">
                <div className="navbar-container itemContainerDes">
                    <NavbarDetail blogId={blogId} desProvince={desProvince}/>
                </div>
                <div className="intro-container itemContainerDes">
                    <IntroduceDes blogId={blogId} />
                </div>
            </div>
        </div>
    );
};

export default BlogDetail;
