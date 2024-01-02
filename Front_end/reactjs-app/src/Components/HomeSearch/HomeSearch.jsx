import React from 'react'
import "./homeSearch.scss"
import { GoSearch } from 'react-icons/go'

const HomeSearch = (prop) => {
  return (
    <section className="home">
      <div className="secContainer contanier">
        <div className="homeText">
          <h2 className='title'>Cùng Gody khám phá Việt Nam</h2>
          <p className='subTitle'>Chuyến đi của bạn sẽ trở nên thú vị hơn từ những kinh nghiệm của các Godyer</p>
          <button className="search" onClick={prop.openSearchForm} >
            <p>Bạn muốn đi đâu</p>
            <div className="icon">
              <GoSearch></GoSearch>
            </div>
          </button>
        </div>
      </div>
    </section>
  )
}

export default HomeSearch