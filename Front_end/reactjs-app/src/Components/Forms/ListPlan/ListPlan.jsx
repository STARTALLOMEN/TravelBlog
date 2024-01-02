import React, { useState, useEffect } from 'react';
import { BsFillCalendar2HeartFill } from 'react-icons/bs';
import { FaPlus, FaLock, FaLockOpen } from 'react-icons/fa';
import NamePlan from '../NamePlan/NamePlan'
import './listPlan.scss'
import request, { getWithToken, postWithFormData } from '../../../utils/request';


function ListPlan(props) {
    const [openNamePlan, setopenNamePlan] = useState(false);

    const handleNamePlan = () => {
        setopenNamePlan(!openNamePlan);
    }

    useEffect(() => {
        const handleOutsideClick = (event) => {
            console.log("event");
            if (!event.target.closest(".formContainer")) {
                props.toggleOutsideForm();
            }
        };
        document.addEventListener('mousedown', handleOutsideClick);

        return () => {
            //toggleOutsideForm();
            document.removeEventListener('mousedown', handleOutsideClick);
        };
    }, []);

    const handlePlanDes = async (id) => {
        try {
            const formData = new FormData();
            formData.append('PlanId', id);
            formData.append('DesId', props.desId);
            const res = await postWithFormData('Plan/addPlanDes', formData);
            console.log(res);
        } catch (error) {

            console.log("-----error:", error);
        }
    };

    const [dataPlan, setDataPlan] = useState([])
    useEffect(() => {
        const getData = async () => {
            try {
                const res = await getWithToken('Plan/get')
                setDataPlan([...res])
            }
            catch (error) {
                console.log("Erorr:", error)
            }

        }
        getData()
    }, [])

    return (
        <div className="formDiv">
            <div className="formContainer">
                <div className="headerForm">
                    <BsFillCalendar2HeartFill className="icon-right iconLarge" />
                    {/* <span>TẠO LẬP CHUYẾN ĐI</span> */}
                    <span>THÊM MỤC YÊU THÍCH</span>
                </div>
                <div className="content">
                    <ul>
                        {dataPlan.map((schedule) => {
                            // if (schedule.status === true) {
                            return (
                                <li key={schedule.id}>
                                    <button onClick={() => handlePlanDes(schedule.id)}>
                                        <FaLock className='icon-right Itemicon' />
                                        {schedule.title}
                                    </button>
                                </li>
                            );
                            // }
                            // else {
                            //     return (
                            //         <li key={schedule.id}>
                            //             <button>
                            //                 <FaLockOpen className='icon-right Itemicon' />
                            //                 {schedule.title}
                            //             </button>
                            //         </li>
                            //     );
                            // }
                        })}
                    </ul>
                </div>
                <div className="createTrip">
                    <button className='createTripButton' onClick={handleNamePlan}>
                        <FaPlus className='icon-right iconLarge' />
                        <span className='taomoi'>Tạo mới</span>
                    </button>
                </div>
                {openNamePlan && <NamePlan toggleOutsideForm={handleNamePlan} desId={props.desId} />}
            </div>
        </div>
    );
};

export default ListPlan;
