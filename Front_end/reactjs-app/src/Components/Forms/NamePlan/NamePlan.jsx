import React, { useState, useEffect } from 'react'
import { BsHeart } from 'react-icons/bs';
import { FaLock, FaLockOpen } from 'react-icons/fa';
import './namePlan.scss'
import { post, postWithFormData, postWithToken } from '../../../utils/request';

function NamePlan(props) {
  const [planName, setPlanName] = useState('');

  const handlePlanNameChange = (event) => {
    setPlanName(event.target.value);
  };

  //radio 
  const [selectedOption, setSelectedOption] = useState('');

  const handleOptionChange = (event) => {
    setSelectedOption(event.target.value);
  };

  useEffect(() => {
    const handleOutsideClick = (event) => {
      if (!event.target.closest(".formContainerNamePlan")) {
        props.toggleOutsideForm();
        console.log("abc")
      }
    };
    document.addEventListener('mousedown', handleOutsideClick);

    return () => {
      //toggleOutsideForm();
      document.removeEventListener('mousedown', handleOutsideClick);
    };
  }, []);

  //send api
  const handleSubmit = async () => {
    try {
      if (planName.trim() === '') {
        console.log('Title is required.');
        return;
      }
      const data = {
        Title: planName,
        DesId: parseInt(props.desId)
      };
      
      const res = await postWithFormData('Plan/add', data);
      console.log(res);
    } catch (error) {

      console.log("-----error:", error);
    }
  };

  return (
    <div className="formDiv">
      <div className="formContainer formContainerNamePlan">
        <div className="headerForm itemContent">
          <BsHeart className="icon-right iconLarge" />
          <span>TẠO MỤC YÊU THÍCH</span>
        </div>
        <div className="contentRole itemContent">
          <div className="input itemContent">
            <span className='titleItemContent itemContent'>Tên</span>
            <input type="text" placeholder='Gody Trip' value={planName} onChange={handlePlanNameChange}/>
          </div>
          <div className="chooseType">
            <div className='titleContent'>
              <span>Tại sao nên tạo mục yêu thích </span>
            </div>
            <div className='flex-start'>
              {/* <div className='radioInput'>
                <input type="radio"
                  value="private"
                  checked={selectedOption === 'private'}
                  onChange={handleOptionChange}
                />
              </div > */}
              <div className='flex-start item'>
                <FaLock className='icon-right ' />
                <div className='itemContent'>
                  <span className='titleItemContent'>Yêu: </span>
                  <span className='contentspan'>
                    Tạo mục yêu thích ngày hôm nay để lưu giữ những địa điểm bạn muốn đến </span>
                </div>
              </div>
            </div>
            <div className='flex-start item'>
              {/* <div className='radioInput'>
                <input type="radio"
                  value="public"
                  checked={selectedOption === 'public'}
                  onChange={handleOptionChange}
                />
              </div> */}
              <div className='flex-start'>
                <FaLock className='icon-right ' />
                <div className='itemContent'>
                  <span className='titleItemContent'>Thích: </span>
                  <span className='contentspan'>
                  Tạo mục yêu thích ngày hôm nay để bạn không bỏ qua những địa điểm hot, thú vị</span>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="create">
          <button className='createButton' onClick={handleSubmit}>
            <span>Tạo mới</span>
          </button>
        </div>
      </div>
    </div>
  )
}

export default NamePlan