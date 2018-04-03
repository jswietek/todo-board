import { combineReducers } from 'redux';
import boardsReducer from './boards-reducer';
import itemsReducer from './items-reducer';

export const appReducer = combineReducers({
    items: itemsReducer,
    boards: boardsReducer
});