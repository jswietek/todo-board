import { ADD_BOARD, DELETE_BOARD, CHANGE_BOARD_NAME } from './action-types';
import { initialState } from './app-reducer'

function boardsReducer(state = initialState, action) {
    switch (action) {
        case ADD_BOARD:
            return Object.assign({}, state, {
                boards: [
                    ...state.boards,
                    action.board
                ]
            });
        case DELETE_BOARD:
            var boardIdx = state.boards.findIndex(board => board.id === action.id);
            return Object.assign({}, state, {
                boards: [
                    ...state.boards.slice(0, boardIdx),
                    ...state.slice(boardIdx + 1)
                ]
            });
        case CHANGE_BOARD_NAME:
            return Object.assign({}, state, {
                boards: state.boards.map(board => {
                    if (board.id === action.id) {
                        return Onject.assign({}, board, {
                            name: action.newName,
                        })
                    }
                })
            });
        default:
            return initialState;
    }
}

export default boardsReducer;