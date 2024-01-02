import React , {useState, useEffect }from 'react'
import { BsArrowRightShort } from 'react-icons/bs'
import { BsArrowLeftShort } from 'react-icons/bs'
import './popular.scss'
import request, { get } from '../../utils/request';
import { Link } from 'react-router-dom';
function Popular(){
const [data, setData] = useState([])
  useEffect(() => {
    const getData = async () => {
        try {
            const res = await get('Destination/popular')
            setData([...res])
        }
        catch (error) {
            console.log("Erorr:", error)
        }

    }
    getData()
}, [])

console.log(data)
  return (
    <section className="popular section container">
      <div className="secContainer">
        <div className="secHeader flex">
          <div className="textDiv">
            <h2 className="secTitle">Điểm đến hot</h2>
            <p>Lựa chọn phổ biến nhất cho du khách từ Việt Nam</p>
          </div>
          <div className="iconDiv flex">
            <BsArrowLeftShort className="icon leftIcon" />
            <BsArrowRightShort className="icon rightIcon" />
          </div>
        </div>
        <div className="mainContent grid">
          {
            data?.map((travel,index) => {
              return (
                <Link to= {`/gioi-thieu/${travel.id}`} state={travel.id}>
                  <div key={travel.id} className="singleDestination">
                    <div className="destImage">
                      <img src={travel.imgAvatar} alt="Image Title" />
                      <div className="overlayInfo">
                        {/* <h3>{travel.Name}</h3> */}
                        <p>{travel.name}</p>
                        <BsArrowRightShort className="icon" />
                      </div>
                    </div>

                    <div className="destFooter">
                      <div className="number">
                      {index < 9 ? `0${index+1}` : index + 1}
                      </div>

                      <div className="destText flex">
                        <h6>{travel.name}</h6>
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

export default Popular