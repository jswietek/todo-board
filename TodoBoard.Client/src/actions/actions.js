import './action-types';

//ITEMS
export const addItem = item => ({ type: ADD_ITEM, item });
export const deleteItem = id => ({ type: DELETE_ITEM, id });
export const changeItemName = (id, newName) => ({ type: CHANGE_ITEM_NAME, id, newName });
export const changeItemDescription = (id, newDescription) => ({ type: CHANGE_ITEM_DESC, id, newDescription });
export const moveItem = (id, newBoardId) => ({ type: MOVE_ITEM, id, newBoardId });


//BOARDS
export const addBoard = board => ({ type: ADD_BOARD, board });
export const deleteBoard = id => ({ type: DELETE_BOARD, id });
export const changeBoardName = (id, newName) => ({ type: CHANGE_BOARD_NAME, id, newName })