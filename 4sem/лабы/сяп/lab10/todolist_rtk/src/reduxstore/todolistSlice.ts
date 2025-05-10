import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { act } from "react";


interface task{
    id:number,
    text:string,
    completed:boolean
}
interface Istate
{
    tasklist:task[]
}
const initialState:Istate = {
    tasklist: [],
};

const todolistSlice = createSlice(
    {
        name: 'todos',
        initialState,
        reducers:
        {
            AddTask:(state,action:PayloadAction<string>) =>
            {
                const todoTask:task = {id:Date.now(),text:action.payload,completed:false};
                state.tasklist.push(todoTask);
            },
            ToggleTask:(state,action:PayloadAction<number>)=>
            {
                state.tasklist.forEach(task=>
                {
                    if(task.id === action.payload)
                    {
                        task.completed = !task.completed;
                    }
                }
                )
            },
            EditTask:(state,action:PayloadAction<{id:number,text:string}>)=>
            {
                state.tasklist.forEach(task=>
                {
                    if(task.id === action.payload.id)
                    {
                        task.text = action.payload.text;
                    }
                }

                )
            },
            DeleteTask:(state,action:PayloadAction<number>)=>
            {
                state.tasklist = state.tasklist.filter(task=>task.id !==action.payload);
            },

        }
    }
)
   

       
        
    
;

export default todolistSlice.reducer;
export const {AddTask,DeleteTask,EditTask,ToggleTask} = todolistSlice.actions;