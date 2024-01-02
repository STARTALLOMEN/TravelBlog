import React, { useState,useEffect } from 'react'
import BlogQuill from '../../Components/LayoutBlog/BlogQuill/BlogQuill';
import Navbar from '../../Components/Navbar/Navbar'
import BlogHeader from '../../Components/LayoutBlog/BlogHeader/BlogHeader '
import Footer from '../../Components/Footer/Footer'
import Login from '../../Components/Forms/Login/Login'
import Register from '../../Components/Forms/Register/Register'
import './addDestination.scss'
import request, { postWithFormData,get } from '../../utils/request';
import Search from '../../Components/Forms/Search/Search';

function AddDestination() {
  const [openLogin, setopenLogin] = useState(false);
  const [openRegister, setopenRegister] = useState(false);
  const [openSearchForm, setopenSearchForm] = useState(false);

  const handleLogin = () => {
    setopenLogin(!openLogin);
  }
  const handleRegister = () => {
    setopenRegister(!openRegister);
  }
  const toggleForm = () => {
    setopenSearchForm(!openSearchForm);
  };


  //
  const [photo, setPhoto] = useState(null);
  const [title, setTitle] = useState("");
  const [content, setContent] = useState("");

  // const handleBlogSubmit = () => {
  const [data, setData] = useState({
    ShortDecription: '',
    ProvinceOrArea: true,
    Tips: '',
    Phone: '',
    Email: '',
    UrlWebsite: '',
    WhoGoTogether: '',
    TimeRecomment: '',
    TimeVisit: '',
    PriceAdv: '',
    Address: '',
    Logitude: '',
    Latitude: '',
    ProvinceId: '',
    TypeDestinationId: '',
  })

  const handleOnChange = (e) => {
    setData({ ...data, [e.target.name]: e.target.value })
  }
  //selectBox
  const [selectedOption, setSelectedOption] = useState('');
  const [selectedTypeDes, setselectedTypeDes] = useState('');
  const [selectedProvince, setselectedProvince] = useState('');
  // const [selectedDictrict, setselectedDictrict] = useState('');
  // const [selectedWard, setselectedWard] = useState('');

  const handleOptionChange = (event) => {
    setSelectedOption(event.target.value);
  };
  const handleTypeDesChange = (event) => {
    setselectedTypeDes(event.target.value);
  };
  const handleProvinceChange = (event) => {
    setselectedProvince(event.target.value);
  };
  // const handleDictrictChange = (event) => {
  //   setselectedDictrict(event.target.value);
  // };
  // const handleWardChange = (event) => {
  //   setselectedWard(event.target.value);
  // };
  const formData = new FormData()
  formData.append('ImgAvatarFile', photo);
  formData.append('Name', title)
  formData.append('ShortDecription', data.ShortDecription)
  formData.append('ProvinceOrAreaOrPrArea', selectedOption)
  formData.append('Content', content)
  formData.append('Tips', data.Tips)
  formData.append('Phone', data.Phone)
  formData.append('Email', data.Email)
  formData.append('UrlWebsite', data.UrlWebsite)
  formData.append('WhoGoTogether', data.WhoGoTogether)
  formData.append('TimeRecomment', data.TimeRecomment)
  formData.append('TimeVisit', data.TimeVisit)
  formData.append('PriceAdv', data.PriceAdv)
  formData.append('Address', data.Address)
  formData.append('Logitude', data.Logitude)
  formData.append('Latitude', data.Latitude)
  formData.append('TypeDestinationId', selectedTypeDes)
  formData.append('ProvinceId', selectedProvince)
  //

  //send api
  const handleSubmit = async () => {
    try {
      const res = await postWithFormData('Destination', formData);
      console.log(res);
    } catch (error) {
      console.log(error);
    }
  };

  //province
  const [province, setProvince] = useState([])
  useEffect(() => {
    const getProvince = async () => {
        try {
            const res = await get('listProvince')
            setProvince([...res])
        }
        catch (error) {
            console.log("Erorr:", error)
        }

    }
    getProvince()
}, [])

console.log("pro",province)

//huyện
// const [dictrict, setDictrict] = useState([])
//   useEffect(() => {
//     const getDictrict = async () => {
//         try {
//             console.log(selectedProvince)
//             const res = await get(`province/${selectedProvince}`)
//             setDictrict([...res])
//         }
//         catch (error) {
//             console.log("Erorr:", error)
//         }

//     }
//     getDictrict()
// }, [selectedProvince])

// console.log("dictrict",dictrict)
//xã
// const [ward, setWard] = useState([])
//   useEffect(() => {
//     const getWard = async () => {
//         try {
//             const res = await get(`dictrict/${selectedDictrict}`)
//             setWard([...res])
//         }
//         catch (error) {
//             console.log("Erorr:", error)
//         }

//     }
//     getWard()
// }, [selectedDictrict])

// console.log("dictrict",selectedDictrict)
// console.log("ward",ward)

  return (
    <div className="addDestinationPage">
      <Navbar openLogin={handleLogin} openRegister={handleRegister} openSearchForm={toggleForm} />
      <>
        {openLogin ? <Login btnClose={handleLogin} /> : ''}
        {openRegister ? <Register btnClose={handleRegister} /> : ''}
      </>
      {openSearchForm && (
        <Search toggleOutsideForm={toggleForm} />
      )}
      <BlogHeader placeholder="Tên địa điểm" onCoverPhotoChange={setPhoto} onTitleChange={setTitle} title={title} />
      <div className="secContainer">
        <div className="desScriptDiv itemDiv">
          <div className="desScript">
            <textarea
              name="ShortDecription"
              rows="4"
              placeholder="Giới thiệu ngắn ..."
              className="form-control travelBlogDescription bar-10 bn card6 p-15 resize-none w-fit h-inherit bn fs-18 bar-2"
              onChange={e => handleOnChange(e)}
              value={data.ShortDecription}
            ></textarea>
          </div>
        </div>
        <BlogQuill setContent={setContent} />
        <div className='itemContent'>
          <label htmlFor="selectBox" className='select-label'>Địa điểm này là:</label>
          <select className='select-box' id="selectBox" value={selectedOption} onChange={handleOptionChange}>
            <option className='selected-option' value="0">Tỉnh</option>
            <option className='selected-option' value="1">Thành phố</option>
            <option className='selected-option' value="2">Địa điểm cụ thể</option>
          </select>
        </div>
        <div className='itemContent'>
          <label htmlFor="selectBox" className='select-label'>Loại hình địa điểm:</label>
          <select className='select-box' id="selectBox" value={selectedTypeDes} onChange={handleTypeDesChange}>
            <option className='selected-option' value="1">Danh lam - Thắng cảnh</option>
            <option className='selected-option' value="2">Nhà hàng - Khách sạn</option>
          </select>
        </div>
        <div className="provicec flex itemContent">
        <p className='titleLocation'>Vị trí cụ thể (Option)</p>
        <div>
          <label htmlFor="selectBox" className='select-label'>Tỉnh:</label>
          <select className='select-box' id="selectBox" value={selectedProvince} onChange={handleProvinceChange}>
          {province?.map((pro) => {
              return (
                <option className='selected-option' value={pro.id}>{pro.name}</option>
              )})
          }
          </select>
        </div>
        {/* <div>
          <label htmlFor="selectBox" className='select-label'>Huyện:</label>
          <select className='select-box' id="selectBox" value={selectedDictrict} onChange={handleDictrictChange}>
          {dictrict?.map((pro) => {
              return (
                <option className='selected-option' value={pro.id}>{pro.name}</option>
              )})
          }
          </select>
        </div>
        <div>
          <label htmlFor="selectBox" className='select-label'>Xã:</label>
          <select className='select-box' id="selectBox" value={selectedWard} onChange={handleWardChange}>
          {ward?.map((pro) => {
              return (
                <option className='selected-option' value={pro.id}>{pro.name}</option>
              )})
          }
          </select>
        </div> */}
        </div>
        <div className="submit">
          <button className='btn icon' onClick={handleSubmit}>Đăng bài</button>
        </div>
      </div>
      <Footer />
    </div>
  )
}

export default AddDestination