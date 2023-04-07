import { Link } from "react-router-dom";

const buildPostDetailUrl = (post) => `/post/${post.id}/${post.slug}`;

function PostItem({ post }) {
    return (
        <Link to={buildPostDetailUrl(post)} className="list-group-item list-group-item-action">
            <div className="d-flex w-100 justify-content-between">
                <h5 className="mb-1">{post.title}</h5>
                <small>{post.publishDate}</small>
            </div>
        </Link>
    )
}

export default PostItem;