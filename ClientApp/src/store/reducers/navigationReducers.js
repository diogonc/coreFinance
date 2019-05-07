import * as actionTypes from '../actions/actionTypes';

const initialState = {
    anchorEl: null,
    isMenuExpanded: window.innerWidth > 600
};


const reducer = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.TOOGLE_MENU:
            return {
                anchorEl: null,
                isMenuExpanded: action.isMenuExpanded
            };
        default:
            return state;

    }
};

export default reducer;
