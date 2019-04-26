import React from 'react';
import { withRouter } from 'react-router-dom'
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import SpeakerGroup from '@material-ui/icons/SpeakerGroup';
import BarChartIcon from '@material-ui/icons/BarChart';
import { goTo } from '../../shared/utils';

const ListItems = (props) => (
    <div>
        <ListItem button>
            <ListItemIcon>
                <SpeakerGroup />
            </ListItemIcon>
            <ListItemText primary="Agrupamentos" onClick={() => goTo(props, 'groups')} />
        </ListItem>
        <ListItem button>
            <ListItemIcon>
                <BarChartIcon />
            </ListItemIcon>
            <ListItemText primary="Relatórios" onClick={() => goTo(props, 'relatorios')} />
        </ListItem>
    </div>
);

export default withRouter(ListItems);