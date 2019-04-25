import React from 'react';
import { connect } from 'react-redux';
import { NavLink } from 'react-router-dom';

import withItemUuidFromUrl from '../../hoc/withIdFromUrl/';
import styles from './ViewProduct.module.css';
import { formatMoney, formatDate } from '../../shared/formatters';

const ViewProduct = props => {
  return (
    <div className={styles.ViewProduct}>
      <p>{props.item.name}</p>
      <strong>U$ {formatMoney(props.item.price)}</strong>
      <div>created at: {formatDate(props.item.creationDate)}</div>
      <div className="content">{props.item.description}</div>
      <NavLink className="button is-info" to="/">
        Show list
      </NavLink>
    </div>
  );
};

const mapStateToProps = state => {
  return {
    items: state.products
  };
};

export default connect(mapStateToProps)(withItemUuidFromUrl(ViewProduct));
