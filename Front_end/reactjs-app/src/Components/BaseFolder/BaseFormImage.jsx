import React from 'react';
import './baseFormImage.scss';

function BaseFormImage(props) {
    const onFileChange = async (e) => {
        // const selectedFiles = e.target.files;
        const selectedFiles = Array.from(e.target.files);
        console.log("selectedFiles: ", selectedFiles)
        props.setImages([...props.images,...selectedFiles]);
    }

    return (
        <div className='itemDiv'>
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
                                        <input id='select_images' type="file" accept='.jpg,.png,.jpeg' multiple onChange={onFileChange} name='image' />
                                    </div>
                                </div>
                            </span>
                        </div>
                    </li>
                    {
                        // props.selectedImages && props.selectedImages.map((image, index) =>
                        // (
                        //     <li className='img-boxitem' key={index}>
                        //         <button className="btn-close" type='button'
                        //             onClick={
                        //                 (e) => {
                        //                     console.log(props.images)
                        //                     const images = props.images.filter((item, i) => i !== index)
                        //                     props.setImages(images);
                        //                     const selectedImages = props.selectedImages.filter((item, i) => i !== index)
                        //                     props.setSelectedImages(selectedImages);

                        //                 }
                        //             } />
                        //         <img src={image} alt="" className='obj-photo photo-avatar' />
                        //     </li>
                        // ))
                        
                        props.images.map((image, index) =>
                        (
                            <li className='img-boxitem' key={index}>
                                <button className="btn-close" type='button'
                                    onClick={
                                        (e) => {
                                            console.log(props.images)
                                            const newSelectedImages = props.images.filter((_, i) => i !== index);
                                            props.setImages(newSelectedImages);

                                        }
                                    } />
                                <img src={URL.createObjectURL(image)} alt="" className='obj-photo photo-avatar' />
                            </li>
                        ))
                    }

                </ul>
            </div>
            <div className="space m"></div>
        </div>
    );
}

export default BaseFormImage;