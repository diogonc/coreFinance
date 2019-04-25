import React from 'react';
import { connect } from 'react-redux';

import ProductItem from './components/productItem/';

const ProductList = props => {
  var itens = props.products.map(p => <ProductItem key={p.id} product={p} />);

  return <div className="columns is-multiline">{itens}</div>;
};

const mapStateToProps = state => {
  return {
    products: state.product.products
  };
};

export default connect(mapStateToProps)(ProductList);
