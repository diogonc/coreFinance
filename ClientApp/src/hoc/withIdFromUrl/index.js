import React from 'react';
import { Redirect } from 'react-router-dom';

export const withItemUuidFromUrl = WrappedComponent => {
  return props => {
    console.log(props);
    var uuid = parseInt(props.match.params.uuid);
    const item = props.items.find(item => item.uuid === uuid);

    if (!item) {
      return <Redirect to="/groups" />;
    }
    return <WrappedComponent {...props} item={item} />;
  };
};

export default withItemUuidFromUrl;
