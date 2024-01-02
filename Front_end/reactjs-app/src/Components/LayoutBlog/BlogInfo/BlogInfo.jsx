import React, { useState, useEffect } from 'react';
import BlogQuill from '../BlogQuill/BlogQuill';
import './blogInfo.scss';
// import Add from '../Add/Add';
import request, { postWithFormData, get } from '../../../utils/request';


function BlogInfo(props) {
  const [totalDays, setTotalDays] = useState('');
  const [cost, setCost] = useState('');
  const [totalDaysError, setTotalDaysError] = useState('');
  const [content, setContent] = useState("");
  const [costError, setCostError] = useState('');
  const [listselectedDestination, setListSelectedDestination] = useState([]);

  const [data, setData] = useState({
    ShortDecription: '',
    DateStart: '',
  })
  const handleOnChange = (e) => {
    setData({ ...data, [e.target.name]: e.target.value })
  }
  const formData = new FormData()
  formData.append('ImgAvatarFile', props.photo);
  formData.append('Title', props.title)
  formData.append('ShortDecription', data.ShortDecription)
  formData.append('Content', content)
  formData.append('DateStart', data.DateStart)
  formData.append('TotalDate', totalDays)
  formData.append('Cost', cost)

  if (listselectedDestination) {
    for (let i = 0; i < listselectedDestination.length; i++) {
      formData.append('DesId', listselectedDestination[i].id);
    }
  }

  const handleTotalDaysChange = (event) => {
    const value = parseInt(event.target.value);
    if (value < 0) {
      setTotalDaysError('Tổng số ngày lớn hơn hoặc bằng 0.');
    } else {
      setTotalDaysError('');
    }
    setTotalDays(value);
  };

  const handleCostChange = (event) => {
    const value = parseInt(event.target.value);
    if (value < 0) {
      setCostError('Chi phí chuyến đi lớn hơn hoặc bằng 0.');
    } else {
      setCostError('');
    }
    setCost(value);
  };

  //send api
  const handleSubmit = async () => {
    try {
      console.log("handleSubmit1")
      const res = await postWithFormData('Blog', formData);
      console.log("handleSubmit2")
      console.log(res);
    } catch (error) {
      console.log(error);
    }
  };

  //handle click des Tag

  const [searchValue, setSearchValue] = useState(null);
  const [destinationResults, setDestinationResults] = useState([]);
  useEffect(() => {
    const fetchData = async () => {
      try {
        const destinationRes = await get(`Destination/${searchValue}`);
        setDestinationResults(destinationRes);
      } catch (error) {
        console.log('Error:', error);
      }
    };

    fetchData();
  }, [searchValue]);

  const handleInputChange = (event) => {
    setSearchValue(event.target.value);
  };

  const handleDestinationClick = (destination) => {
    // setSelectedDestination(destination);
    if (!listselectedDestination.some((item) => item.id === destination.id)) {
      setListSelectedDestination([...listselectedDestination, destination]);
      setDestinationResults([]);
    }
  };
  return (
    <section className="blogInfo">
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
        <div className="infoAdd itemDiv">
          <div className="info-item form-group info-item">
            <input type="date" className="form-control" name="DateStart"
              value={data.DateStart}
              onChange={e => handleOnChange(e)}
            />
            <i className="fas fa-calendar"></i>
          </div>
          <div className="info-item form-group info-item">
            <input
              className="form-control"
              type="number"
              placeholder="Tổng số ngày"
              value={totalDays}
              onChange={handleTotalDaysChange}
            />
            <i className="fas fa-clock"></i>
            {totalDaysError && <div className="error-message alert alert-danger">{totalDaysError}</div>}
          </div>
          <div className="info-item form-group info-item">
            <input
              className="form-control"
              type="number"
              placeholder="Chi phí chuyến đi"
              value={cost}
              onChange={handleCostChange}
            />
            <i className="fas fa-money-bill"></i>
            {costError && <div className="error-message alert alert-danger">{costError}</div>}
          </div>
        </div>
        <div className="grid-blog">
          <div className="inputBlogDiv">
            <input className="form-control inputTag" type="text" placeholder="Nhập tag tìm kiếm" onChange={handleInputChange} />
            <i className="fas fa-search"></i>
          </div>
          <div className="searchResult">
            {destinationResults.map((destination) => (
              <span key={destination.id} onClick={() => handleDestinationClick(destination)} className='desResult'>
                # {destination.name}
              </span>
            ))}
          </div>
          <div className="metadata flex itemContent">
            {listselectedDestination.map((location) => (
              <div className="locationDiv" key={location.id}>
                <span className="location">{location.name + location.id}</span>
                <button className="btn-close" type='button'
                  onClick={
                    (e) => {
                      const newLocaTags = listselectedDestination.filter((_) => _.id !== location.id);
                      setListSelectedDestination(newLocaTags);

                    }
                  } />
              </div>
            ))}
          </div>

        </div>
        <BlogQuill setContent={setContent} />
        <div className="submit">
          <button className='btn icon' onClick={handleSubmit}>Đăng bài</button>
        </div>
      </div>
    </section>
  )
}

export default BlogInfo
