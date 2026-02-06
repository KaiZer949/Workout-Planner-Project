import "/src/Css/Signup.css"; 

function Signup() {
    return (
        <div className="signup-container">
            <div className="signup-title">Sign Up</div>

            <div className="input-grp">
                <label>Name</label>
                <input type="text" placeholder="Enter your name" />
            </div>

            <div className="input-grp">
                <label>Username</label>
                <input type="text" placeholder="Choose a username" />
            </div>

            <div className="input-grp">
                <label>Password</label>
                <input type="password" placeholder="Create password" />
            </div>

            <div className="input-grp">
                <label>Confirm Password</label>
                <input type="password" placeholder="Repeat password" />
            </div>

            <span className="switch-link" >
                Already have an account? Login
            </span>

            <button type="submit">Create Account</button>
        </div>
    );
}

export default Signup;