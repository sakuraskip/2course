import { convertToObject } from "typescript";
import {Post,NewPost} from './postsSlice'
const POSTS:string = 'https://jsonplaceholder.typicode.com/posts/'
const axios  = require('axios');

export async function fetchPosts()
{
    try
    {
        const response:Post[] = await axios.get(POSTS);
        return response;
    }
    catch(error)
    {
        console.error(error)
    }
}
export async function createPost(newpost:NewPost)
{
    try
    {
       const response:Post =  await axios.post(POSTS,newpost);
       return response;
       
    }
    catch(error)
    {
        console.error(error);
    }
}
export async function updatePost(post:Post)
{
    try
    {
        const responce:Post = await axios.put(POSTS+post.id);
        return responce;
    }
    catch(error)
    {
        console.error(error)
    }
}
export async function deletePost(id:number)
{
    try
    {
        await axios.delete(POSTS+id);
        return
    }
    catch(error)
    {
        console.error(error);
    }
}