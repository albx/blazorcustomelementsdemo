import { useEffect } from "react";
import { Link, useParams } from "react-router-dom";
import axios from "axios";

const buildPostDetailUrl = (id, slug) => `/post/${id}/${slug}`;

function PostComments() {
    const { id, slug } = useParams();

    useEffect(() => {
        const registerBlazorStart = () => {
            window.Blazor.start().then(() => {
                const postComments = document.querySelector("post-comments");
                const postId = postComments.getAttribute('post-id');
        
                postComments.title = 'Hello from backoffice';
                postComments.onCommentAdded = async (comment) => {
                    try {
                        const url = `http://localhost:5238/api/posts/${postId}/comments`;
                        await axios.post(url, comment);

                        alert('Comment added successfully!');
                    } catch (error) {
                        alert ('Error adding a comment');
                    }
                }
            })
        }

        registerBlazorStart()
    }, []);

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