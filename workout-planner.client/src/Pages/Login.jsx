import "/src/Css/Login.css"
import Signup from "./Signup"
import { useState } from "react"
import { useNavigate } from "react-router-dom";

function Login() {

    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const navigate = useNavigate();

    const navigation = () => {
        navigate('/Signup');
    }

    const handleSubmit = async () => {
        const response = await fetch("https://localhost:7183/api/Login", {
            method : "POST",
            headers : {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ username, password })

        });
        //if (!response.ok) {return }
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
                <input name = "password" type="password" onChange={(e) => setPassword(e.target.value)} />
            </div>

            <span className="switch-link" onClick={navigation}>
                Don't have an account yet? Signup here
            </span>

            <button>Login</button>
            </form>
        </div>
  );
}

export default Login;