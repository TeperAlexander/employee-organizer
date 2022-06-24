import { configureStore } from '@reduxjs/toolkit'
import { stateReducer } from "./reducers/stateReducer";
import storage from 'redux-persist/lib/storage';
import { persistReducer, persistStore } from 'redux-persist';
import thunk from 'redux-thunk';



const persistConfiguration = {
    key: 'root',
    storage
}

// Using combined reducers would be better approach
const persistedReducer = persistReducer(persistConfiguration, stateReducer);

export const store = configureStore({
    reducer: persistedReducer,
    middleware: [thunk]
});

export const persistor = persistStore(store);