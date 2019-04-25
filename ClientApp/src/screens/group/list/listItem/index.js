import React from 'react';

import styles from './GroupItem.module.css';
import Actions from './actions';

const GroupItem = props => {
  return (
    <div className={[styles.Item, 'column', 'is-one-quarter'].join(' ')}>
      <p>{props.item.name}</p>
      <strong>{props.item.priority}</strong>
      <strong>{props.item.categoryType}</strong>
      <Actions uuid={props.item.uuid} />
    </div>
  );
};

export default GroupItem;
