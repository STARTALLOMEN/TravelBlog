import React, { useState, useEffect } from 'react'
import { FaStar, FaStarHalfAlt, FaMapMarkerAlt } from 'react-icons/fa';
import { AiOutlineHeart, AiOutlineStar } from 'react-icons/ai'
import './accomodationRestaurant.scss'
import request, { get } from '../../utils/request';
import { Link } from 'react-router-dom';

const AccomodationRestaurant = () => {
    //render icon rating
    const renderStars = (rating) => {
        const fullStars = Math.floor(rating);
        const halfStars = rating - fullStars >= 0.5 ? 1 : 0;
        const emptyStars = 5 - fullStars - halfStars;

        const stars = [];

        for (let i = 0; i < fullStars; i++) {
            stars.push(<FaStar className='icon iconStar' key={i} />);
        }

        if (halfStars === 1) {
            stars.push(<FaStarHalfAlt className='icon iconStar' key={fullStars} />);
        }

        for (let i = 0; i < emptyStars; i++) {
            stars.push(<AiOutlineStar className='icon iconStar' key={fullStars + halfStars + i} />);
        }

        return stars;
    }
    
    const [accomRestr, setAccomRestr] = useState([])
    useEffect(() => {
        const getData = async () => {
            try {
                const res = await get('Destination/popularHotelResstaurant')
                setAccomRestr([...res])
            }
            catch (error) {
                console.log("Erorr:", error)
            }

        }
        getData()
    }, [])

    return (
        <section className="accomRestr container section">
            <div className='secContainer'>
                <div className="secHeader flex">
                    <div className="textDiv">
                        <h2 className="secTitle">Khách sạn và nhà hàng</h2>
                        <p>Nhiều khách sạn và nhà hàng phục vụ du khách</p>
                    </div>
                </div>
                <div className="mainContent grid">
                    {
                        accomRestr.map((accomRestr) => {
                            return (
                                <Link to= {`/gioi-thieu/${accomRestr.id}`} state={accomRestr.id}>
                                <div key={accomRestr.id} className="singleAccomRestr">
                                    <div className="destImage">
                                        <img src={accomRestr.imgAvatar} alt="Image Name" />
                                        <button className="bookmark">
                                            <AiOutlineHeart className="icon">
                                            </AiOutlineHeart>
                                        </button>
                                    </div>

                                    <div className="destFooter">
                                        <h6 className="title">{accomRestr.name}</h6>
                                        <div className="starReview">
                                            <div className="iconStar">{renderStars(accomRestr.numberStar)}</div>
                                            <span>{accomRestr.numberReview} reviews</span>
                                        </div>
                                        <div className="destDetination">
                                            <FaMapMarkerAlt className="iconDetina"></FaMapMarkerAlt>
                                            <span>{accomRestr.nameProvince}</span>
                                        </div>
                                    </div>
                                </div>
                                </Link>
                            )
                        })
                    }
                </div>
            </div>
        </section>
    )
}

export default AccomodationRestaurant