import React, { useState, useEffect } from 'react'
import './generalProfile.scss'
import jwt from 'jwt-decode';

function GeneralProfile() {
  const [isLogin, setIsLogin] = useState(false);
  const [userToken, setUserToken] = useState(localStorage.getItem('userToken') || null)
  const [name, setName] = useState('')
  const [avatar, setAvatar] = useState('')

  useEffect(() => {
    try {
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
    catch {
      console.log("abc")
    }
  }, [userToken, isLogin]);

  return (
    <section className="secContainer-profile">
      <div className="general-profile">
        <img src={avatar} alt="Avatar" className="avatarImage" />
        <span className='statsBold'>{name}</span>
        <span className="introduction itemContent">Hãy đi cùng tôi đến nhiều nơi khác nhé</span>
        <div className="grid-profile">
          <div className="profile-stats ">
            <div className="stat ">
              <span className="stat-value statsBold">0</span>
              <span className="stat-label">Tỉnh thành</span>
            </div>
            <div className="stat">
              <span className="stat-value statsBold">0</span>
              <span className="stat-label">Đóng góp</span>
            </div>
          </div>
          <div className="profile-stats">
            <div className="stat">
              <span className="stat-value statsBold">0</span>
              <span className="stat-label">Theo dõi</span>
            </div>
            <div className="stat">
              <span className="stat-value statsBold">0</span>
              <span className="stat-label">Đang theo dõi</span>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};

export default GeneralProfile;
