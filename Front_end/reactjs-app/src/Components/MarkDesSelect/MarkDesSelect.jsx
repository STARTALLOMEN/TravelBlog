import React, { useState, useEffect } from 'react';
import { FaPlus, FaLock, FaLockOpen } from 'react-icons/fa';
import { TiTickOutline } from 'react-icons/ti';
import { BiX } from 'react-icons/bi';
import './markDesSelect.scss'
import request, { postWithFormData, get } from '../../utils/request';

function MarkDesSelect(props) {
  const [selectedDestinations, setSelectedDestinations] = useState([]);

  const handleSelect = (destinationId) => {
    setSelectedDestinations((prevSelectedDestinations) => {
      const isSelected = prevSelectedDestinations.includes(destinationId);

      if (isSelected) {
        return prevSelectedDestinations.filter((id) => id !== destinationId);
      } else {
        return [...prevSelectedDestinations, destinationId];
      }
    });
  };

  const handleSaveDestinations = () => {
    console.log(selectedDestinations);
  };
  const formData = new FormData()
  if (selectedDestinations) {
    for (let i = 0; i < selectedDestinations.length; i++) {
      formData.append('DesId', selectedDestinations[i]);
    }
  }

  //
  //   useEffect(() => {
  //     const handleOutsideClick = (event) => {
  //         console.log("event");
  //         if (!event.target.closest(".marContainer")) {
  //             props.toggleOutsideForm();
  //         }
  //     };
  //     document.addEventListener('mousedown', handleOutsideClick);

  //     return () => {
  //         document.removeEventListener('mousedown', handleOutsideClick);
  //     };
  // }, []);
  //send api
  const handleSubmit = async () => {
    try {
      const res = await postWithFormData('MarkDesAdd', formData);
      console.log(res);
      props.toggleOutsideForm();
      props.reloadData();
    } catch (error) {
      console.log(error);
      props.toggleOutsideForm();
    }
  };


  return (
    <div className="formMarkSelect mark-des-select-overlay ">
      <div className="marContainer mark-des-select-container">
      <button onClick={props.btnClose}><BiX className='close__icon' /></button>
        <div className="destinationMark-list">
          {props.destinationDanhDau.map((destination) => (
            <div className="destination destinationMark" key={destination.id}>
              <img src={destination.imgAvatar} alt={destination.name} />
              <div className="destination-name">{destination.name}</div>
              {/* Add selected icon based on isSelected
              {selectedDestinations.includes(destination.id) ? (
                <button className="select-button" onClick={() => handleSelect(destination.id)}>
                  <FaLock />
                </button>
              ) : (
                <button className="select-button" onClick={() => handleSelect(destination.id)}>
                  <FaLockOpen />
                </button>
              )} */}
            </div>
          ))}
        </div>
        {props.desNonSelect ?
          <div className="destinationMark-list">
            {props.desNonSelect.map((destination) => (
              <div className="destination destinationMark" key={destination.id}>
                <img src={destination.imgAvatar} alt={destination.name} />
                <div className="destination-name">{destination.name}</div>
                {/* Add selected icon based on isSelected */}
                {selectedDestinations.includes(destination.id) ? (
                  <button className="select-button" onClick={() => handleSelect(destination.id)}>
                    <TiTickOutline className='iconMark' />
                  </button>
                ) : (
                  <button className="select-button" onClick={() => handleSelect(destination.id)}>
                    <FaPlus className='iconMark' />
                  </button>
                )}
              </div>
            ))}
          </div> : ''
        }
      </div>
      <button className="btn save-button" onClick={handleSubmit}>
        Xác nhận
      </button>
    </div>
  );
}

export default MarkDesSelect;
