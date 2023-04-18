import { useCallback } from "react";
import { Link } from "react-router-dom";

const buildPostDetailUrl = (post) => `/post/${post.id}/${post.slug}`;

function PostItem({ post, onDelete }) {
    const handleDelete = useCallback(() => {
        if (window.confirm(`You are going to delete post ${post.title}. Are you sure?`)) {
            onDelete(post);
        }
    }, [onDelete, post])

    return (
        <div className="list-group-item list-group-item-action">
            <div className="d-flex w-100 justify-content-between">
                <h5 className="mb-1">
                    <Link to={buildPostDetailUrl(post)}>{post.title}</Link>
                </h5>
                <small>{post.publishDate}</small>
                <button type="button" className="btn btn-outline-danger" onClick={handleDelete}>Delete</button>
            </div>
        </div>
    )
}

export default PostItem;