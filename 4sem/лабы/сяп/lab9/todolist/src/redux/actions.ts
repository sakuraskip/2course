export const ADD_TASK = "ADD_TASK"
export const TOGGLE_TASK  = "TOGGLE_TASK"
export  const EDIT_TASK = "EDIT_TASK"
export const DELETE_TASK = "DELETE_TASK"


export const addTask = (task:string)=>
{
    return {type:ADD_TASK,info:task}
}
export const toggleTask = (id:number)=>
{
    return {type:TOGGLE_TASK,info:id}
}
export const editTask = (task:string,id:number)=>
{
    return {type:EDIT_TASK,info:{task,id}}
}
export const deleteTask = (id:number)=>
{
    return {type:DELETE_TASK,info:id}
}