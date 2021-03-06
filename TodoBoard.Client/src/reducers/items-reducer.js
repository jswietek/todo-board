﻿import { ADD_ITEM, DELETE_ITEM, CHANGE_ITEM_NAME, CHANGE_ITEM_DESC, MOVE_ITEM } from '../actions/actions';

function itemsReducer(state = {}, action) {
    switch (action) {
        case ADD_ITEM:
            return Object.assign({}, state, {
                items: [
                    ...state.items,
                    action.item
                ]
            });
        case DELETE_ITEM:
            var itemIdx = state.items.findIndex(item => item.id === action.id);
            return Object.assign({}, state, {
                items: [
                    ...state.items.slice(0, itemIdx),
                    ...state.slice(itemIdx + 1)
                ]
            });
        case CHANGE_ITEM_NAME:
            return Object.assign({}, state, {
                items: state.items.map(item => {
                    if (item.id === action.id) {
                        return Object.assign({}, item, {
                            name: action.newName,
                        })
                    }
                    return item;
                })
            });
        case CHANGE_ITEM_DESC:
            return Object.assign({}, state, {
                items: state.items.map(item => {
                    if (item.id === action.id) {
                        return Object.assign({}, item, {
                            descrption: action.newDescrption,
                        })
                    }
                    return item;
                })
            });
        case MOVE_ITEM:
            return Object.assign({}, state, {
                items: state.items.map(item => {
                    if (item.id === action.id) {
                        return Object.assign({}, item, {
                            boardId: action.newBoardId
                        })
                    }
                    return item;
                })
            });

        default:
            return state;
    }
}

export default itemsReducer;