import { appReducer } from '../reducers/app-reducer';
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

const store = createStore(appReducer, initialState);
export default store;