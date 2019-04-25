import React from 'react';
import { connect } from 'react-redux';

import * as actions from '../../store/actions/productActions';
import ProductForm from '../productForm/';

const NewProduct = props => {
  return (
    <ProductForm
      saveProduct={props.addProduct}
      product={{ id: 0, price: 0, name: '', description: '' }}
    />
  );
};

const mapDispatchToProps = dispatch => {
  return {
    addProduct: product => dispatch(actions.addProduct(product))
  };
};

export default connect(
  null,
  mapDispatchToProps
)(NewProduct);
