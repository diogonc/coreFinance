import * as actionTypes from '../actions/actionTypes';

const initialState = {
  products: [
    {
      id: 1,
      price: 13.5,
      name: 'keyboard',
      description: 'A keyboard full of keys',
      creationDate: Date()
    },
    {
      id: 2,
      price: 7.75,
      name: 'mouse',
      description: 'A mouse with three buttons',
      creationDate: Date()
    },
    {
      id: 3,
      price: 700,
      name: 'laptop',
      description: 'A laptop with screen and a keyboard',
      creationDate: Date()
    },
    {
      id: 4,
      price: 150,
      name: 'monitor',
      description: 'A widescreen monitor',
      creationDate: Date()
    },
    {
      id: 5,
      price: 120.99,
      name: 'desk',
      description: 'A big desk',
      creationDate: Date()
    }
  ]
};

const getMaxIdFromState = state => {
  if (state.products.length === 0){
    return 0;
  } 
  return Math.max.apply(Math, state.products.map(p => p.id));
};

const addProduct = (state, action) => {
  const newProductList = [
    ...state.products,
    {
      ...action.product,
      id: getMaxIdFromState(state) + 1,
      creationDate: Date()
    }
  ];
  return { products: newProductList };
};

const updateProduct = (state, action) => {
  const newProductList = state.products.map(item => {
    if (item.id === action.product.id){
      return { ...action.product, creationDate: item.creationDate };
    }      
    return item;
  });
  return { products: newProductList };
};

const deleteProduct = (state, action) => {
  const newProductList = state.products.filter(item => action.id !== item.id);
  return { products: newProductList };
};

const reducer = (state = initialState, action) => {
  switch (action.type) {
    case actionTypes.ADD_PRODUCT:
      return addProduct(state, action);
    case actionTypes.UPDATE_PRODUCT:
      return updateProduct(state, action);
    case actionTypes.DELETE_PRODUCT:
      return deleteProduct(state, action);
    default:
      return state;
  }
};

export default reducer;
