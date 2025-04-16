

interface Istate{
    count:number;
}
const initialState:Istate = 
{
    count:0
};

const counterReducer = (state = initialState,action:any):Istate=>
{
    switch(action.type)
    {
        case 'INCREMENT':
        return {...state,count:state.count+1}
        case 'DECREMENT':
        return {...state,count:state.count-1}
        case 'RESET':
        return {...state,count:0}
        default:return state
    }
}
export default counterReducer;