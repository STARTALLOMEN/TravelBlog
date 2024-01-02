import React, { useState, useEffect } from 'react';
import MarkDesSelect from '../../Components/MarkDesSelect/MarkDesSelect'
import './MarkDestination.scss'; // Import the SCSS file
import { AiOutlinePlusCircle } from 'react-icons/ai'
import request, { get, getWithToken, postWithFormData } from '../../utils/request';

function MarkDestination() {
    const [selectedProvinceDestinations, setSelectedProvinceDestinations] = useState([]);
    const [destinationDanhDau, setDestinationDanhDau] = useState([]);
    const [desNonSelect, setDesNonSelect] = useState([]);

    useEffect(() => {
        const filteredDesNonSelect = selectedProvinceDestinations.filter(
          (destination) => !destinationDanhDau.some((item) => item.id === destination.id)
        );
        setDesNonSelect(filteredDesNonSelect);
    }, [selectedProvinceDestinations, destinationDanhDau]);


    const [openMarkDesSelect, setopenMarkDesSelect] = useState(false);
    const handleMarkDesSelect = () => {
        setopenMarkDesSelect(!openMarkDesSelect);
    };


    const [dataMark, setdataMark] = useState([])
    useEffect(() => {
        const getData = async () => {
            try {
                const res = await getWithToken('Destination/danh-dau')
                setdataMark([...res])
            }
            catch (error) {
                console.log("Erorr:", error)
            }

        }
        getData()
    }, [])



    const handleMarkDestination = async (province) => {
        try {
            console.log(province);
            console.log(province.provinceId);
            const res = await get(`province/${province.provinceId}/destination`);
            setSelectedProvinceDestinations(res);

            // Lọc danh sách Destination đã được đánh dấu của tỉnh provinceId
            const danhDauDestinations = province.destinations;
            setDestinationDanhDau(danhDauDestinations);
            setopenMarkDesSelect(!openMarkDesSelect);
        } catch (error) {
            console.log('Error:', error);
        }
    };

    //reload lại data sau khi call api MarkDesSelect thành công
    const reloadData = async () => {
        try {
          const res = await getWithToken('Destination/danh-dau');
          setdataMark([...res]);
        } catch (error) {
          console.log("Error:", error);
        }
      };
    return (
        <div className="containerMark">
            <div className="visited-provinces">
                Số tỉnh thành đã đi qua: {dataMark.length > 0 ? dataMark.length : 0}
            </div>

            {dataMark.map((province) => (
                <div className="province" key={province.provinceId}>
                    <div className="infoPro">
                        <img src={province.imageProvince} alt={province.nameProvince} />
                        <div className="province-name">{province.nameProvince}</div>
                        <div className="destination-count">
                            Đã đến: {province.destinations.length > 0 ? province.destinations.length : 0}
                        </div>
                    </div>
                    <div className="destination-list">
                        {province.destinations.map((destination) => (
                            <div className="destination" key={destination.id}>
                                <img src={destination.imgAvatar} alt={destination.name} />
                                <div className="destination-name">{destination.name}</div>
                                <button className="rate-button">Đã để lại dấu chân</button>
                            </div>
                        ))}
                        <div className="destination destinationAdd">
                            <button className="btn btnMarkDesk" onClick={() => handleMarkDestination(province)}>
                                <AiOutlinePlusCircle />
                            </button>
                            <span className='spanMark'>Đánh dấu</span>
                        </div>

                    </div>
                </div>
            ))}
            <button className="add-destination-button">Thêm điểm đến</button>
            {openMarkDesSelect && (
                <MarkDesSelect toggleOutsideForm={handleMarkDesSelect} destinationDanhDau={destinationDanhDau} desOfProvince={selectedProvinceDestinations} desNonSelect={desNonSelect} reloadData={reloadData}/>
            )}
        </div>

    );
};

export default MarkDestination;
