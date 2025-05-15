import { convertToObject } from "typescript";
import {Post,NewPost} from './postsSlice'
import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from 'axios';

const POSTS:string = 'https://jsonplaceholder.typicode.com/posts/'

export const fetchPosts = createAsyncThunk<Post[]>('posts/fetchPosts',async ()=>
{
    const response = await axios.get(POSTS);
    return response.data;
});
export const createPost = createAsyncThunk<Post,NewPost>('posts/createPost',async(newpost)=>
{
    const response = await axios.post(POSTS,newpost);
    return response.data;
})
export const updatePost = createAsyncThunk<Post,Post>('posts/updatePosts',async (post)=>
{
    const response = await axios.put(`${POSTS}${post.id}`,post);
    return response.data;
});
export const deletePost = createAsyncThunk<number,number>('posts/deletePosts',async (id)=>
{
    await axios.delete(`${POSTS}${id}`);
    return id;
});