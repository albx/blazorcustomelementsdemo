function PostItem({ post }) {
    return (
        <div>
            <h3>{post.title}</h3>
            <small>{post.creationDate}</small>
        </div>
    )
}

export default PostItem;