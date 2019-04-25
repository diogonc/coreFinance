import * as actionTypes from './actionTypes';

export const addProduct = product => {
  return {
    type: actionTypes.ADD_PRODUCT,
    product: product
  };
};

export const updateProduct = product => {
  return {
    type: actionTypes.UPDATE_PRODUCT,
    product: product
  };
};

export const deleteProduct = productId => {
  return {
    type: actionTypes.DELETE_PRODUCT,
    id: productId
  };
};
