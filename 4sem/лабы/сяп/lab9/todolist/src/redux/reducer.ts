
import { ADD_TASK, TOGGLE_TASK, EDIT_TASK, DELETE_TASK } from "./actions";

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

const todoReducer = (state = initialState, action:any): Istate => {
    switch (action.type) {
        case ADD_TASK:
            return {
                ...state,
                tasklist: [
                    ...state.tasklist,
                    { id: Date.now(), text: action.info, completed: false },
                ],
            };

        case TOGGLE_TASK: {
            const updatedTasklist: task[] = [];
            state.tasklist.forEach(task => {
                if (task.id === action.info) {
                    updatedTasklist.push({ ...task, completed: !task.completed });
                } else {
                    updatedTasklist.push(task);
                }
            });
            return {
                ...state,
                tasklist: updatedTasklist,
            };
        }

        case EDIT_TASK: {
            const updatedTasklist: task[] = [];
            state.tasklist.forEach(task => {
                if (task.id === action.info.id) {
                    updatedTasklist.push({ ...task, text: action.info.task });
                    console.log(action);
                } else {
                    updatedTasklist.push(task);
                }
            });
            return {
                ...state,
                tasklist: updatedTasklist,
            };
        }

        case DELETE_TASK: {
            const updatedTasklist = state.tasklist.filter(task => task.id !== action.info);
            return {
                ...state,
                tasklist: updatedTasklist,
            };
        }

        default:
            return state;
    }
};

export default todoReducer;