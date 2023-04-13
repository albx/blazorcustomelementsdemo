import { useCallback } from "react";
import { useNavigate } from 'react-router-dom'
import PostForm from './PostForm'

function CreatePost() {
    
    const navigate = useNavigate();

    const createNewPost = useCallback((post) => {
        console.log(post);
        navigate('/');
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