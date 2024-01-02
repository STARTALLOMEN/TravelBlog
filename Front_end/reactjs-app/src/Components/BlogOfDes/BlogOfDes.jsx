import React, { useState, useEffect } from 'react';
import './blogOfDes.scss'
import { BsArrowRightShort } from 'react-icons/bs'
import request, { get } from '../../utils/request';
import { Link } from "react-router-dom";

function BlogOfDes (props){
    const [data, setData] = useState([])
    useEffect(() => {
        const getData = async () => {
            try {
                const res = await get(`Blog/Destination/${props.desId}`)
                setData([...res])
            }
            catch (error) {
                console.log("Erorr:", error)
            }

        }
        getData()
    }, [])

    return (
        <section className="blog">
            <div className="secBlogDes">
                <div className="mainContainer grid">
                    {data.map((post) => {
                        return (
                            <Link to={`/blog/${post.id}/`} state={post.id} className="navLink">
                            <div key={post.id} className="singlePost gridBlogDes">
                                <div className="imgDiv">
                                    <img src={post.imgAvatar} alt="Image Name" />
                                </div>
                                <div className="postDetails">
                                    <h3>{post.title}</h3>
                                    <p className='text-container'>{post.shortDecription}</p>
                                </div>
                                <a href="#" className="flex">
                                    Đọc thêm
                                    <BsArrowRightShort className="icon"></BsArrowRightShort>
                                </a>
                            </div>
                            </Link>
                        )
                    })}
                </div>
            </div>
        </section>
    )
}

export default BlogOfDes