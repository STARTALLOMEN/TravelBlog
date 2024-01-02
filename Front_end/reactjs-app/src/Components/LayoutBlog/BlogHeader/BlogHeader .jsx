import React, { useState, useRef, useEffect } from 'react';
import './blogHeader.scss'
import { BiImageAdd } from 'react-icons/bi'
import { AiFillSetting } from 'react-icons/ai'

function BlogHeader(props){
  const [coverPhoto, setCoverPhoto] = useState(null);
  const fileInputRef = useRef(null);

  const handleFileChange = (event) => {
    const file = event.target.files[0];
    // Kiểm tra định dạng tệp tại đây (nếu cần thiết)

    // Tạo URL đại diện cho ảnh
    const imageUrl = URL.createObjectURL(file);

    // setCoverPhoto(imageUrl);
    setCoverPhoto(imageUrl);
    props.onCoverPhotoChange(file);
  };

  const handleOpenFileInput = () => {
    fileInputRef.current.click();
  };

  // useEffect(() => {
  //   // Gọi hàm onSubmit trong component cha khi có thay đổi của title và coverPhoto
  //   props.onSubmit();
  // }, [props.onSubmit]);

  const handleTitleChange = (event) => {
    props.onTitleChange(event.target.value);
  };

  return (
    <section className="add-cover-photo">
      <div className="image-preview">
        {coverPhoto ? (
          <div className='containerImg'>
            <img src={coverPhoto} alt="Ảnh bìa" />
            <div className="placeholderChange" >
              <div className='changeImg'>
                <AiFillSetting />
                <span onClick={handleOpenFileInput}>Thay đổi ảnh bìa</span>
              </div>
              <input
                ref={fileInputRef}
                type="file"
                accept="image/*"
                onChange={handleFileChange}
                style={{ display: 'none' }}
              />
            </div>
          </div>
        )
          : (
            <div className="placeholderAddImg">
              <div className="selectImg" onClick={handleOpenFileInput}>
                <BiImageAdd className='iconImage' />
                <span >Chọn ảnh bìa</span>
              </div>
              <input
                ref={fileInputRef}
                type="file"
                accept="image/*"
                onChange={handleFileChange}
                style={{ display: 'none' }}
              />
            </div>
          )}
      <div className="titleDiv">
        <div className="title">
          <input type="text" id="form12" className="form-control" placeholder={props.placeholder} 
          onChange={handleTitleChange}
          value={props.title}/>
        </div>
      </div>
      
      </div>
    </section>
  );
};

export default BlogHeader;
