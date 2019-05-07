import * as actionTypes from './actionTypes';

export const toogleMenu = isMenuExpanded => {
  return {
    type: actionTypes.TOOGLE_MENU,
    isMenuExpanded: isMenuExpanded
  };
};