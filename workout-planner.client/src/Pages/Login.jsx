import "/src/Css/Login.css"
import Signup from "./Signup"
import { useNavigate } from "react-router-dom";
function Login() {

    const navigate = useNavigate();

    const handleClick = () => {
        navigate('/Signup');
    }

    return (
        <div className="login-container">
            <div className="login-title">Login</div>
            <div className="input-grp">
                <label>Username:</label>
                <input type="text" />
            </div>
            <div className="input-grp">
                <label>Password:</label>
                <input type="password" />
            </div>
            <span className="switch-link" onClick={handleClick}>
                Don't have an account yet? Signup here
            </span>
            <button>Login</button>
        </div>
  );
}

export default Login;