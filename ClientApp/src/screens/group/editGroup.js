import React, { useState } from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import toastr from 'toastr'
import Button from '@material-ui/core/Button';
import FormControl from '@material-ui/core/FormControl';
import Input from '@material-ui/core/Input';
import InputLabel from '@material-ui/core/InputLabel';
import Typography from '@material-ui/core/Typography';
import withStyles from '@material-ui/core/styles/withStyles';
import Select from '@material-ui/core/Select';
import MenuItem from '@material-ui/core/MenuItem';
import * as actions from '../../store/actions/groupActions';

const mapStateToProps = state => {
  return {
    items: state.group.items
  };
};

const mapDispatchToProps = dispatch => {
  return {
    update: item => dispatch(actions.updateGroup(item)),
    add: item => dispatch(actions.addGroup(item)),
    deleteGroup: uuid => dispatch(actions.deleteGroup(uuid))
  };
};

const styles = theme => ({
  form: {
    maxWidth: '350px',
    marginTop: theme.spacing.unit,
  },
  button: {
    marginTop: theme.spacing.unit * 3,
    marginRight: theme.spacing.unit,
  },
});

const submitForm = (event, props, group, newItem, updateGroup) => {
  event.preventDefault();
  if (group.uuid) {
    props.update(group);
  } else {
    props.add(group);
  }
  toastr.success(`Group saved!!`)

  console.log('dddd', newItem)
  if (!newItem)
    props.history.push('/groups');
  else {
    console.log('aaaa')
    updateGroup({ uuid: 0, priority: 1, name: '', categoryType: 1 })
  }
};

const deleteGroupAction = (props, uuid) => {
  props.deleteGroup(uuid);
  toastr.success(`Group deleted!!`)
  props.history.push('/groups');
};

const goToList = (props) => {
  props.history.push('/groups');
};

const EditGroup = props => {
  const { classes } = props;
  let item = { uuid: 0, priority: 1, name: '', categoryType: 2 };
  let uuid = parseInt(props.match.params.uuid);
  if (uuid) {
    const itemFound = props.items.find(item => item.uuid === uuid);
    if (itemFound) {
      item = itemFound
    }
    else {
      uuid = null;
    }
  }
  const [group, updateGroup] = useState({ ...item });

  const optionalButton = item.uuid && item.uuid !== 0 ?
    (
      <Button
        type="button"
        variant="contained"
        color="secondary"
        size="small"
        className={classes.button}
        onClick={event => deleteGroupAction(props, group.uuid)}
      >
        Excluir
    </Button>)
    :
    (
      <Button
        type="button"
        variant="contained"
        size="small"
        className={classes.button}
        onClick={event => submitForm(event, props, group, true, updateGroup)}
      >
        Salvar e novo
          </Button>
    );


  return (
    <>
      <Typography component="h1" variant="h5">
        Agrupamento
        </Typography>
      <form className={classes.form} onSubmit={event => submitForm(event, props, group, false, updateGroup)}>
        <input type="hidden" name="id" value={group.uuid} />
        <FormControl margin="normal" required fullWidth>
          <InputLabel htmlFor="email">Nome</InputLabel>
          <Input id="name" name="name" autoFocus
            value={group.name}
            onChange={event =>
              updateGroup({ ...group, name: event.target.value })
            } />
        </FormControl>
        <FormControl margin="normal" required fullWidth>
          <InputLabel htmlFor="priority">Prioridade</InputLabel>
          <Input name="priority" type="number" step="1" id="priority"
            value={group.priority}
            onChange={event =>
              updateGroup({ ...group, priority: event.target.value })
            } />
        </FormControl>
        <FormControl margin="normal" required fullWidth>
          <InputLabel htmlFor="categoryType">Tipo</InputLabel>
          <Select
            value={group.categoryType}
            onChange={event =>
              updateGroup({ ...group, categoryType: event.target.value })
            }
            inputProps={{
              name: 'categoryType',
              id: 'categoryType',
            }}
          >
            <MenuItem value={1}>Crédito</MenuItem>
            <MenuItem value={2}>Débito</MenuItem>
            <MenuItem value={3}>Tranferência de crédito</MenuItem>
            <MenuItem value={4}>Tranferência de débito</MenuItem>
          </Select>
        </FormControl>
        <Button
          type="submit"
          variant="contained"
          color="primary"
          size="small"
          className={classes.button}
        >
          Salvar
          </Button>
        {optionalButton}
        <Button
          type="button"
          variant="contained"
          size="small"
          className={classes.button}
          onClick={() => goToList(props)}
        >
          Voltar
          </Button>
      </form>
    </>
  );
};


export default connect(
  mapStateToProps,
  mapDispatchToProps
)(withRouter(withStyles(styles)(EditGroup)));
