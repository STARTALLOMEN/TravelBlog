import React from 'react'
import { BiEdit } from 'react-icons/bi'
import { AiOutlineHeart, AiOutlineComment } from 'react-icons/ai'
import { Link } from "react-router-dom";
import './post.scss'

const Post = () => {
  return (
    <section className="secContainerPost">
        <div className="post flex-start">
            <div className="avatar">
                <img src="https://media.gody.vn/images/lao-cai/nha-tho-sapa/10-2016/20161020033948-nha-tho-sapa-gody(9).jpg" alt="" />
            </div>
            <div className="contentPost">
                <div className="headerPost itemContentPost">
                    <Link to='/'>
                        <BiEdit/>
                    </Link>
                    <span>Đà Nẵng, thành phố đáng sống nhất Việt Nam</span>
                </div>
                <div className="text-container itemContentPost">
                    <span className="content">
                        Các bạn đã từng đi du lịch khối Bắc Âu cho mình xin chút kinh nghiệm và những điểm đến đẹp ko thể bỏ qua ở những thành phố cảng như Stavanger, Hellesylt, Geivanger và Maloy của Na uy với. Tháng sau mình đi Tour tàu biển này, sẽ ghé những điểm như trên hình, Tour tham quan của nhà tàu có nhiều nhưng giá hơi đắt nên mình muốn tham khảo trước để tự đi. Cảm ơn các bạn nhiều.
                        Các bạn đã từng đi du lịch khối Bắc Âu cho mình xin chút kinh nghiệm và những điểm đến đẹp ko thể bỏ qua ở những thành phố cảng như Stavanger, Hellesylt, Geivanger và Maloy của Na uy với. Tháng sau mình đi Tour tàu biển này, sẽ ghé những điểm như trên hình, Tour tham quan của nhà tàu có nhiều nhưng giá hơi đắt nên mình muốn tham khảo trước để tự đi. Cảm ơn các bạn nhiều.
                        Các bạn đã từng đi du lịch khối Bắc Âu cho mình xin chút kinh nghiệm và những điểm đến đẹp ko thể bỏ qua ở những thành phố cảng như Stavanger, Hellesylt, Geivanger và Maloy của Na uy với. Tháng sau mình đi Tour tàu biển này, sẽ ghé những điểm như trên hình, Tour tham quan của nhà tàu có nhiều nhưng giá hơi đắt nên mình muốn tham khảo trước để tự đi. Cảm ơn các bạn nhiều.
                        Các bạn đã từng đi du lịch khối Bắc Âu cho mình xin chút kinh nghiệm và những điểm đến đẹp ko thể bỏ qua ở những thành phố cảng như Stavanger, Hellesylt, Geivanger và Maloy của Na uy với. Tháng sau mình đi Tour tàu biển này, sẽ ghé những điểm như trên hình, Tour tham quan của nhà tàu có nhiều nhưng giá hơi đắt nên mình muốn tham khảo trước để tự đi. Cảm ơn các bạn nhiều.
                    </span>
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
    </section>
  )
}

export default Post