import React, { Component } from 'react';
import { Grid, Row, Col } from 'react-bootstrap';
import BoardContainer from './components/board-container';
import store from './store/store'
import './App.css';

class App extends Component {
    constructor(props) {
        super(props);
        this.state = store.getState();
    }

    render() {
        return (
            <Grid fluid>
                <Row>
                    <div className="hidden"></div>
                </Row>
                <Row>
                    <Col sm={2}></Col>
                    <Col sm={8} className="text-center">
                        <BoardContainer boards={this.state.boards} />
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
