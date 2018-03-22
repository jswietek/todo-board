import React, { Component } from 'react';
import { Grid, Row, Col, Button } from 'react-bootstrap'

class Board extends Component {
    render() {
        return (
            <Grid fluid>
                <Row>
                    <Col sm={12}>
                        {this.props.data.Name}
                    </Col>
                </Row>
                <Row>
                    <Col sm={12}>
                        Here goes the task container
                    </Col>
                </Row>
                <Row>
                    <Col sm={12}>
                        <Button block><h3>+</h3></Button>
                    </Col>
                </Row>
            </Grid>
        );
    }
}

export default Board;