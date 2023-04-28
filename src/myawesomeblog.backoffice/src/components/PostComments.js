import React, { useCallback, useEffect, useRef, useState } from "react";
import { Link, useParams } from "react-router-dom";
import axios from "axios";

const buildPostDetailUrl = (id, slug) => `/post/${id}/${slug}`;

function PostComments() {
    const { id, slug } = useParams();

    const loadComments = useCallback(async (postId) => {
        const response = await axios.get(`http://localhost:5238/api/posts/${postId}/comments`);
        return response.data;
    }, []);

    const postComments = useRef(null);

    useEffect(() => {
        loadComments(id)
            .then((comments) => {
                postComments.current.comments = comments;
            });

        postComments.current.title = 'Hello from backoffice';
        postComments.current.onCommentAdded = async (comment) => {
            try {
                const url = `http://localhost:5238/api/posts/${id}/comments`;
                await axios.post(url, comment);

                alert('Comment added successfully!');

                const comments = await loadComments(id);
                postComments.current.comments = comments;
            } catch (error) {
                alert('Error adding a comment');
            }
        }
    }, [loadComments, id, postComments]);

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
            <post-comments post-id={id} ref={postComments}></post-comments>
        </>
    )
}

export default PostComments;