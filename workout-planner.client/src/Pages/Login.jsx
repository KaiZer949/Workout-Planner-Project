import "/src/Css/Login.css"
import Signup from "./Signup"
import Dashboard from "./Dashboard"
//import { useState } from "react"
import { useNavigate } from "react-router-dom";

const Login = () => {

    //const [username, setUsername] = useState("");
    //const [password, setPassword] = useState("");

    const navigate = useNavigate();

    const navigation = () => {
        navigate('/Signup');
    }


    return (
        <div className="login-container">
            <div className="login-title">Login</div>
            <form>
                <div className="input-grp">
                    <label>Username:</label>
                    <input name="username" type="text" />
                </div>

                <div className="input-grp">
                    <label>Password:</label>
                    <input name="password" type="password" />
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