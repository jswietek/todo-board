import { appReducer } from '../reducers/app-reducer';
import { createStore } from 'redux';

const initialState = {
    items: [],
    boards: [
        {
            Id: 1,
            Name: "jedna"
        },
        {
            Id: 2,
            Name: "druga"
        }
    ]
}

const store = createStore(appReducer, initialState);
export default store;