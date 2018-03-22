import React, { Component } from 'react';
import { Grid, Row, Col, Button } from 'react-bootstrap'
import Board from './board'

function BoardContainer(props) {
    var boards = [];
    for (var i = 0; i < props.Boards.length; i++) {
        boards.push(
            <Col xs={3}>
                <Board data={props.Boards[i]} />
            </Col>
        );
    }

    return (
        <Grid fluid>
            <Row>
                {boards}
            </Row>
        </Grid>
    );
}

export default BoardContainer;
