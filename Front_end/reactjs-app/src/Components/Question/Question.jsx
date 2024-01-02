import React from 'react';
import { Link } from "react-router-dom";
import { AiOutlineHeart, AiOutlineComment } from 'react-icons/ai'
import './question.scss'

function Question(props) {
    const listImage = [
        {
            id: 1,
            imgSrc: "https://media.gody.vn/images/lao-cai/nha-tho-sapa/10-2016/20161020033948-nha-tho-sapa-gody(9).jpg",
        },
        {
            id: 2,
            imgSrc: "https://media.gody.vn/images/lao-cai/nha-tho-sapa/10-2016/20161020033948-nha-tho-sapa-gody(9).jpg",
        },
        {
            id: 3,
            imgSrc: "https://media.gody.vn/images/lao-cai/nha-tho-sapa/10-2016/20161020033948-nha-tho-sapa-gody(9).jpg",
        }
    ]
    const listLocation = [
        {
            id: 1,
            name: "Đà Nẵng",
        },
        {
            id: 2,
            name: "Quảng Nam",
        },
        {
            id: 3,
            name: "Quảng Trị",
        },
        {
            id: 4,
            name: "Đà Nẵng",
        },
        {
            id: 5,
            name: "Quảng Nam",
        },
        {
            id: 6,
            name: "Quảng Trị Quảng Trị Quảng Trị",
        },

    ]
    return (
        <div className="secContainerQues">
            <div className="question">
                <div className="user flex itemDivQues">
                    <img className="avatar" src="https://media.gody.vn/images/lao-cai/nha-tho-sapa/10-2016/20161020033948-nha-tho-sapa-gody(9).jpg" alt="User Avatar" />
                    <span className="username">Anna</span>
                </div>
                <div className="itemDivQues">
                    <Link to='/' className="title">Kinh nghiệm du lịch khối Bắc Âu</Link>
                </div>
                <div className="text-container itemDivQues">
                    <span className="content ">
                        Các bạn đã từng đi du lịch khối Bắc Âu cho mình xin chút kinh nghiệm và những điểm đến đẹp ko thể bỏ qua ở những thành phố cảng như Stavanger, Hellesylt, Geivanger và Maloy của Na uy với. Tháng sau mình đi Tour tàu biển này, sẽ ghé những điểm như trên hình, Tour tham quan của nhà tàu có nhiều nhưng giá hơi đắt nên mình muốn tham khảo trước để tự đi. Cảm ơn các bạn nhiều.
                        Các bạn đã từng đi du lịch khối Bắc Âu cho mình xin chút kinh nghiệm và những điểm đến đẹp ko thể bỏ qua ở những thành phố cảng như Stavanger, Hellesylt, Geivanger và Maloy của Na uy với. Tháng sau mình đi Tour tàu biển này, sẽ ghé những điểm như trên hình, Tour tham quan của nhà tàu có nhiều nhưng giá hơi đắt nên mình muốn tham khảo trước để tự đi. Cảm ơn các bạn nhiều.
                        Các bạn đã từng đi du lịch khối Bắc Âu cho mình xin chút kinh nghiệm và những điểm đến đẹp ko thể bỏ qua ở những thành phố cảng như Stavanger, Hellesylt, Geivanger và Maloy của Na uy với. Tháng sau mình đi Tour tàu biển này, sẽ ghé những điểm như trên hình, Tour tham quan của nhà tàu có nhiều nhưng giá hơi đắt nên mình muốn tham khảo trước để tự đi. Cảm ơn các bạn nhiều.
                        Các bạn đã từng đi du lịch khối Bắc Âu cho mình xin chút kinh nghiệm và những điểm đến đẹp ko thể bỏ qua ở những thành phố cảng như Stavanger, Hellesylt, Geivanger và Maloy của Na uy với. Tháng sau mình đi Tour tàu biển này, sẽ ghé những điểm như trên hình, Tour tham quan của nhà tàu có nhiều nhưng giá hơi đắt nên mình muốn tham khảo trước để tự đi. Cảm ơn các bạn nhiều.
                    </span>
                </div>
                <div className="images">
                    {listImage.map((image, index) => (
                        <img key={image.id} src={image.imgSrc} alt={`Question Image ${index + 1}`} />
                    ))}
                </div>
                <div className="metadata flex">
                    {listLocation.map((location) => (
                        <div className="locationDiv">
                            <span className="location">{location.name}</span>
                        </div>
                    ))}
                </div>
                <div className="stats flex">
                    <div className="live itemStat">
                        <AiOutlineHeart className="icon" />
                        <span className="likes">3 Likes</span>
                    </div>
                    <div className="comment itemStat">
                        <AiOutlineComment className="icon"/>
                        <span className="comments">4 Comments</span>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Question;