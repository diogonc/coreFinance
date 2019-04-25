import React from 'react';
import { Route, Switch } from 'react-router-dom';
import styles from './App.module.css';
import Navigation from './screens/navigation/';
import ListGroup from './screens/group/listGroup';
import NewGroup from './screens/group/newGroup';
import EditGroup from './screens/group/editGroup';

const App = () => {
  return (
    <>
      <Navigation />
      <div className={[styles.MainContainer, 'container'].join(' ')}>
        <Switch>
          <Route path="/groups/new" render={() => <NewGroup />} />
          <Route path="/groups/edit/:uuid" exact component={EditGroup} />
          <Route path="/groups" exact render={() => <ListGroup />} />
          <Route exact path="/" render={() => <ListGroup />} />
        </Switch>
      </div>
    </>
  );
};

export default App;
