import React from 'react';
import { connect } from 'react-redux';
import { NavLink } from 'react-router-dom';
import Notification from 'react-bulma-notification';

import * as actions from '../../../../../../store/actions/productActions';

const deleteProduct = (functionToDeleteAProduct, id) => {
  Notification.success('Product deleted!');
  functionToDeleteAProduct(id);
};

const ProductItemActions = props => {
  return (
    <div className="buttons">
      <NavLink className="button is-info" to={'/view/' + props.productId}>
        View
      </NavLink>
      <NavLink className="button is-primary" to={'/edit/' + props.productId}>
        Edit
      </NavLink>
      <button
        className="button is-danger"
        onClick={() => deleteProduct(props.deleteProduct, props.productId)}
      >
        Delete
      </button>
    </div>
  );
};

const mapDispatchToProps = dispatch => {
  return {
    deleteProduct: productId => dispatch(actions.deleteProduct(productId))
  };
};

export default connect(
  null,
  mapDispatchToProps
)(ProductItemActions);
