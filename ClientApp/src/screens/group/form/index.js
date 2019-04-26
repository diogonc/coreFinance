import React, { useState } from 'react';
import { withRouter } from 'react-router-dom';
import Button from '@material-ui/core/Button';
import FormControl from '@material-ui/core/FormControl';
import Input from '@material-ui/core/Input';
import InputLabel from '@material-ui/core/InputLabel';
import Typography from '@material-ui/core/Typography';
import withStyles from '@material-ui/core/styles/withStyles';
import Select from '@material-ui/core/Select';
import MenuItem from '@material-ui/core/MenuItem';

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

const submitForm = (event, props, group) => {
  event.preventDefault();
  props.save(group);
  props.history.push('/groups');
};

const deleteGroupAction = (props, uuid) => {
  props.deleteGroup(uuid);
  props.history.push('/groups');
};

const goToList = (props) => {
  props.history.push('/groups');
};

function GroupForm(props) {
  const { classes } = props;

  const [group, updateGroup] = useState({
    uuid: props.item.uuid,
    name: props.item.name,
    priority: props.item.priority,
    categoryType: props.item.categoryType,
  });

  return (
    <>
      <Typography component="h1" variant="h5">
        Agrupamento
        </Typography>
      <form className={classes.form} onSubmit={event => submitForm(event, props, group)}>
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
        <Button
          type="submit"
          variant="contained"
          size="small"
          className={classes.button}
        >
          Salvar e novo
          </Button>
        <Button
          type="button"
          variant="contained"
          color="secondary"
          size="small"
          className={classes.button}
          onClick={event => deleteGroupAction(props, group.uuid)}
        >
          Excluir
          </Button>
        <Button
          type="button"
          variant="contained"
          size="small"
          className={classes.button}
          onClick={event => goToList(props)}
        >
          Voltar
          </Button>
      </form>
    </>
  );
}

export default withRouter(withStyles(styles)(GroupForm));
