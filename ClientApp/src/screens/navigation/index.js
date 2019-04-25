import React from 'react';

import MenuBar from '../../components/MenuBar';

const Navigation = () => {
  return (
    <MenuBar
      links={[
        { path: '/', label: 'Products' },
        { path: '/new', label: 'Add new product' },
        { path: '/groups', label: 'Groups' }
      ]}
    />
  );
};

export default Navigation;
