import React from 'react'
import { SiYourtraveldottv } from 'react-icons/si'
import { ImFacebook } from 'react-icons/im'
import { AiFillYoutube,AiFillInstagram } from 'react-icons/ai'
import './footer.scss'

function Footer () {
    return (
        <div className="footer">
            <div className=" secContainer container grid">
                <div className="logoDiv">
                    <div className="footerLogo">
                        <a href="#" className="logo flex">
                            <h1 className="flex">
                                <SiYourtraveldottv className="icon" />
                                Gody
                            </h1>
                        </a>
                    </div>
                    <div className="socials flex">
                        <ImFacebook className="icon" />
                        <AiFillYoutube className="icon" />
                        <AiFillInstagram className="icon" />
                    </div>
                </div>
                <div className="footerLinks">
                    <span className="linkTitle">Về Gody</span>
                    <ul>
                        <li>
                            <a href="#">Giới thiệu</a>
                        </li>
                        <li>
                            <a href="#">Chính sách bảo mật</a>
                        </li>
                        <li>
                            <a href="#">Chính sách quyền riêng tư</a>
                        </li>
                        <li>
                            <a href="#">Chính sách sử dụng</a>
                        </li>
                    </ul>
                </div>
                <div className="footerLinks">
                    <span className="linkTitle">Tiện ích</span>
                    <ul>
                        <li>
                            <a href="#">Điểm đến</a>
                        </li>
                        <li>
                            <a href="#">Viết Blog du lịch</a>
                        </li>
                        <li>
                            <a href="#">Hỏi đáp du lịch</a>
                        </li>
                        <li>
                            <a href="#">Lên lịch trình du lịch</a>
                        </li>
                        <li>
                            <a href="#">Tạo bản đồ du lịch</a>
                        </li>
                    </ul>
                </div>
                <div className="footerLinks">
                    <span className="linkTitle">Liên hệ</span>
                    <span className='phone'>0931.547479</span>
                    <span className='email'>21521576@gm.uit.edu.vn</span>
                    <span className='school'>UIT </span>
                </div>
            </div>
        </div>
    )
}

export default Footer