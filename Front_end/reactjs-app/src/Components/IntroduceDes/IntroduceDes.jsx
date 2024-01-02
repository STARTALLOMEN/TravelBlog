import React, { useState, useEffect } from 'react';
import './introduceDes.scss';
import request, { get } from '../../utils/request';
import { Link } from 'react-router-dom';
import { BsFillPenFill, BsFillBookmarkHeartFill } from "react-icons/bs";
import ListPlan from '../Forms/ListPlan/ListPlan';

function IntroduceDes(props) {
  const [blogData, setBlogData] = useState(null);
  const [desData, setDesData] = useState(null);
  const [openLike, setopenLike] = useState(false);
  const handleLike = () => {
    setopenLike(!openLike);
  };


  useEffect(() => {
    if (props.desId != null) {
      const getData = async () => {
        try {
          const res = await get(`Destination/get-dentination/${props.desId}`);
          setDesData(res);
        } catch (error) {
          console.log("Error:", error);
        }
      };

      getData();
    }
  }, [props.desId]);

  useEffect(() => {
    if (props.blogId != null) {
      const getData = async () => {
        try {
          const res = await get(`Blog/${props.blogId}/blogDetail`);
          setBlogData(res);
        } catch (error) {
          console.log("Error:", error);
        }
      };

      getData();
    }
  }, [props.blogId]);

  const renderContent = () => {
    if (desData) {
      return (
        <div>
          <h2>{desData.name}</h2>
          <div className="btn btnReview">
            <Link to={`/diem-den/${props.desId}/review`} state={props.desId}>
              <BsFillPenFill className='iconReview' />
              <span className="spanReview">Viết Review</span>
            </Link>
          </div>
          <div className="btn btnLike" onClick={handleLike}>
            {/* <Link to={'/yeu-thich'} state={props.desId}> */}
              <BsFillBookmarkHeartFill className='iconReview' />
              <span className="spanReview">Thêm vào mục yêu thích</span>
            {/* </Link> */}
          </div>
          {openLike && (
            <ListPlan toggleOutsideForm={handleLike} desId={props.desId}/>
          )}
          <div className='shortScripts'>
            <p>{desData.shortDecription}</p>
          </div>
          <div dangerouslySetInnerHTML={{ __html: desData.content }} />
        </div>
      );
    }

    if (blogData) {
      return (
        <div>
          <h2>{blogData.title}</h2>
          <div className='shortScripts'>
            <p>{blogData.shortDescription}</p>
          </div>
          <div dangerouslySetInnerHTML={{ __html: blogData.content }} />
        </div>
      );
    }

    return null;
  };

  return (
    <div className="introduce-des">
      {renderContent()}
    </div>
  );
}

export default IntroduceDes;
