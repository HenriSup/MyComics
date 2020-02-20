import React, { Component } from 'react';
import logo from './img/logo.svg';

class HeaderDefault extends Component {

    render() {

        return (
            <header className="App-header">
                <div className="header container-fluid">
                    <div className="logo"><img src={logo} alt="Logo my comics" /></div>
                    <div className="register">
                        <div class="form-group form-header">
                            <div className="login">
                                <span className="text">Login :</span>
                                <input type="text" class="form-control input-header" aria-label="login" aria-describedby="basic-addon1"></input>
                            </div>
                            <div className="password">
                                <span className="text">Password :</span>
                                <input type="password" class="form-control input-header" aria-label="password" aria-describedby="basic-addon1"></input>
                            </div>
                            <button type="submit" className="btn btn-header">Connexion</button>
                        </div>
                        <button className="btn btn-header btn-sub">Inscription</button>
                    </div>
                </div>
            </header>
        );
    }
}

export default HeaderDefault;