import { useState } from "react";
import { useDispatch } from "react-redux"
import { NewPost, Post } from "../posts/postsSlice";
import { createPost } from "../posts/postsAPI";
import { Dispatch } from "../app/store";
const PostForm:React.FC =() =>
{
    const dispath =  useDispatch<Dispatch>();
    const [title,setTitle] = useState<string>('');
    const [body,setBody] = useState<string>('');
    const [userId,setUserId] = useState<number>(0);

    const submit = async(event:React.FormEvent)=>
    {
        event.preventDefault();
        const newPost:NewPost = {title:title,userId:userId,body:body};

        const createdPost = await dispath(createPost(newPost)).unwrap();
        setTitle('');
        setBody('');
    };
    return (
        <form onSubmit={submit}>
            <input type="text" value={title} onChange={(e)=> setTitle(e.target.value)}
            placeholder="title" required></input>
            <textarea  value={body}
        onChange={(e) => setBody(e.target.value)}
        placeholder="Body"
        required></textarea>
        <button type="submit">создать Post</button>
        </form>
    )
}
export default PostForm;