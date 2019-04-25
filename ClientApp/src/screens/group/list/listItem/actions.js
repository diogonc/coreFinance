import React from 'react';
import { connect } from 'react-redux';
import { NavLink } from 'react-router-dom';
import Notification from 'react-bulma-notification';

import * as actions from '../../../../store/actions/groupActions';

const deleteGroup = (functionToDeleteAGroup, uuid) => {
  Notification.success('Group deleted!');
  functionToDeleteAGroup(uuid);
};

const Actions = props => {
  return (
    <div className="buttons">
      <NavLink className="button is-primary" to={'/groups/edit/' + props.uuid}>
        Edit
      </NavLink>
      <button
        className="button is-danger"
        onClick={() => deleteGroup(props.deleteGroup, props.uuid)}
      >
        Delete
      </button>
    </div>
  );
};

const mapDispatchToProps = dispatch => {
  return {
    deleteGroup: uuid => dispatch(actions.deleteGroup(uuid))
  };
};

export default connect(
  null,
  mapDispatchToProps
)(Actions);
