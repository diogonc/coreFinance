import React from 'react';

import MenuBar from '../../components/MenuBar';

const Navigation = () => {
  return (
    <MenuBar
      links={[
        { path: '/groups', label: 'Groups' }
      ]}
    />
  );
};

export default Navigation;
