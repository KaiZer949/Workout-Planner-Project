import "/src/Css/Login.css"
import Signup from "./Signup"
import Dashboard from "./Dashboard"
import { useState } from 'react'
//import { useState } from "react"
import { useNavigate } from "react-router-dom";

const Login = () => {

    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const navigate = useNavigate();

    const navigation = () => {
        navigate('/Signup');
    }

    const handleSubmit = async (e) => {        //error showing username, pass and this func never assigned a value....why? missing async keyword.....

        e.preventDefault();

        if (username == "" && password == "") {
            window.alert("Please enter your credentials");
        }

        const url = "https://localhost:7183/api/Login"
        await fetch(url, {

            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },

            body: JSON.stringify({ username, password }),

        });
    }

    return (
        <div className="login-container">
            <div className="login-title">Login</div>
            <form onSubmit={handleSubmit}>
                <div className="input-grp">
                    <label>Username:</label>
                    <input name="username" type="text" onChange={(e) => setUsername(e.target.value)} />
                </div>

                <div className="input-grp">
                    <label>Password:</label>
                    <input name="password" type="password" onChange={(e) => setPassword(e.target.value)} />
                </div>

                <span className="switch-link" onClick={navigation}>
                    Don't have an account yet? Signup here
                </span>

                <button type="submit">Login</button>
            </form>
        </div>
    );
}
export default Login;