import React from 'react'
import './about.scss'
import imgTravel from '../../Assets/iconTravel.png'
import imgCustomer from '../../Assets/iconCustomer.png'
import imgPosts from '../../Assets/iconPost.png'
import imgComment from '../../Assets/iconComment.png'
import video from '../../Assets/video.mp4'
const About = () => {
    return (
        <div className="about section">
            <div className="secContainer">
                <h2 className="title">
                    Tại sao du khách đến với Gody?
                </h2>
                <div className="mainContent container grid">
                    <div className="singleItem">
                        <img src={imgTravel} alt="Image Name" />
                        <h3>600+ Điểm tham quan</h3>
                        <p>Chúng tôi đã giới thiệu đến bạn đọc những địa điểm du lịch nổi tiếng trong nước,
                            từ những địa điểm du lịch đồng quê đến những thành phố sầm uất và hấp dẫn</p>
                    </div>
                    <div className="singleItem">
                        <img src={imgCustomer} alt="Image Name" />
                        <h3>1000+ Thành viên</h3>
                        <p> Chúng tôi luôn cố gắng cung cấp cho thành viên những trải nghiệm tốt nhất và tạo ra một cộng đồng du lịch đầy đủ và đa dạng.</p>
                    </div>
                    <div className="singleItem">
                        <img src={imgPosts} alt="Image Name" />
                        <h3>3000+ Bài viết</h3>
                        <p>Người dùng chia sẻ những trải nghiệm và kiến thức của họ về các địa điểm du lịch. Từ những bài đánh giá đến những hướng dẫn du lịch,
                            chúng tôi luôn cố gắng tạo ra một kho thông tin phong phú và đáng tin cậy cho người dùng.</p>
                    </div>
                    <div className="singleItem">
                        <img src={imgComment} alt="Image Name" />
                        <h3>4000+ Comment tương tác</h3>
                        <p>Chúng tôi cũng đã có hàng nghìn lượt tương tác từ người dùng,
                            bao gồm những bình luận, đánh giá và hỏi đáp. Chúng tôi luôn trân trọng mọi đóng góp từ
                            cộng đồng của mình và cố gắng tương tác và giải đáp mọi thắc mắc của người dùng.</p>
                    </div>
                </div>
                <div className="videoCard container">
                    <div className="cardContent grid">
                        <div className="cardText">
                            <h2>Bản đồ du lịch cá nhân</h2>
                            <p>
                                Check-in bản đồ du lịch Việt Nam để lưu lại dấu chân của mình, chia sẻ cùng bạn bè.
                                Bạn đã khám phá được bao nhiêu % Việt Nam? Đã đến được bao nhiêu tỉnh thành?
                            </p>
                        </div>
                        <div className="cardVideo">
                            <video src={video} autoPlay loop muted typeof='video.mp4'></video>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default About