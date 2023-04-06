import { useEffect, useState } from "react";
import PostItem from "./PostItem";

function Dashboard() {
    //useState vs useEffect (eseguire la funzione passata SOLO se sono verificate delle condizioni)

    const [posts, setPostList] = useState([])

    useEffect(() => {
        const loadPosts = async () => {
            const postsJson = await fetch('/api/....');
            const posts = await postsJson.json();

            setPostList(posts);
        }
        
        loadPosts();
    }, []);

    return (
        <>
            <h1>All my posts</h1>
            <hr />
            {posts.map(p => (
                <PostItem post={p} key={p.id} />
            ))}
        </>
    )
}

export default Dashboard;