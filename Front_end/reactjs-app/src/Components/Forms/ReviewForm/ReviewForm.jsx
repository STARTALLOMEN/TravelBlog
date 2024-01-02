import React, { useState, useEffect } from 'react';
import { useParams, useLocation } from 'react-router-dom';
import { FaStar } from 'react-icons/fa';
import './reviewForm.scss';
import BaseFormImage from '../../BaseFolder/BaseFormImage';
import Navbar from '../../Navbar/Navbar';
import Login from '../Login/Login';
import Register from '../Register/Register';
import Search from '../Search/Search';
import request, { postWithFormData, get } from '../../../utils/request';

function ReviewForm() {
    const params = useParams();
    const desId = params.id;
    console.log("desId", desId);

    const [hoveredRating, setHoveredRating] = useState(0);
    const [selectedRating, setSelectedRating] = useState(0);
    const [title, setTitle] = useState('');
    const [content, setContent] = useState('');
    const [images, setImages] = useState([])

    const [openLogin, setopenLogin] = useState(false);
    const [openRegister, setopenRegister] = useState(false);
    const [openSearchForm, setopenSearchForm] = useState(false);
    const [desData, setDesData] = useState(null);

    useEffect(() => {
        if (desId != null) {
            const getData = async () => {
                try {
                    const res = await get(`Destination/get-dentination/${desId}`);
                    setDesData(res);
                } catch (error) {
                    console.log("Error:", error);
                }
            };

            getData();
        }
    }, [desId]);

    const handleLogin = () => {
        setopenLogin(!openLogin);
    }
    const handleRegister = () => {
        setopenRegister(!openRegister);
    }
    const toggleForm = () => {
        setopenSearchForm(!openSearchForm);
    };

    const handleRatingHover = (ratingValue) => {
        setHoveredRating(ratingValue);
    };

    const handleRatingClick = (ratingValue) => {
        setSelectedRating(ratingValue);
    };

    const handleTitleChange = (event) => {
        setTitle(event.target.value);
    };

    const handleContentChange = (event) => {
        setContent(event.target.value);
    };


    const formData = new FormData()
    formData.append('Title', title);
    formData.append('Content', content)
    formData.append('NumberStar', selectedRating)
    if (images) {
        for (let i = 0; i < images.length; i++) {
            formData.append('ImageReviewsFile', images[i]);
        }
    }
    //send api
    const handleSubmit = async () => {
        try {
            const res = await postWithFormData(`ReviewDestination/Destination/${desId}`, formData);
            console.log(res);
        } catch (error) {
            console.log(error);
        }
    };
    return (
        <div className="containerReview">
            <Navbar openLogin={handleLogin} openRegister={handleRegister} openSearchForm={toggleForm} />
            <>
                {openLogin ? <Login btnClose={handleLogin} /> : ''}
                {openRegister ? <Register btnClose={handleRegister} /> : ''}
            </>
            {openSearchForm && (
                <Search toggleOutsideForm={toggleForm} />
            )}
            <div className="review-form">
                <div className="header">
                    <img className="avatar" src={desData?.imgAvatar} alt="Avatar" />
                    <h2 className="destination">{desData?.name}</h2>
                </div>
                <div className='form'>
                    <div className="rating-location">
                        <label>Xếp hạng trải nghiệm của bạn:</label>
                        <div className="rating-icons">
                            {[1, 2, 3, 4, 5].map((ratingValue) => {
                                const isSelected = ratingValue <= selectedRating;
                                const isHovered = ratingValue <= hoveredRating;

                                return (
                                    <div
                                        key={ratingValue}
                                        className={`star ${isSelected ? 'selected' : ''} ${isHovered ? 'hovered' : ''
                                            }`}
                                        onClick={() => handleRatingClick(ratingValue)}
                                        onMouseEnter={() => handleRatingHover(ratingValue)}
                                        onMouseLeave={() => handleRatingHover(0)}
                                    >
                                        <FaStar />
                                    </div>
                                );
                            })}
                        </div>
                    </div>
                    <div className="review-title">
                        <label>Tiêu đề:</label>
                        <input type="text" value={title} onChange={handleTitleChange} />
                    </div>
                    <div className="review-content">
                        <label>Nội dung:</label>
                        <textarea value={content} onChange={handleContentChange} />
                    </div>
                    <div className="review-image">
                        <label>Ảnh:</label>
                        <BaseFormImage setImages={setImages} images={images} />
                    </div>
                    <div className="submit-button ">
                        <button type="submit" className='btn btnSubReview' onClick={handleSubmit}>Gửi đánh giá</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default ReviewForm;
