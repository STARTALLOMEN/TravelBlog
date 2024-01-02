import './search.scss'
import 'bootstrap/dist/css/bootstrap.min.css';
import React, { useRef, useEffect, useState } from 'react'
import SearchBar from '../../Searching/SearchBar/SearchBar'
import { FiMapPin } from 'react-icons/fi'
import { BsFileText, BsPeople } from 'react-icons/bs'
import { CiImageOn } from 'react-icons/ci'
import { Link } from "react-router-dom";
import request, { get } from '../../../utils/request';


function Search(props) {
  useEffect(() => {
    const handleOutsideClick = (event) => {
      console.log("event");
      if (!event.target.closest(".searchBarContainer")) {
        props.toggleOutsideForm();
      }
    };
    document.addEventListener('mousedown', handleOutsideClick);

    return () => {
      //toggleOutsideForm();
      document.removeEventListener('mousedown', handleOutsideClick);
    };
  }, []);

  const [searchValue, setSearchValue] = useState('');
  const [destinationResults, setDestinationResults] = useState([]);
  useEffect(() => {
    const fetchData = async () => {
      try {
        const destinationRes = await get(`Destination/${searchValue}`);
        setDestinationResults(destinationRes);

        // const blogRes = await getBlogByNameDestination(searchValue);
        // setBlogResults(blogRes.data);
      } catch (error) {
        console.log('Error:', error);
      }
    };

    fetchData();
  }, [searchValue]);

  const handleInputChange = (event) => {
    setSearchValue(event.target.value);
  };

  console.log(destinationResults);
  return (
    <div className="searchForm" id='searchForm'>
      <div className="searchBarContainer">
        <SearchBar onChange={handleInputChange} />
        <div className="searchResult">
          <div className="mainResult">
            {destinationResults.map((result) => (
              <Link key={result.id} to={`/gioi-thieu/${result.id}`}>
                <div className="resultItem d-flex ai-center ps-relative py-12 bb bc-eleventh">
                  <div className="iconDiv bar-circle ba bc-eleventh d-flex ai-center jc-center p-10 mr-15 ">
                    <FiMapPin className="icon locationIcon"></FiMapPin>
                  </div>
                  <div className="itemContent fl-1">
                    <p className="fw-500 fs-16 m-0 tt-capitalize fc-nineth mb-2">
                      {result.name}
                    </p>
                    <p class="fs-14 m-0 tt-capitalize fc-sixth">
                      Việt nam
                    </p>
                  </div>

                </div>
              </Link>
            ))}
            {/* Blog */}
            {/* <Link to="/">
              <div className="resultItem d-flex ai-center ps-relative py-12 bb bc-eleventh">
                <div className="iconDiv bar-circle
                    ba
                    bc-eleventh
                    d-flex
                    ai-center
                    jc-center
                    p-10
                    mr-15">

                  <BsFileText className="icon blogIcon" />
                </div>
                <div className="itemContent fl-1">
                  <p className="fw-500 fs-16 m-0 tt-capitalize fc-nineth mb-2">
                    Blog du lịch Đà Nẵng
                  </p>
                  <p class="fs-14 m-0 tt-capitalize fc-sixth">
                    Việt nam
                  </p>
                </div>

              </div>
            </Link> */}
            {/* ImgageShare */}
            {/* <Link to="/">
              <div className="resultItem d-flex ai-center ps-relative py-12 bb bc-eleventh">
                <div className="iconDiv bar-circle
                    ba
                    bc-eleventh
                    d-flex
                    ai-center
                    jc-center
                    p-10
                    mr-15">

                  <CiImageOn className="icon imageIcon" />
                </div>
                <div className="itemContent fl-1">
                  <p className="fw-500 fs-16 m-0 tt-capitalize fc-nineth mb-2">
                    Hình ảnh du lịch Đà Nẵng
                  </p>
                  <p class="fs-14 m-0 tt-capitalize fc-sixth">
                    Việt nam
                  </p>
                </div>

              </div>
            </Link> */}
            {/* Question */}
            {/* <Link to="/">
              <div className="resultItem d-flex ai-center ps-relative py-12 bb bc-eleventh">
                <div className="iconDiv bar-circle
                    ba
                    bc-eleventh
                    d-flex
                    ai-center
                    jc-center
                    p-10
                    mr-15">

                  <BsPeople className="icon imageIcon" />
                </div>
                <div className="itemContent fl-1">
                  <p className="fw-500 fs-16 m-0 tt-capitalize fc-nineth mb-2">
                    Hỏi đáp du lịch Đà Nẵng
                  </p>
                  <p class="fs-14 m-0 tt-capitalize fc-sixth">
                    Việt nam
                  </p>
                </div>

              </div>
            </Link> */}
          </div>
          <div className="footer">
          </div>
        </div >
      </div>
    </div>
  )
}

export default Search