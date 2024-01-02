import React from 'react'
import './questionHome.scss'
import { Link } from "react-router-dom";

const data = [
  {
    id: 1,
    imgSrc: "https://media.gody.vn/images/lao-cai/nha-tho-sapa/10-2016/20161020033948-nha-tho-sapa-gody(9).jpg",
    destTitle: 'Nơi đẹp Việt Nam',
    location: 'Hello mọi người ạ. Mọi người cho e hỏi là khách sạn khu Bugis có ok không ạ? Em đang cần tìm khách sạn gần các cửa hàng tiện lợi và trạm xe bus Cảm ơn mng rất nhiều.',
    username: 'Minh Hoàng'
  },
  {
    id: 1,
    imgSrc: "https://media.gody.vn/images/lao-cai/nha-tho-sapa/10-2016/20161020033948-nha-tho-sapa-gody(9).jpg",
    destTitle: 'Nơi đẹp Việt Nam',
    location: 'Hello mọi người ạ. Mọi người cho e hỏi là khách sạn khu Bugis có ok không ạ? Em đang cần tìm khách sạn gần các cửa hàng tiện lợi và trạm xe bus Cảm ơn mng rất nhiều.',
    username: 'Minh Hoàng'
  },
  {
    id: 1,
    imgSrc: "https://media.gody.vn/images/lao-cai/nha-tho-sapa/10-2016/20161020033948-nha-tho-sapa-gody(9).jpg",
    destTitle: 'Nơi đẹp Việt Nam',
    location: 'Hello mọi người ạ. Mọi người cho e hỏi là khách sạn khu Bugis có ok không ạ? Em đang cần tìm khách sạn gần các cửa hàng tiện lợi và trạm xe bus Cảm ơn mng rất nhiều.',
    username: 'Minh Hoàng'
  }
]

const Question = () => {
  return (
    <section className="question section container">
      <div className="secContainer">
        <div className="secHeader flex">
          <div className="textDiv">
            <h2 className="secTitle">Q/A - Hỏi đáp du lịch</h2>
          </div>
        </div>
        <div className="mainContent">
          {
            data.map((question) => {
              return (
                <div key={question.id} className="singleQuestion">
                  <div className="overlayInfo">
                    <Link to="/" className='titleQues'>
                      <p>Nên xem show Ấn Tượng Lệ Giang hay Lệ Giang Thiên Cổ tình</p>
                    </Link>
                    <div className="infoDiv flex">
                      <div className="img">
                        <Link>
                          <img src="https://media.gody.vn/images/lao-cai/nha-tho-sapa/10-2016/20161020033948-nha-tho-sapa-gody(9).jpg" alt="" className="avata" />
                        </Link>
                      </div>
                      <div className="infoQues">
                        <div className="name">
                          <Link>
                            <p>Ngọc Anh</p>
                          </Link>
                        </div>
                        <div className="contentQues">
                          <p>Mình dự định thuê xe oto tự lái từ Florence tới Tuscany mùa hè này. Ngoài bằng lái VN đổi sang quốc tế, mng cho mình hỏi về kn thuê xe, hãng thuê & cung đg đẹp với. Mình dự định sẽ ở lại Tuscany 1 đêm. Cảm ơn mng.</p>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              )
            })}
        </div>
      </div>
    </section>
  )
}

export default Question