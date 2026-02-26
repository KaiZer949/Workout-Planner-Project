import React from 'react';
import "/src/Css/Dashboard.css"

const Dashboard = () => {
    return (
        <div className="builder-container">
            <header className="builder-header">
                <input
                    type="text"
                    className="routine-name-input"
                    placeholder="e.g. Monday Upper Body"
                />
                <button className="save-btn">Save Routine</button>
            </header>

            <div className="exercise-list">

                <div className="exercise-card">
                    <div className="card-header">
                        <h3>Bench Press</h3>
                        <button className="remove-btn">×</button>
                    </div>

                    <div className="set-table">
                        <div className="table-header">
                            <span>Set</span>
                            <span>Weight (kg)</span>
                            <span>Reps</span>
                            <span></span>
                        </div>

                        <div className="set-row">
                            <span className="set-number">1</span>
                            <input type="number" placeholder="0" />
                            <input type="number" placeholder="0" />
                            <button className="delete-set">🗑</button>
                        </div>
                    </div>

                    <button className="add-set-btn">+ Add Set</button>
                </div>

                <button className="add-exercise-card">
                    <span className="plus-icon">+</span>
                    Add New Exercise
                </button>
            </div>
        </div>
    );
};

export default Dashboard;