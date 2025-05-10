import { configureStore } from "@reduxjs/toolkit";
import reducer from "./todolistSlice";

const store = configureStore(
{
    reducer:{
        todos:reducer,
    },
}
)
export default store;