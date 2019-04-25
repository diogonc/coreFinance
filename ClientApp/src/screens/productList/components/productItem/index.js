import React from 'react';

import styles from './ProductItem.module.css';
import { formatMoney, formatDate } from '../../../../shared/formatters';
import ProductItemActions from './components/productItemActions/';

const ProductItem = props => {
  return (
    <div className={[styles.Product, 'column', 'is-one-quarter'].join(' ')}>
      <p>{props.product.name}</p>
      <strong>U$ {formatMoney(props.product.price)}</strong>
      <div>created at: {formatDate(props.product.creationDate)}</div>
      <ProductItemActions productId={props.product.id} />
    </div>
  );
};

export default ProductItem;
