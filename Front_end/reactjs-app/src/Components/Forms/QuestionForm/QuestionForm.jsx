import React, { useState, useEffect } from 'react'
import { BsImage } from 'react-icons/bs'
import './questionForm.scss'
import request, { postWithFormData, get } from '../../../utils/request';


function QuestionForm(props) {
    const [value, setValue] = useState('');
    const [listselectedDestination, setListSelectedDestination] = useState([]);
    const [searchValue, setSearchValue] = useState(null);
    const [destinationResults, setDestinationResults] = useState([]);

    const autoResize = () => {
        const textarea = document.getElementById('myTextarea');
        textarea.style.height = 'auto';
        textarea.style.height = `${textarea.scrollHeight}px`;
    };

    const handleChange = (event) => {
        setValue(event.target.value);
        autoResize();
    };

    //add photo
    const [images, setImages] = useState([]);
    const onFileChange = async (e) => {
        const selectedFiles = Array.from(e.target.files);
        console.log("selectedFiles: ", selectedFiles)
        setImages([...images, ...selectedFiles]);
    }

    //
    const listLocation = [
        {
            id: 1,
            name: "Đà Nẵng",
        },
        {
            id: 2,
            name: "Quảng Nam",
        },
        {
            id: 3,
            name: "Bình Định",
        },
        {
            id: 4,
            name: "Đà Nẵng",
        },
        {
            id: 5,
            name: "Quảng Nam",
        },
        {
            id: 6,
            name: "Quảng Trị Quảng Trị Quảng Trị",
        },
        {
            id: 7,
            name: "Quảng Trị",
        },
        {
            id: 8,
            name: "Đà Nẵng",
        },
        {
            id: 9,
            name: "Quảng Nam",
        },
        {
            id: 10,
            name: "Quảng Trị Quảng Trị Quảng Trị",
        },
    ]

    const [locaTags, setLocaTags] = useState(listLocation)

    //openOrcloseQuestionForm
    useEffect(() => {
        const handleOutsideClick = (event) => {
            console.log("event");
            if (!event.target.closest(".questionContainer")) {
                props.setopenQuestionForm();
            }
        };
        document.addEventListener('mousedown', handleOutsideClick);

        return () => {
            document.removeEventListener('mousedown', handleOutsideClick);
        };
    }, []);

    //
    const [data, setData] = useState({
        Title: '',
    })
    const handleOnChange = (e) => {
        setData({ ...data, [e.target.name]: e.target.value })
    }
    const formData = new FormData()
    formData.append('Title', data.Title);
    formData.append('Content', value)
    if (images) {
        for (let i = 0; i < images.length; i++) {
            formData.append('ImageQuestionsFile', images[i]);
        }
    }
    if (listselectedDestination) {
        for (let i = 0; i < listselectedDestination.length; i++) {
            formData.append('DesId', listselectedDestination[i].id);
        }
    }
    //send api
    const handleSubmit = async () => {
        try {
            console.log(formData.get('Title'))
            console.log(formData.get('Content'))
            console.log(formData.get('ImageQuestionsFile'))
            console.log(images)
            const res = await postWithFormData('Question', formData);
            console.log(res);
        } catch (error) {

            console.log("-----error:", error);
        }
    };

    //


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
        if (!listselectedDestination.some((item) => item.id === destination.id)) {
            setListSelectedDestination([...listselectedDestination, destination]);
            setDestinationResults([]);
        }
    };

    return (
        // <div className={`questionForm ${props.openQuestionForm ? 'active' : ''}`}>
        <div className="questionForm">
            <div className={`questionContainer ${props.openQuestionForm ? 'active' : ''}`}>
                <div className="headerDiv flex-start itemContent">
                    <img src="https://media.gody.vn/images/lao-cai/nha-tho-sapa/10-2016/20161020033948-nha-tho-sapa-gody(9).jpg" alt="" />
                    <div className="contentDiv">
                        <div className="title ">
                            <input className='itemContentDiv' type="text" placeholder='Đặt câu hỏi của bạn tại đây'
                                name='Title'
                                onChange={e => handleOnChange(e)}
                                value={data.Title}
                            />
                        </div>
                        <div className="content ">
                            {/* <textarea id="myTextarea" className='itemContentDiv' type="text" placeholder='Nội dung chi tiết ...' oninput={autoResize()} /> */}
                            <textarea id="myTextarea" value={value}
                                onChange={handleChange}
                                rows={1}
                                placeholder='Nội dung chi tiết ...'
                            ></textarea>
                        </div>
                    </div>
                </div>
                <div className="listImage itemContent">
                    <ul className='photo__box'>
                        {
                            images.map((image, index) =>
                            (
                                <li className='img-boxitem ' key={index}>
                                    <button className="btn-close" type='button'
                                        onClick={
                                            (e) => {
                                                const newSelectedImages = images.filter((_, i) => i !== index);
                                                setImages(newSelectedImages);

                                            }
                                        } />
                                    <img src={URL.createObjectURL(image)} alt="" className='obj-photo photo-avatar' />
                                </li>
                            ))
                        }
                    </ul>
                </div>
                <div className="destinaTag itemContent">
                    <input type="text" placeholder='Tag(địa điểm liên quan)' onChange={handleInputChange} />
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
                            <span className="location">{location.name}</span>
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
                <div className="fileContainer itemContent" for="select_images">
                    <BsImage className='iconImage' />
                    Chọn hình
                    <input className='inputChooseFile' id='select_images' type="file" accept='.jpg,.png,.jpeg' multiple onChange={onFileChange} name='image' />
                </div>
                <div className="create">
                    <button className='btn btnSubmit' onClick={handleSubmit}>
                        <span>Đăng</span>
                    </button>
                </div>
            </div>
        </div>
    )
}

export default QuestionForm