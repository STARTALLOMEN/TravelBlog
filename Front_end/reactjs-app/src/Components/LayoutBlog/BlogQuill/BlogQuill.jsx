import React, { useState } from 'react'
import ReactQuill from "react-quill";
import "react-quill/dist/quill.snow.css";
import './blogQuill.scss'

function BlogQuill(props) {
    const [body, setBody] = useState("");
    const handleBody = e =>{
        // console.log(e)
        setBody(e)
        props.setContent(e)
        // props.setContenBlog(e)
    }
    return (
        <div className="blogQuill itemDiv">
            <ReactQuill
                placeholder='Viết gì đó ở đây ...'
                modules={BlogQuill.modules}
                formats={BlogQuill.formats}
                onChange={handleBody}
                value={body}
            // placeholder={this.props.placeholder}
            />
        </div>
    )
}
BlogQuill.modules = {
    toolbar: [
        [{ header: "1" }, { header: "1" }, { header: [3, 4, 5, 6] }, { font: [] }],
        [{ size: [] }],
        ["bold", "italic", "underline", "strike", "blockquote"],
        [{ list: "ordered" }, { list: "bullet" }],
        ["link", "image", "video"],
        ["clean"],
        ["code-block"],

    ],

};

BlogQuill.formats = [
    'header',
    'font',
    'size',
    'bold', 'italic', 'underline', 'strike',
    'list', 'bullet',
    'link', 'image', 'video',
    'clean',
    'code-block',
    // 'image', 'video', 'file', 'link',"code-block", "video", "blockquote", "clean"
];
export default BlogQuill