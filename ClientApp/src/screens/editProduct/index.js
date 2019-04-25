import React from 'react';
import { connect } from 'react-redux';

import withItemUuidFromUrl from '../../hoc/withIdFromUrl/';
import * as actions from '../../store/actions/productActions';
import ProductForm from '../productForm/';

const EditProduct = props => {
  return <ProductForm saveProduct={props.updateProduct} product={props.item} />;
};

const mapStateToProps = state => {
  return {
    items: state.product.products
  };
};

const mapDispatchToProps = dispatch => {
  return {
    updateProduct: product => dispatch(actions.updateProduct(product))
  };
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(withItemUuidFromUrl(EditProduct));
