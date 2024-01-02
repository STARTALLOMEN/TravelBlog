import React, { useState, useEffect } from 'react';
import { Link } from "react-router-dom";
import './navbarDetail.scss'
import request, { get } from '../../utils/request';

function NavbarDetail(props) {
  const [data, setData] = useState([])
  const [id, setId] = useState(null)
  // const [desProvince, setDesProvince] = useState(null)
  useEffect(() => {
    const getData = async () => {
      try {
        const res = await get(`Destination/get-dentination/${props.desId}`)
        setData(res)
        data.provinceOrAreaOrPrArea === "desSpecial" ? setId(res.desId) : setId(res.provinceId)
        // const respro = await get(`province/${data.provinceId}/destinationPro`)
        // setDesProvince(respro)
      }
      catch (error) {
        console.log("Erorr:", error)
      }
    }
    getData()
  }, [props.desId])
  console.log("idDes", id)
  return (
    <div className="navbar-detail">
      <div className="containerNavbarDeatail">
        <div className="nameProvince">
          {data.provinceOrAreaOrPrArea === "desSpecial" ? (
            <span className="nameProvince">{data.name}</span>
          ) : (
            <span className="nameProvince">{data.nameProvince}</span>
          )}
        </div>
        <ul>
          <li><Link to={`/gioi-thieu/${props.desId}`} state={props.desId}>Giới thiệu</Link></li>
          <li><Link to={`/diem-den/${props.desId}/diem-du-lich/`}>Điểm du lịch</Link></li>
          <li><Link to={`/diem-den/${props.desId}/blog/`}>Kinh nghiệm du lịch</Link></li>
          <li><Link to="path/to/hoi-dap">Hỏi đáp</Link></li>
          <li><Link to="path/to/hinh-anh">Hình ảnh</Link></li>
        </ul>
      </div>
    </div>
  )
}

export default NavbarDetail