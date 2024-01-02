import './blogContent.scss';
import React from 'react';
function BlogContent(props) {
    return (
        <div>
            <div className="car__photo">
                <ul className='photo__box'>
                    <li>
                        <div className='obj-photo'>
                            <span className="ins">
                                <div className="fileUploader">
                                    <div className="file-container">
                                        <button className='chooseFileButton btn btn-primary btn--m'>
                                            Chọn hình
                                        </button>
                                        <input id='select_images' type="file" accept='.jpg,.png,.jpeg' multiple onChange={props.onFileChange} name='image' />
                                    </div>
                                </div>
                            </span>
                        </div>
                    </li>
                    {
                        props.selectedImages && props.selectedImages.map((image, index) =>
                        (
                            <li className='img-boxitem' key={index}>
                                <button className="btn-close" type='button'
                                    onClick={
                                        (e) => {
                                            props.selectedImages.filter(item => image.index !== item.index)
                                            props.setSelectedImages(props.selectedImages);
                                        }
                                    } />
                                <img src={image} alt="" className='obj-photo photo-avatar' />
                            </li>
                        ))
                    }

                </ul>
            </div>
            <div className="space m"></div>
        </div>
    );
}

export default BlogContent;