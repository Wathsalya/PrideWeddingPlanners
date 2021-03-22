import React, { Fragment,useState } from "react";
import { Link } from 'react-router-dom';
import {FacebookLoginButton} from 'react-social-login-buttons';
import "./index.css";

import  {ClientLogins}  from '../authorization/authorization';


      const ClientLogin = () => {
        const [formData, setFromData] = useState(
          {
             
              UserName: '',
              Password: '',
           
          });
      
        const { UserName,Password } = formData;
      
        const onChange = e => setFromData({ ...formData, [e.target.name]: e.target.value })
      
       const onSubmit = async e => {
        e.preventDefault();
        console.log("Login On Submit function is Working")
        ClientLogins (UserName,Password);
       };

        return (
          <Fragment>
            <form onSubmit={e => onSubmit(e)} >
            <h3 className="testClass">Log in</h3>

            <div className="form-group">
                <label>User Name</label>
                <input type="text" className="form-control" placeholder="UserName" 
                name="UserName"
                value={UserName}
                onChange={e => onChange(e)}/>
            </div>

            <div className="form-group">
                <label>Password</label>
                <input type="password" className="form-control" placeholder="Enter password" name="Password"
            value={Password}
            onChange={e => onChange(e)}/>
            </div>

            <div className="form-group">
                <div className="custom-control custom-checkbox">
                    <input type="checkbox" className="custom-control-input" id="customCheck1" />
                    <label className="custom-control-label" htmlFor="customCheck1">Remember me</label>
                </div>
            </div>
            <input className="font_size" type="submit" className="btn btn-primary" value="Go to My Account" />
            <Link to="/client-selection">
              <button type="submit" className="btn btn-dark btn-lg btn-block">Submit</button>
            </Link>

               <div className="form-group">
                Or continue with your social account
              </div>
              <FacebookLoginButton classname="mt-1 mb-1"/>
              <div className="forgot-password text-right">
              <Link to="/path">
              sign up
                </Link>
                <span className="p-2">|</span>
                <Link to="/forget-pw">
               Forgot Password
               </Link>
              </div>         
          </form>
          </Fragment>
        );
      };
      export default ClientLogin;