import { ADD_ITEM, DELETE_ITEM, CHANGE_ITEM_NAME, CHANGE_ITEM_DESC, MOVE_ITEM } from './action-types';

const initialState = {
    items: [],
    boards: []
}

function itemsReducer(state = initialState, action) {
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
                        return Onject.assign({}, item, {
                            name: action.newName,
                        })
                    }
                })
            });
        case CHANGE_ITEM_DESC:
            return Object.assign({}, state, {
                items: state.items.map(item => {
                    if (item.id === action.id) {
                        return Onject.assign({}, item, {
                            descrption: action.newDescrption,
                        })
                    }
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
                })
            });

        default:
            return state;
    }
}