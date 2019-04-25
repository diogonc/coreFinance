import React, { useState } from 'react';
import { withRouter } from 'react-router-dom';
import Form from 'react-validation/build/form';
import Button from 'react-validation/build/button';
import Input from 'react-validation/build/input';
import { NavLink } from 'react-router-dom';
import Notification from 'react-bulma-notification';

import styles from './form.module.css';
import { required, graterThen } from '../../../shared/Validation/';

const submitForm = (event, props, group) => {
  event.preventDefault();
  props.save(group);
  props.history.push('/groups');
  Notification.success('Group saved!');
};

const GroupForm = props => {
  const [group, updateGroup] = useState({
    uuid: props.item.uuid,
    name: props.item.name,
    priority: props.item.priority,
    categoryType: props.item.categoryType,
  });

  return (
    <Form onSubmit={event => submitForm(event, props, group)}>
      <input type="hidden" name="id" value={group.uuid} />
      <div className="control">
        <label className="label">Nome</label>
        <Input
          className="input"
          type="text"
          name="name"
          value={group.name}
          onChange={event =>
            updateGroup({ ...group, name: event.target.value })
          }
          validations={[required]}
        />
      </div>
      <div className="control">
        <label className="label">Prioridade</label>
        <Input
          type="number"
          name="priority"
          step="1"
          min="0"
          value={group.priority}
          validations={[required, graterThen]}
          onChange={event =>
            updateGroup({ ...group, priority: event.target.value })
          }
        />
      </div>
      <div className="control">
        <label className="label">Tipo</label>
        <Input
          type="number"
          name="categoryType"
          step="1"
          min="0"
          max="4"
          value={group.categoryType}
          validations={[required, graterThen]}
          onChange={event =>
            updateGroup({ ...group, categoryType: event.target.value })
          }
        />
      </div>
      <div className={[styles.ButtonsArea, 'control', 'buttons'].join(' ')}>
        <Button className="button is-primary" type="submit">
          Save
        </Button>
        <NavLink className="button is-link" to="/groups">
          Show list
        </NavLink>
      </div>
    </Form>
  );
};

export default withRouter(GroupForm);
