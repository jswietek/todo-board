import { combineReducers } from 'redux';
import { itemsReducer, boardsReducer } from '.';

export const initialState = {
    items: [],
    boards: []
}

const appReducer = combineReducers({
    itemsReducer,
    boardsReducer
})

export default appReducer;