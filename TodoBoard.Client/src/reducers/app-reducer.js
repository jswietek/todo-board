import { combineReducers } from 'redux';
import BoardsReducer from './boards-reducer';
import ItemsReducer from './items-reducer';

export const AppReducer = combineReducers({
    items: ItemsReducer,
    boards: BoardsReducer
});