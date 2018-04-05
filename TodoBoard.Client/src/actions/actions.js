import fetch from 'cross-fetch'

//ITEMS
export const ADD_ITEM = "ADD_ITEM";
export const addItem = item => ({ type: ADD_ITEM, item });

export const DELETE_ITEM = "DELETE_ITEM";
export const deleteItem = id => ({ type: DELETE_ITEM, id });

export const CHANGE_ITEM_NAME = "CHANGE_ITEM_NAME";
export const changeItemName = (id, newName) => ({ type: CHANGE_ITEM_NAME, id, newName });

export const CHANGE_ITEM_DESC = "CHANGE_ITEM_DESC";
export const changeItemDescription = (id, newDescription) => ({ type: CHANGE_ITEM_DESC, id, newDescription });

export const MOVE_ITEM = "MOVE_ITEM";
export const moveItem = (id, newBoardId) => ({ type: MOVE_ITEM, id, newBoardId });

export const REQUEST_ITEMS = "REQUEST_ITEMS";
export const requestItems = () => ({ type: REQUEST_ITEMS });

export const RECEIVE_ITEMS = "RECEIVE_ITEMS";
export const receiveItems = (json) => ({ type: RECEIVE_ITEMS, items: json, receivedAt: Date.now })

//BOARDS
export const ADD_BOARD = "ADD_BOARD";
export const addBoard = board => ({ type: ADD_BOARD, board });

export const DELETE_BOARD = "DELETE_BOARD";
export const deleteBoard = id => ({ type: DELETE_BOARD, id });

export const CHANGE_BOARD_NAME = "CHANGE_BOARD_NAME";
export const changeBoardName = (id, newName) => ({ type: CHANGE_BOARD_NAME, id, newName })

export const REQUEST_BOARDS = "REQUEST_BOARDS";
export const requestBoards = () => ({ type: REQUEST_BOARDS });

export const RECEIVE_BOARDS = "RECEIVE_BOARDS";
export const receiveBoards = (json) => ({ type: RECEIVE_BOARDS, boards: json, receivedAt: Date.now })

export function fetchPosts() {
    return function (dispatch) {
        dispatch(requestBoards());

        return fetch('http://loaclhost:15351/api/boards')
            .then(
                response => response.json(),
                error => console.log('ERROR!!!!', error),
            )
            .then(
                json => dispatch(receiveBoards(json))
            );
    }
}