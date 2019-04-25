import React from 'react';
import { NavLink } from 'react-router-dom';
import { connect } from 'react-redux';

import GroupItem from './list/listItem';

const ListGroup = props => {
  var items = props.items.map(item => <GroupItem key={item.uuid} item={item} />);

  return (
    <div className="columns is-multiline">
      <NavLink className="button is-primary" to={'/groups/new/'}>
        New
      </NavLink>
      {items}
    </div>);
};

const mapStateToProps = state => {
  return {
    items: state.group.items
  };
};

export default connect(mapStateToProps)(ListGroup);
