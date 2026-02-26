import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './App.css'
import Login from "./Pages/Login"
import Signup from "./Pages/Signup"
import Dashboard from './Pages/Dashboard';
import Sidebar from './Components/Sidebar'
import Topbar from './Components/Topbar'


function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/login" element={<Login/>}/>
                <Route path="/signup" element={<Signup />} />


                <Route
                    path="*"    
                    element={
                        <div className="app-layout">
                            <Sidebar />
                            <div className="main-viewport">
                                <Topbar />
                                <div className="page-content">
                                    <Routes>
                                        <Route path="/dashboard" element={<Dashboard />} />
                                    </Routes>
                                </div>
                            </div>
                        </div>
                    }
                />
            </Routes>
        </BrowserRouter>
  );
}

export default App
