import React, { Component } from 'react'
import { Row, Col} from 'antd'


// Importation de style
import 'antd/dist/antd.css'

const Tuiles = ({ name }) => {

    return(
        <div className="category col-md-3">
            <div className="speech">
                <img src={`${process.env.PUBLIC_URL}/img/category/logo-${name}.png`} alt="" />
            </div>
        </div>

    )
}

export default Tuiles;