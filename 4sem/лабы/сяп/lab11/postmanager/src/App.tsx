import React, { useEffect } from 'react';
import logo from './logo.svg';
import './App.css';
import { useDispatch, useSelector } from 'react-redux';
import { Dispatch } from './app/store';
import { fetchPosts } from './posts/postsAPI';
import PostForm from './components/PostForm';
import PostItem from './components/Post';
import { Post } from './posts/postsSlice';

function App() {
  const dispatch = useDispatch<Dispatch>();
  const {Posts,fetching} = useSelector((state:any)=>state.posts)
  useEffect(()=>
  {
    dispatch(fetchPosts());
  },[dispatch]);
  return (
    <div className="mainAPP">
        <h1>Наfetch'il постов</h1>

      <div className="container">
        <div className="creation-form">
          <h2>создать новый пост</h2>
          <PostForm />
        </div>

        <div className="list">
          <h2>список постов</h2>
          <div className="posts-container">
            {Posts.map((post: Post) => (
              <PostItem key={post.id} ppost={post} />
            ))}
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
