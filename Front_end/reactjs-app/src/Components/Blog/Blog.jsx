import React from 'react'
import './blog.scss'
import { BsArrowRightShort } from 'react-icons/bs'

const Post = [
    {
        id: 1,
        imgSrc: "https://media.gody.vn/images/lao-cai/nha-tho-sapa/10-2016/20161020033948-nha-tho-sapa-gody(9).jpg",
        destTitle: ' Hành trình chinh phục đỉnh Phu Xai Lai Leng - Nóc nhà dãy Trường Sơn Bắc',
        desc: 'Đây là bài viết kể về hành trình chinh phục đỉnh Puxailaileng thuộc địa phận xã Na Ngoi, huyện Kỳ Sơn, tỉnh Nghệ An, sát biên giới với Lào được xem là nóc nhà của dãy bắc Trường Sơn hùng vĩ.'
    },
    {
        id: 2,
        imgSrc: "https://media.gody.vn/images/lao-cai/nha-tho-sapa/10-2016/20161020033948-nha-tho-sapa-gody(9).jpg",
        destTitle: ' Hành trình chinh phục đỉnh Phu Xai Lai Leng - Nóc nhà dãy Trường Sơn Bắc',
        desc: 'Đây là bài viết kể về hành trình chinh phục đỉnh Puxailaileng thuộc địa phận xã Na Ngoi, huyện Kỳ Sơn, tỉnh Nghệ An, sát biên giới với Lào được xem là nóc nhà của dãy bắc Trường Sơn hùng vĩ.'
    },
    {
        id: 3,
        imgSrc: "https://media.gody.vn/images/lao-cai/nha-tho-sapa/10-2016/20161020033948-nha-tho-sapa-gody(9).jpg",
        destTitle: ' Hành trình chinh phục đỉnh Phu Xai Lai Leng - Nóc nhà dãy Trường Sơn Bắc',
        desc: 'Đây là bài viết kể về hành trình chinh phục đỉnh Puxailaileng thuộc địa phận xã Na Ngoi, huyện Kỳ Sơn, tỉnh Nghệ An, sát biên giới với Lào được xem là nóc nhà của dãy bắc Trường Sơn hùng vĩ.'
    },
]

function Blog (){
    return (
        <section className="blog container section">
            <div className="secContainer">
                <div className="secIntro">
                    <h2 className="secTitle">
                        Blog tuyệt vời!
                    </h2>
                    <p>Godyer chia sẻ những trải nghiệm của bản thân qua các chuyến đi</p>
                </div>
                <div className="mainContainer grid">
                    {Post.map((post) => {
                        return (
                            <div key={post.id} className="singlePost grid">
                                <div className="imgDiv">
                                    <img src={post.imgSrc} alt="Image Name" />
                                </div>
                                <div className="postDetails">
                                    <h3>{post.destTitle}</h3>
                                    <p>{post.desc}</p>
                                </div>
                                <a href="#" className="flex">
                                    Đọc thêm
                                    <BsArrowRightShort className="icon"></BsArrowRightShort>
                                </a>
                            </div>
                        )
                    })}
                </div>
            </div>
        </section>
    )
}

export default Blog