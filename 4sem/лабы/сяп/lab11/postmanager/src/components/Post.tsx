import { useDispatch } from "react-redux";
import { Post } from "../posts/postsSlice";
import { Dispatch } from "../app/store";
import React, { useState } from "react";
import { deletePost, updatePost } from "../posts/postsAPI";
import PostForm from "./PostForm";
interface IPostProp
{
    ppost:Post;
}
interface IeditPostForm
{
    post:Post;
    Save:(post:{title:string,body:string})=>void;
    Cancel: ()=>void;
    fetching:boolean;
}
const EditPostForm:React.FC<IeditPostForm> =({post,Save,Cancel,fetching})=>
{
    const SubmitForm = (event:React.FormEvent)=>
    {
        let post:Post;
        event.preventDefault();
        const data = new FormData(event.currentTarget as HTMLFormElement);
        Save({title:data.get('title') as string,body:data.get('body') as string});
    };
    return (
    <form onSubmit={SubmitForm}>
      <input
        name="title"
        defaultValue={post.title}
        required
      />
      <textarea
        name="body"
        defaultValue={post.body}
        required
        rows={4}
      />
      <button type="submit" disabled={fetching}>
        {fetching ? 'сохраняем!' : 'сохранить'}
      </button>
      <button type="button" onClick={Cancel} disabled={fetching}>
        отмена
      </button>
    </form>
    );
}
const PostItem: React.FC<IPostProp>  = ({ppost})=>
{
    const dispath = useDispatch<Dispatch>();
    const [editing,setEditing] = useState(false);
    const [fetching,setFetching]  = useState(false);
    const UpdatePost =  async(post:{title:string,body:string})=>
    {
        setFetching(true);
        const updatedPost = {
            id:ppost.id,
            title:post.title,
            body:post.body,
            userId:ppost.userId

        };
        await dispath(updatePost(updatedPost)).unwrap()
         setFetching(false);
    };
    const DeletePost = async()=>
    {
        setFetching(true);
        await dispath(deletePost(ppost.id)).unwrap();
    }
    return(
        <div className="post-container">
            <div className="post-id">
                <h4>post id №{ppost.id}</h4>
                <div className="post-buttons">
                 {(()=> {
                    if(!editing)
                    {
                        return <button onClick={()=>setEditing(true)}>Редактировать</button>;
                    } else
                    {
                     return <button onClick={()=>setEditing(false)}>отмена</button>;
                    }
                 })()

                 }
                 <button onClick={DeletePost} disabled={fetching}>удалить</button>
                </div>
            </div>
            {(()=>
            {
                if(editing)
                {
                    return <EditPostForm post={ppost} Save={UpdatePost}
                    Cancel={()=>setEditing(false)}
                    fetching = {fetching}/>
                }
                else
                {
                    return  <div className="post-info">
                        <h4>{ppost.title}</h4>
                        <p>{ppost.body}</p>
                        <p>userid : {ppost.userId}</p>
                    </div>
                }
            })()}
        </div>

    )
}
export default PostItem;