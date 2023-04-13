function PostDisplay({ post }) {
    return (
        <>
            <div className="row">
                <div className="col-md-3">Title</div>
                <div className="col-md-9">{post.title}</div>
            </div>
            <div className="row">
                <div className="col-md-3">Slug</div>
                <div className="col-md-9">{post.slug}</div>
            </div>
            <hr />
            <div className="row">
                <div className="col-md-12">Content</div>
            </div>
            <div className="row">
                <div className="col-md-12">{post.content}</div>
            </div>
        </>
    )    
}

export default PostDisplay;