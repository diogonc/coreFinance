import React from 'react';
import ReactDOM from 'react-dom';
import * as serviceWorker from './serviceWorker';
import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
import { createStore } from 'redux';
import { offline } from '@redux-offline/redux-offline';
import config from '@redux-offline/redux-offline/lib/config';
import App from './App';
import reducer from './store/reducers';
import toastr from 'toastr'

const store = createStore(reducer, offline(config))

toastr.options = {
  hideDuration: 300,
  timeOut: 1200,
  positionClass: 'toast-top-right',
}

ReactDOM.render(
  <Provider store={store}>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </Provider>,
  document.getElementById('root')
);

serviceWorker.unregister();
