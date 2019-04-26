
import React from 'react';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom'
import Typography from '@material-ui/core/Typography';
import { withStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import Fab from '@material-ui/core/Fab';
import AddIcon from '@material-ui/icons/Add';
import { goTo } from '../../shared/utils';

const styles = theme => ({
  root: {
    width: '100%',
    overflowX: 'auto',
  },
  table: {
    minWidth: 700,
  },
  tableRow: {
    cursor: 'pointer',
  },
  fab: {
    margin: theme.spacing.unit * 2,
    float: 'right'
  },
});

const mapStateToProps = state => {
  return {
    items: state.group.items
  };
};

function SimpleTable(props) {
  const { classes } = props;

  return (
    <>
      <Fab color="primary" aria-label="Add"
        className={classes.fab}
        onClick={() => goTo(props, 'groups/new')}>
        <AddIcon />
      </Fab>
      <Typography variant="h4" gutterBottom component="h2">
        Agrupamentos
      </Typography>
      <Paper className={classes.root}>
        <Table className={classes.table}>
          <TableHead>
            <TableRow>
              <TableCell>Nome</TableCell>
              <TableCell align="right">Prioridade</TableCell>
              <TableCell align="right">Tipo</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {props.items.map(item => (
              <TableRow className={classes.tableRow} key={item.uuid} onClick={() => goTo(props, `groups/edit/${item.uuid}`)}>
                <TableCell component="th" scope="row">
                  {item.name}
                </TableCell>
                <TableCell align="right">{item.priority}</TableCell>
                <TableCell align="right">{item.categoryType}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </Paper>
    </>
  );
}

export default connect(mapStateToProps)(withRouter(withStyles(styles)(SimpleTable)));