import React, { Component } from 'react';
import { Grid, Row, Col, Button } from 'react-bootstrap';
import Board from './board';

class BoardContainer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            boards: props.boards,
        }
    }

    render() {
        var boardElements = [];
        for (var i = 0; i < this.state.boards.length; i++) {
            boardElements.push(
                <li xs={3}>
                    <Board data={this.state.boards[i]} />
                </li>
            );
        }

        return (
            <ul className="board-container">
                {boardElements}
            </ul>
        );
    }

}

export default BoardContainer;
