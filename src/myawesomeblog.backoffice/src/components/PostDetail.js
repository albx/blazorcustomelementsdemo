import { useCallback, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import PostForm from "./PostForm";
import PostDisplay from "./PostDisplay";
import axios from "axios";

function PostDetail() {
    const { id, slug } = useParams();

    const [readonly, setReadonly] = useState(true);
    const [post, setPost] = useState({});

    const updatePost = useCallback(async (post) => {
        try {
            await axios.put(`/api/posts/${id}`, post);
            alert('Post updated successfully!');

            setPost(post);
            setReadonly(true);
        } catch (error) {
            alert(`Error updating post ${post.title}`);
        }
    }, [id]);

    const enableEdit = () => setReadonly(false);

    useEffect(() =>{
        const loadPostDetail = async () => {
            const postDetailJson = await axios.get(`/api/posts/${id}`);
            const post = postDetailJson.data;

            setPost(post);
        }

        loadPostDetail();
    }, [id, slug]);

    return (
        <>
            <div className="row">
                <div className="col">
                    <h1>{post.title}</h1>
                </div>
                <div className="col-auto d-flex align-items-center">
                    {readonly && <button type="button" className="btn btn-primary" onClick={enableEdit}>Edit</button>}
                </div>
            </div>
            <hr/>
            {readonly ? <PostDisplay post={post} /> : <PostForm post={post} onSave={updatePost} />}
        </>
    )
}

export default PostDetail;