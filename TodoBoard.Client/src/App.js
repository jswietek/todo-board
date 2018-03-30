import React, { Component } from 'react';
import { Grid, Row, Col } from 'react-bootstrap'
import BoardContainer from './components/board-container'
import './App.css';

class App extends Component {
    constructor(props) {
        super(props);
        this.boards = [
            {
                Name: "jedna"
            },
            {
                Name: "druga"
            }
        ];
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
                        <BoardContainer boards={this.boards} />
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
