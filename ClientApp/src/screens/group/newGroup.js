import React from 'react';
import { connect } from 'react-redux';

import * as actions from '../../store/actions/groupActions';
import GroupForm from './form/';

const NewGroup = props => {
  return (
    <GroupForm
      save={props.add}
      item={{ id: 0, priority: 1, name: '', categoryType: 1 }}
    />
  );
};

const mapDispatchToProps = dispatch => {
  return {
    add: item => dispatch(actions.addGroup(item))
  };
};

export default connect(
  null,
  mapDispatchToProps
)(NewGroup);
