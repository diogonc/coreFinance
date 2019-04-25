import { combineReducers } from 'redux'
import product from './productReducers'
import group from './groupReducers'

export default combineReducers({
    product,
    group
})