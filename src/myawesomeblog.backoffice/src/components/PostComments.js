import { useCallback, useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import axios from "axios";

const buildPostDetailUrl = (id, slug) => `/post/${id}/${slug}`;

function PostComments() {
    const { id, slug } = useParams();

    const loadComments = useCallback(async (postId) => {
        const response = await axios.get(`http://localhost:5238/api/posts/${postId}/comments`);
        return response.data;
    }, []);

    useEffect(() => {
        const registerBlazorStart = () => {
            window.Blazor.start().then(() => {
                const postComments = document.querySelector("post-comments");
                const postId = postComments.getAttribute('post-id');

                loadComments(postId)
                    .then((comments) => {
                        postComments.comments = comments;
                    });
        
                postComments.title = 'Hello from backoffice';
                postComments.onCommentAdded = async (comment) => {
                    try {
                        const url = `http://localhost:5238/api/posts/${postId}/comments`;
                        await axios.post(url, comment);

                        alert('Comment added successfully!');

                        const comments = await loadComments(postId);
                        postComments.comments = comments;
                    } catch (error) {
                        alert ('Error adding a comment');
                    }
                }
            })
        }

        registerBlazorStart()
    }, [loadComments]);

    return (
        <>
            <div className="row">
                <div className="col">
                    <h1>Post comments</h1>
                </div>
                <div className="col-auto d-flex align-items-center">
                    <Link className="btn btn-outline-primary" to={buildPostDetailUrl(id, slug)}>back</Link>
                </div>
            </div>
            <hr />
            <post-comments post-id={id}></post-comments>
        </>
    )
}

export default PostComments;