import React, { Fragment,useState } from "react";
import { Link } from 'react-router-dom';

import  {ClientLogins}  from '../authorization/authorization';


      const Verify_Login_2 = () => {
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
            <form onSubmit={e => onSubmit(e)}>

                <h3>Verify Log in</h3>

                <div className="form-group">
                    <label>UserName</label>
                    <input type="text" className="form-control" placeholder="Username"
                     name="UserName"
                     value={UserName}
                     onChange={e => onChange(e)}/> 
                </div>

                <div className="form-group">
                    <label>Password</label>
                    <input type="password" className="form-control" placeholder="Enter password" 
                     name="Password"
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
            </form>
            </Fragment>
        );
      };
      export default Verify_Login_2;
