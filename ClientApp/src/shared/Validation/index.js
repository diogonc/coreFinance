import React from 'react';
import styles from './Validation.module.css';

export const required = (value, props) => {
  if (!value.toString().trim().length) {
    return <p className={styles.Error}>{props.name + ' is required'}</p>;
  }
};

export const graterThen = (value, props) => {
  if (value <= props.min) {
    return (
      <p className={styles.Error}>
        {props.name + ' should be greater than ' + props.min}
      </p>
    );
  }
};
