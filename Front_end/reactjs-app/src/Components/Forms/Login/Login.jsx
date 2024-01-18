
import './login.scss';
import { BiLock, BiUserCheck } from "react-icons/bi";
import { BiX } from "react-icons/bi";
import ButtonAccess from '../ButtonAccess/ButtonAccess';
import * as yup from 'yup';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import { useState } from 'react';

//import {useNavigate} from 'react-router-dom'
import request from '../../../utils/request';
function Login(props) {

    const handleCloseModal = () => {
        const modalElement = document.getElementsByClassName('modal__container')[0];
        modalElement.classList.add('hidden');
    }
    const schema = yup.object().shape({
        userName: yup.string().required('You have to enter your username!'),
        password: yup.string().required('You have to enter your password!'),
    });
    const { register, handleSubmit, formState: { errors } } = useForm({ resolver: yupResolver(schema) });
    const [isLogin, setIsLogin] = useState(null)
    const [email, setEmail] = useState('');
    const [showForgotPasswordForm, setShowForgotPasswordForm] = useState(false);
    const handleForgotPassword = () => {
        setShowForgotPasswordForm(true);
      };
    
      const handleResetPassword = (event) => {
        event.preventDefault();
        // Add your reset password logic here
        try {
            // Replace with your actual API endpoint
            const res = request.post('Auth/forgotPassword', { email });
            if (res.status === 200) {
              alert('An email has been sent to your email address');
              setShowForgotPasswordForm(false);
              setEmail('');
            } else {
              alert('Something went wrong');
            }
          } catch (error) {
            console.error(error);
          }
      };
    
      const handleEmailChange = (event) => {
        setEmail(event.target.value);
      };
    const onSubmit = async (data) => {
        // try {
        const dataUser = {
            userName: data.userName,
            password: data.password,
        }
        const res = await request.post('Auth/login', dataUser)
        localStorage.setItem('userToken', res.data.accessToken)
        handleCloseModal();
        setIsLogin(null)
        window.location.reload()
        console.log("user", res.data)
        // }
        // catch (error) {
        //     console.log('Something error!');
        // }
    }
    return (
        <div className="modal__container">
            <div className="layout__container">
                <div className="layout__container-wrapper">
                    <button onClick={props.btnClose}><BiX className='close__icon' /></button>
                    <div className="layout__header">
                        <h1 className='title__header'>Đăng nhập</h1>
                    </div>
                    <form action="">
                        <div className="wrapper">

                            <div className="input__wrapper">
                                <BiUserCheck width={35} size={35} />
                                <input type="text" {...register('userName')} placeholder='Your username' id='userName' />
                            </div>
                            {errors.userName ? <p className='error_messages'>Vui lòng nhập username!</p> : ''}
                            <p className='error_messages'></p>
                            <div className="input__wrapper">
                                <BiLock width={27} size={27} />
                                <input type="password" {...register('password')} placeholder='Your password' id='password' />
                            </div>
                            {errors.password ? <p className='error_messages'>Vui lòng nhập password!</p> : ''}
                            {isLogin ? <p className='error_messages'>{isLogin}</p> : ''}
                        </div>
                        <p><button onClick={handleForgotPassword}>Quên mật khẩu?</button></p>
                        {showForgotPasswordForm && (
                            <form onSubmit={handleResetPassword}>
                                <input type="email" placeholder="Email" value={email} onChange={handleEmailChange} />
                                <button type="submit">Gửi email</button>
                            </form>
                        )}
                        <ButtonAccess namebtn='ĐĂNG NHẬP' onHandleSubmit={handleSubmit(onSubmit)} />

                    </form>
                </div>
            </div>
        </div>
    );
}

export default Login;