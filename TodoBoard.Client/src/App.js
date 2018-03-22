import React, { Component } from 'react';
import { Grid, Row, Col, Button } from 'react-bootstrap'
import './App.css';

class App extends Component {
    render() {
        return (
            <Grid fluid>
                <Row>
                    <div className="hidden"></div>
                </Row>
                <Row>
                    <Col sm={2}></Col>
                    <Col sm={8} className="text-center">
                        COS
                    </Col>
                    <Col sm={2}></Col>
                </Row>
                <Row>
                    <div className="hidden"></div>
                </Row>
            </Grid >
        );
    }
}

export default App;
