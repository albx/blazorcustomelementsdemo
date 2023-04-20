import { Link, useParams } from "react-router-dom";

const buildPostDetailUrl = (id, slug) => `/post/${id}/${slug}`;

function PostComments() {
    const { id, slug } = useParams();

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