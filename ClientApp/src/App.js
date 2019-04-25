import React from 'react';
import { Route, Switch } from 'react-router-dom';
import styles from './App.module.css';
import Navigation from './screens/navigation/';
import ProductList from './screens/productList/';
import GroupList from './screens/group/';
import NewGroup from './screens/group/newGroup';
import EditGroup from './screens/group/editGroup';
import EditProduct from './screens/editProduct/';
import ViewProduct from './screens/viewProduct/';
import NewProduct from './screens/newProduct/';

const App = () => {
  return (
    <>
      <Navigation />
      <div className={[styles.MainContainer, 'container'].join(' ')}>
        <Switch>
          <Route path="/new" component={NewProduct} />
          <Route path="/edit/:uuid" exact component={EditProduct} />
          <Route path="/view/:uuid" exact component={ViewProduct} />
          <Route path="/groups/new" render={() => <NewGroup />} />
          <Route path="/groups/edit/:uuid" exact component={EditGroup} />
          <Route path="/groups" exact render={() => <GroupList />} />
          <Route exact path="/" render={() => <ProductList />} />
        </Switch>
      </div>
    </>
  );
};

export default App;
