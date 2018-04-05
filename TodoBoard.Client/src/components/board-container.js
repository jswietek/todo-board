import React, { Component } from 'react';
import Board from './board';

class BoardContainer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            boards: this.props.boards,
        }
    }

    render() {
        var boardElements = this.state.boards.map((board) =>
            <li key={board.Id}>
                <Board data={board} />
            </li>
        );

        return (
            <ul className="board-container">
                {boardElements}
            </ul>
        );
    }

}

export default BoardContainer;
