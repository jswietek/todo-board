import thunkMiddleware from 'redux-thunk';
import { createLogger } from 'redux-logger';
import { appReducer } from '../reducers/app-reducer';
import { createStore, applyMiddleware } from 'redux';

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

const loggerMiddleware = createLogger();

const store = createStore(appReducer, initialState, applyMiddleware(
    thunkMiddleware,
    loggerMiddleware
));

export default store;