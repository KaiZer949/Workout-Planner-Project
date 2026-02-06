import "/src/Css/Login.css"
//import { useNavigate } from "react-router-dom";
function Login() {

    //const navigate = useNavigate();

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
            <a href="">Don't have an account? Signup</a>
            <button>Login</button>
        </div>
  );
}

export default Login;