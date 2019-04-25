import React, { useState } from 'react';
import { withRouter } from 'react-router-dom';
import Form from 'react-validation/build/form';
import Button from 'react-validation/build/button';
import Input from 'react-validation/build/input';
import TextArea from 'react-validation/build/textarea';
import { NavLink } from 'react-router-dom';
import Notification from 'react-bulma-notification';

import styles from './ProductForm.module.css';
import { required, graterThen } from '../../shared/Validation/';

const submitForm = (event, props, product) => {
  event.preventDefault();
  props.saveProduct(product);
  props.history.push('/');
  Notification.success('Product saved!');
};

const ProductForm = props => {
  const [product, updateProduct] = useState({
    id: props.product.id,
    price: props.product.price,
    name: props.product.name,
    description: props.product.description
  });

  return (
    <Form onSubmit={event => submitForm(event, props, product)}>
      <input type="hidden" name="id" value={product.id} />
      <div className="control">
        <label className="label">Name</label>
        <Input
          className="input"
          type="text"
          name="name"
          value={product.name}
          onChange={event =>
            updateProduct({ ...product, name: event.target.value })
          }
          validations={[required]}
        />
      </div>
      <div className="control">
        <label className="label">Price</label>
        <Input
          type="number"
          name="price"
          step="0.01"
          min="0"
          value={product.price}
          validations={[required, graterThen]}
          onChange={event =>
            updateProduct({ ...product, price: event.target.value })
          }
        />
      </div>
      <div className="control">
        <label className="label">Description</label>
        <TextArea
          className="textarea"
          name="description"
          value={product.description}
          onChange={event =>
            updateProduct({ ...product, description: event.target.value })
          }
          validations={[required]}
        >
          {product.description}
        </TextArea>
      </div>
      <div className={[styles.ButtonsArea, 'control', 'buttons'].join(' ')}>
        <Button className="button is-primary" type="submit">
          Save
        </Button>
        <NavLink className="button is-link" to="/">
          Show product list
        </NavLink>
      </div>
    </Form>
  );
};

export default withRouter(ProductForm);
