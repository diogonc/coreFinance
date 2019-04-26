import React from 'react';
import { connect } from 'react-redux';

import withItemUuidFromUrl from '../../hoc/withIdFromUrl';
import * as actions from '../../store/actions/groupActions';
import GroupForm from './form/';

const EditGroup = props => {
  return <GroupForm save={props.update} deleteGroup={props.deleteGroup} item={props.item} />;
};

const mapStateToProps = state => {
  return {
    items: state.group.items
  };
};

const mapDispatchToProps = dispatch => {
  return {
    update: item => dispatch(actions.updateGroup(item)),
    deleteGroup: uuid => dispatch(actions.deleteGroup(uuid))
  };
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(withItemUuidFromUrl(EditGroup));
