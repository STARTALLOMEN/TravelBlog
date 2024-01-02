import React from 'react';
import './styles.scss';


function ButtonAccess(props) {
    return (
            <button className='access__btn' type='button' onClick={e=>props.onHandleSubmit(e)}  >
                        <b>{props.icon}{props.namebtn}</b>    
            </button>
    );
}

export default ButtonAccess;