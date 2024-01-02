import React, { useState, useEffect } from 'react'
import BlogQuill from '../../Components/LayoutBlog/BlogQuill/BlogQuill';
import Navbar from '../../Components/Navbar/Navbar'
import BlogHeader from '../../Components/LayoutBlog/BlogHeader/BlogHeader '
import Footer from '../../Components/Footer/Footer'
import './shareImageDestination.scss'
import BaseFormImage from '../../Components/BaseFolder/BaseFormImage';
import request, { postWithFormData, get } from '../../utils/request';
import Login from '../../Components/Forms/Login/Login'
import Register from '../../Components/Forms/Register/Register'
import Search from '../../Components/Forms/Search/Search';


function ShareImageDestination() {
    const [openLogin, setopenLogin] = useState(false);
    const [openRegister, setopenRegister] = useState(false);
    const [openSearchForm, setopenSearchForm] = useState(false);
    const [listselectedDestination, setListSelectedDestination] = useState([]);
    const [searchValue, setSearchValue] = useState(null);
    const [destinationResults, setDestinationResults] = useState([]);

    const handleLogin = () => {
        setopenLogin(!openLogin);
    }
    const handleRegister = () => {
        setopenRegister(!openRegister);
    }
    const toggleForm = () => {
        setopenSearchForm(!openSearchForm);
    };
    //
    const [photo, setPhoto] = useState(null);
    const [title, setTitle] = useState("");


    const [images, setImages] = useState([])
    console.log(images)

    const [data, setData] = useState({
        ShortDecription: '',
    })
    const handleOnChange = (e) => {
        setData({ ...data, [e.target.name]: e.target.value })
    }

    const formData = new FormData()
    formData.append('Title', title);
    formData.append('ImgAvatarFile', photo)
    formData.append('ShortDecription', data.ShortDecription)
    if (images) {
        for (let i = 0; i < images.length; i++) {
            formData.append('ListImgShareFile', images[i]);
        }
    }
    if (listselectedDestination) {
        for (let i = 0; i < listselectedDestination.length; i++) {
            formData.append('DesId', listselectedDestination[i].id);
        }
    }

    //send api
    const handleSubmit = async () => {
        try {
            console.log(formData.get('Title'))
            console.log(formData.get('ImgAvatarFile'))
            console.log(formData.get('ListImgShareFile'))
            console.log(images)
            const res = await postWithFormData('ImageShare', formData);
            console.log(res);
        } catch (error) {

            console.log("-----error:", error);
        }
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                const destinationRes = await get(`Destination/${searchValue}`);
                setDestinationResults(destinationRes);
            } catch (error) {
                console.log('Error:', error);
            }
        };

        fetchData();
    }, [searchValue]);

    const handleInputChange = (event) => {
        setSearchValue(event.target.value);
    };

    const handleDestinationClick = (destination) => {
        if (!listselectedDestination.some((item) => item.id === destination.id)) {
            setListSelectedDestination([...listselectedDestination, destination]);
            setDestinationResults([]);
        }
    };

    return (
        <div className="shareImageDestination">
            <Navbar openLogin={handleLogin} openRegister={handleRegister} openSearchForm={toggleForm} />
            <>
                {openLogin ? <Login btnClose={handleLogin} /> : ''}
                {openRegister ? <Register btnClose={handleRegister} /> : ''}
            </>
            {openSearchForm && (
                <Search toggleOutsideForm={toggleForm} />
            )}
            <BlogHeader placeholder="Tiêu đề albums" onCoverPhotoChange={setPhoto} onTitleChange={setTitle} />
            <div className="secContainer">
                <div className="desScriptDiv itemDiv">
                    <div className="desScript">
                        <textarea name="ShortDecription" id="" rows="4"
                            placeholder='Giới thiệu ngắn ...'
                            className="form-control travelBlogDescription bar-10 bn card6 p-15 resize-none w-fit h-inherit bn fs-18 bar-2"
                            onChange={e => handleOnChange(e)}
                            value={data.ShortDecription}
                        >
                        </textarea>
                    </div>
                </div>
                <div className="destinaTag itemContent">
                    <input type="text" placeholder='Tag(địa điểm liên quan)' onChange={handleInputChange} />
                </div>
                <div className="searchResult">
                    {destinationResults.map((destination) => (
                        <span key={destination.id} onClick={() => handleDestinationClick(destination)} className='desResult'>
                            # {destination.name}
                        </span>
                    ))}
                </div>
                <div className="metadata flex itemContent">
                    {listselectedDestination.map((location) => (
                        <div className="locationDiv" key={location.id}>
                            <span className="location">{location.name}</span>
                            <button className="btn-close" type='button'
                                onClick={
                                    (e) => {
                                        const newLocaTags = listselectedDestination.filter((_) => _.id !== location.id);
                                        setListSelectedDestination(newLocaTags);

                                    }
                                } />
                        </div>
                    ))}
                </div>
                <div className="imgContainer">
                    <h4>Album ảnh (Tối đa 100 ảnh)</h4>
                    <BaseFormImage setImages={setImages} images={images} />
                </div>
                <div className="submit">
                    <button className='btn icon' onClick={handleSubmit}>Đăng bài</button>
                </div>
            </div>
            <Footer />
        </div>

    )
}

export default ShareImageDestination