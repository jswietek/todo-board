import { AppReducer } from '../reducers/app-reducer';
import { createStore } from 'redux';

const initialState = {
    items: [],
    boards: [
        {
            Name: "jedna"
        },
        {
            Name: "druga"
        }
    ]
}

const Store = createStore(AppReducer, initialState);
export default Store;