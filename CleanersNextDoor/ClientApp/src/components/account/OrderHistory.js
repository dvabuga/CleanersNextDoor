﻿import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class OrderHistory extends Component {
    constructor(props) {
        super(props)
    }

    componentDidMount() {

    }

    render() {
        return (
            <div>
                <header className="bg-primary py-3 mb-5">
                    <div className="container h-100">
                        <div className="row h-100 align-items-center">
                            <div className="col-lg-12">
                                <h1 className="display-4 text-white mt-5 mb-2">
                                    Order History
                                </h1>
                                <p className="lead text-white-50">
                                    You can always access your past orders on your account.
                                </p>
                                <Link to="/account" className="btn btn-success btn-lg">My Account</Link>
                            </div>
                        </div>
                    </div>
                </header>
                <div className="container">
                    <div className="my-3">
                        <h3>Orders</h3>

                    </div>
                </div>
            </div>
        )
    }
}