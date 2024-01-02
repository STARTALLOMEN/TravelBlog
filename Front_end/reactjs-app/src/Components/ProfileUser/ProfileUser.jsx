import React, { useState, useEffect } from 'react';
import './profile.scss'

function ProfileUser() {
    const [user, setUser] = useState({
        firstName: '',
        lastName: '',
        phoneNumber: '',
        email: '',
        avatar: '',
        coverImage: '',
    });

    useEffect(() => {
        // Lấy thông tin User từ API và cập nhật state user
        const fetchUser = async () => {
            try {
                const res = await fetch('/api/user'); // Thay đổi đường dẫn API tương ứng
                const data = await res.json();
                setUser(data);
            } catch (error) {
                console.log('Error:', error);
            }
        };

        fetchUser();
    }, []);

    const handleUpdateUserInfo = (event) => {
        event.preventDefault();
        // Gửi thông tin User đã cập nhật lên API để lưu trữ
        // Thực hiện cập nhật state user
        // ...
    };

    const handleAvatarChange = (event) => {
        const file = event.target.files[0];
        const reader = new FileReader();

        reader.onload = () => {
            setUser((prevUser) => ({
                ...prevUser,
                avatar: reader.result,
            }));
        };

        reader.readAsDataURL(file);
    };

    const handleCoverImageChange = (event) => {
        const file = event.target.files[0];
        const reader = new FileReader();

        reader.onload = () => {
            setUser((prevUser) => ({
                ...prevUser,
                coverImage: reader.result,
            }));
        };

        reader.readAsDataURL(file);
    };

    const handleChange = (event) => {
        const { name, value } = event.target;
        setUser((prevUser) => ({
          ...prevUser,
          [name]: value,
        }));
      };

    return (
        <div className="profile-user">
            <div className="profile-header">
                <img className="cover-image" src="https://znews-photo.zingcdn.me/w1920/Uploaded/mdf_eioxrd/2021_07_06/2.jpg" alt="Cover" />
                <input className='cover-input' type="file" onChange={handleCoverImageChange} accept="image/*" />
                <span className='span-cover-input'>Thay đổi ảnh bìa</span>
                <img className="avatar-image" src={user.avatar} alt="Avatar" />
                <input className='avatar-input' type="file" onChange={handleAvatarChange} accept="image/*" />
            </div>
            <div className="profile-details">
                {/* <h1 className="full-name">{`${user.firstName} ${user.lastName}`}</h1> */}
                <form onSubmit={handleUpdateUserInfo}>
                    <div className="form-group">
                        <label htmlFor="firstName">First Name:</label>
                        <input
                            type="text"
                            name="firstName"
                            value={user.firstName}
                            onChange={handleChange}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="lastName">Last Name:</label>
                        <input
                            type="text"
                            name="lastName"
                            value={user.lastName}
                            onChange={handleChange}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="phoneNumber">Phone Number:</label>
                        <input
                            type="text"
                            name="phoneNumber"
                            value={user.phoneNumber}
                            onChange={handleChange}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="email">Email:</label>
                        <input
                            type="email"
                            name="email"
                            value={user.email}
                            onChange={handleChange}
                        />
                    </div>
                    <button type="submit">Update</button>
                </form>
            </div>
        </div>
    );
}

export default ProfileUser;
