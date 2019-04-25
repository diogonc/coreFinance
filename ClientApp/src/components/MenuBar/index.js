import React from 'react';
import { NavLink } from 'react-router-dom';

const MenuBar = props => {
  const links = props.links.map(link => (
    <NavLink className="navbar-item" to={link.path} exact key={link.path}>
      {link.label}
    </NavLink>
  ));
  return (
    <nav
      className="navbar is-primary"
      role="navigation"
      aria-label="main navigation"
    >
      <div className="navbar-menu">
        <div className="navbar-start">{links}</div>
      </div>
    </nav>
  );
};

export default MenuBar;
