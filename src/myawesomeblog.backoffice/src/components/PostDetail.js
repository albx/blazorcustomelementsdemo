import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import PostForm from "./PostForm";
import PostDisplay from "./PostDisplay";

function PostDetail() {
    const { id, slug } = useParams();

    const [readonly, setReadonly] = useState(true);
    const [post, setPost] = useState({});

    useEffect(() =>{
        //...api call
        // const loadPostDetail = async () => {
        //     await fetch('...')

        //     //setPost()
        // }

        //loadPostDetail()
    }, [id, slug]);

    return (
        <>
            <h1>{slug}</h1>
            <hr/>
            {readonly ? <PostDisplay post={post} /> : <PostForm post={post} />}
        </>
    )
}

export default PostDetail;