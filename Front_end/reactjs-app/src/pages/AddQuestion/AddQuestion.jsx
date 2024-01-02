import React, { useState } from 'react'
import { BsFillPatchQuestionFill, BsFillCameraFill } from 'react-icons/bs'
import Navbar from '../../Components/Navbar/Navbar'
import Question from '../../Components/Question/Question'
import QuestionForm from '../../Components/Forms/QuestionForm/QuestionForm'
import Login from '../../Components/Forms/Login/Login'
import Register from '../../Components/Forms/Register/Register'
import './addquestion.scss'
import Search from '../../Components/Forms/Search/Search'

const AddQuestion = () => {
    const [openLogin, setopenLogin] = useState(false);
    const [openRegister, setopenRegister] = useState(false);
    const [openSearchForm, setopenSearchForm] = useState(false);

    const handleLogin = () => {
        setopenLogin(!openLogin);
    }
    const handleRegister = () => {
        setopenRegister(!openRegister);
    }
    const toggleForm = () => {
        setopenSearchForm(!openSearchForm);
    };

    //open FormQuestion
    const [openQuestionForm, setopenQuestionForm] = useState(false);
    const handleQuestionForm = () => {
        setopenQuestionForm(!openQuestionForm);
    };
    console.log(openQuestionForm)
    return (
        <div className="questionPage">
            <Navbar openLogin={handleLogin} openRegister={handleRegister} openSearchForm={toggleForm} />
            <>
                {openLogin ? <Login btnClose={handleLogin} /> : ''}
                {openRegister ? <Register btnClose={handleRegister} /> : ''}
            </>
            {openSearchForm && (
                <Search toggleOutsideForm={toggleForm} />
            )}
            <div className="secContainer">
                <div className="questionText">
                    <h2 className='title'>HỎI ĐÁP & TƯ VẤN THÔNG TIN DU LỊCH</h2>
                    <p className='subTitle'>Cộng đồng chia sẻ hỏi đáp, tư vấn thông tin & kinh nghiệm du lịch</p>
                </div>
            </div>
            <div className="container">
                <div className="searchDiv flex">
                    <img className="avatar" src="https://media.gody.vn/images/lao-cai/nha-tho-sapa/10-2016/20161020033948-nha-tho-sapa-gody(9).jpg" alt="User Avatar" />
                    {/* <button className="search" onClick={prop.openSearchForm} > */}
                    <button className="search" onClick={handleQuestionForm}>
                        <p>Đặt câu hỏi bạn tại đây</p>
                        <div className="icon">
                            <BsFillCameraFill />
                        </div>
                    </button>
                </div>
                {openQuestionForm && (
                    <QuestionForm setopenQuestionForm={setopenQuestionForm} openQuestionForm={openQuestionForm} />
                )}
                <div className="questionNew">
                    <div className="title flex">
                        <BsFillPatchQuestionFill className='icon' />
                        <span>Câu hỏi mới nhất</span>
                    </div>
                    <Question className="itemQues" />
                    <Question />
                    <Question />
                </div>

            </div>
        </div >
    )
}

export default AddQuestion