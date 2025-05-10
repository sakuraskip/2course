import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { create } from "domain";

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
    Posts:Post[]
}
const initialState:Istate=
{
    Posts:[],
}
const postsSlice = createSlice(
    {
        name:"posts",
        initialState,
        reducers:
        {
            DisplayPosts:()=>
            {
                
            }
        }
    }
)
