import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { create } from "domain";
import { fetchPosts,createPost,deletePost,updatePost } from "./postsAPI";

export interface Post
{
    userId:number,
    id:number,
    title:string,
    body:string
}
export interface NewPost
{
    userId:number,
    title:string,
    body:string
}
interface Istate
{
    Posts:Post[],
    loading:boolean,
    error:boolean;
}
const initialState:Istate=
{
    Posts:[],
    loading:false,
    error:false
}
const postsSlice = createSlice(
    {
        name:"posts",
        initialState,
        reducers:
        {
        },
        extraReducers:(builder)=>
        {
            builder.addCase(fetchPosts.pending,(state)=>
            {
                state.loading = true;
                
            })
            .addCase(fetchPosts.rejected,(state)=>
            {
                state.loading = false;
                state.error = true;
            })
            .addCase(fetchPosts.fulfilled, (state,action:PayloadAction<Post[]>)=>
            {
                state.loading = false;
                state.Posts = action.payload;
            })
            .addCase(createPost.fulfilled,(state,action:PayloadAction<Post>)=>
            {
                state.Posts.push(action.payload)
            })
            .addCase(updatePost.fulfilled,(state,action:PayloadAction<Post>)=>
            {
                let index = state.Posts.findIndex(p=>p.id === action.payload.id);
                state.Posts[index] = action.payload;
            })
            .addCase(deletePost.fulfilled,(state,action:PayloadAction<number>)=>
            {
               state.Posts = state.Posts.filter(p=>p.id !== action.payload)
            })

        }
        
    }
)
export default postsSlice.reducer;