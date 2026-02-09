import React from 'react';
import {
    FaHome,
    FaChartLine,
    FaWallet,
    FaUserCog,
    FaSignOutAlt
} from 'react-icons/fa';
import '/src/Css/Sidebar.css';

const Sidebar = () => {
    return (
        <aside className="sidebar">
            <div className="sidebar-logo">
                <div className="logo-icon">G</div>
                <span className="logo-text">Workout Tracker</span>
            </div>

            <nav className="sidebar-menu">
                <p className="menu-label">Main Menu</p>
                <ul>
                    <li className="menu-item active">
                        <FaHome className="icon" />
                        <span>Dashboard</span>
                    </li>
                    <li className="menu-item">
                        <FaChartLine className="icon" />
                        <span>Workouts</span>
                    </li>
                </ul>

                <p className="menu-label">Account</p>
                <ul>
                    <li className="menu-item">
                        <FaUserCog className="icon" />
                        <span>Profile</span>
                    </li>
                    <li className="menu-item logout">
                        <FaSignOutAlt className="icon" />
                        <span>Logout</span>
                    </li>
                </ul>
            </nav>
        </aside>
    );
};

export default Sidebar;