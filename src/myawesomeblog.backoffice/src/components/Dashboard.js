import { useEffect, useState } from "react";
import PostItem from "./PostItem";

const postsPromise = new Promise((resolve, reject) => {
    const posts = [
        {
            id: 1,
            title: 'My first post',
            slug: 'my-first-post',
            publishDate: '2023-04-07T00:00:00.000Z'
        },
        {
            id: 2,
            title: 'Another post',
            slug: 'another-post',
            publishDate: '2023-04-07T00:00:00.000Z'
        },
        {
            id: 3,
            title: 'An awesome post, again',
            slug: 'an-awesome-post-again',
            publishDate: '2023-04-07T00:00:00.000Z'
        }
    ]

    resolve(posts)
})

function Dashboard() {
    //useState vs useEffect (eseguire la funzione passata SOLO se sono verificate delle condizioni)

    const [posts, setPostList] = useState([])

    useEffect(() => {
        const loadPosts = async () => {
            //const postsJson = await fetch('/api/....');
            const posts = await postsPromise; //await postsJson.json();

            setPostList(posts);
        }
        
        loadPosts();
    }, []);

    return (
        <>
            <h1>All my posts</h1>
            <hr />
            <div className="list-group">
                {posts.map(p => (
                    <PostItem post={p} key={p.id} />
                ))}
            </div>
        </>
    )
}

export default Dashboard;