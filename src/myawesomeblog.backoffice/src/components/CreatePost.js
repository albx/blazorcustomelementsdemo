import { useCallback } from "react";
import { useNavigate } from 'react-router-dom'
import PostForm from './PostForm'
import axios from "axios";

function CreatePost() {
    
    const navigate = useNavigate();

    const createNewPost = useCallback(async (post) => {
        try {
            await axios.post('/api/posts', post);
            alert('Post created successfully!');

            navigate('/');
        } catch (error) {
            alert(`Error creating post ${post.title}. Please try again`);
        }
    }, [navigate]);

    return (
        <>
            <h1>Create new post</h1>
            <hr />
            <PostForm onSave={createNewPost} />
        </>
    )
}

export default CreatePost;