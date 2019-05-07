import { combineReducers } from 'redux'
import product from './productReducers'
import group from './groupReducers'
import navigation from './navigationReducers'

export default combineReducers({
    product,
    group,
    navigation
})