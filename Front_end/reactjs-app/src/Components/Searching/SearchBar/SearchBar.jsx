import React, {useState} from 'react'
import { GoSearch } from 'react-icons/go'
import './searchBar.scss'

function SearchBar(props) {
    return (
        <div className="modalSearchBar">
            <div className="inputSearch">
                <GoSearch className="icon searchIcon" />
                <input type="text"
                    placeholder='Đại điểm bạn muốn tìm ?'
                    onChange={props.onChange} />
            </div>
        </div>
    )
}

export default SearchBar