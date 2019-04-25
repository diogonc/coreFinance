import * as actionTypes from './actionTypes';

export const addGroup = group => {
  return {
    type: actionTypes.ADD_GROUP,
    item: group
  };
};

export const updateGroup = group => {
  return {
    type: actionTypes.UPDATE_GROUP,
    item: group
  };
};

export const deleteGroup = uuid => {
  return {
    type: actionTypes.DELETE_GROUP,
    uuid: uuid
  };
};
