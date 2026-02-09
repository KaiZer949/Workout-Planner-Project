import React from 'react';
import { FaSearch, FaBell, FaUserCircle } from 'react-icons/fa';
import '/src/Css/Topbar.css';

const Topbar = () => {
    return (
        <header className="topbar">
            <div className="search-box">
                <FaSearch />
                <input type="text" placeholder="Search your workouts..." />
            </div>
            <div className="topbar-actions">
                <FaBell className="action-icon" />
                <div className="profile">
                    <span>John Doe</span>
                    <FaUserCircle className="profile-icon" />
                </div>
            </div>
        </header>
    );
};

export default Topbar;