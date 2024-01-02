import React, { useState, useEffect } from 'react';
import { Link } from "react-router-dom";
import { AiOutlineHeart, AiOutlineComment } from 'react-icons/ai'
import './duLich.scss'
import request, { get } from '../../utils/request';

function DuLich(props) {
    const [data, setData] = useState([])
    useEffect(() => {
        const getData = async () => {
            try {
                const res = await get(`Destination/${props.desId}/du-lich`)
                setData([...res])
            }
            catch (error) {
                console.log("Erorr:", error)
            }

        }
        getData()
    }, [])
    return (
        <div className="secContainerQues">
            {
                data?.map((travel, index) => {
                    return (
                        <Link to={`/gioi-thieu/${travel.id}`} state={travel.id}>
                            <div className="question dulich">
                                <div className="itemDivQues">
                                    <img className="avatarCover" src={travel.imgAvatar} alt="Ảnh du lịch" />
                                </div>
                                <div className="div">
                                    <h2>{travel.name}</h2>
                                    <div className="text-container itemDivQues">
                                        <span className="content ">
                                            {travel.shortDecription}
                                        </span>
                                    </div>

                                </div>
                            </div>
                        </Link>
                    )
                })
            }
        </div>
    );
};

export default DuLich;