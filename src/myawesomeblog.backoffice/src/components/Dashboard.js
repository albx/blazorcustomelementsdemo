import { useCallback, useEffect, useState } from "react";
import PostItem from "./PostItem";
import axios from "axios";

function Dashboard() {
    const [posts, setPostList] = useState([])

    useEffect(() => {
        const loadPosts = async () => {
            const postsJson = await axios.get('/api/posts');
            const posts = postsJson.data;
            setPostList(posts);
        }
        
        loadPosts();
    }, []);

    const deletePost = useCallback(async (post) => {
        try {
            await axios.delete(`/api/posts/${post.id}`);
            alert(`Post ${post.title} deleted successfully!`);
            
            const postsJson = await axios.get('/api/posts');
            const posts = postsJson.data;
            setPostList(posts);
        } catch (error) {
            alert(`There was an error deleting ${post.title}`);
        }
    }, [])

    return (
        <>
            <h1>All my posts</h1>
            <hr />
            <div className="list-group">
                {posts.map(p => (
                    <PostItem post={p} onDelete={deletePost} key={p.id} />
                ))}
            </div>
        </>
    )
}

export default Dashboard;