import React, { useState, useEffect } from 'react'
import { FaStar, FaStarHalfAlt } from 'react-icons/fa';
import { AiOutlineStar } from 'react-icons/ai';
import './starrating.scss'


function StarRating() {
  const [rating, setRating] = useState(3.5);

  const renderStars = () => {
    const fullStars = Math.floor(rating);
    const halfStars = rating - fullStars >= 0.5 ? 1 : 0;
    const emptyStars = 5 - fullStars;

    const stars = [];

    for (let i = 0; i < fullStars; i++) {
      stars.push(<FaStar className='icon iconStar' key={i}/>);
    }

    if (halfStars === 1) {
      stars.push(<FaStarHalfAlt className='icon iconStar' key={fullStars} />);
    }

    for (let i = 0; i < emptyStars; i++) {
      stars.push(<AiOutlineStar className='icon iconStar' key={fullStars + halfStars + i} />);
    }

    return stars;
  }

  return (
    <div>
      {renderStars()} {parseFloat(rating).toFixed(1)} sao
    </div>
  );
}

export default StarRating;