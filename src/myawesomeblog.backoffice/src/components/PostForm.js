import { useState } from "react";
import { useForm } from "react-hook-form";

function PostForm({ post, onSave }) {
    const { register, formState, handleSubmit } = useForm({ values: post });

    const [isNew] = useState(post === undefined);

    return (
        <form onSubmit={handleSubmit(onSave)}>
            <div className="mb-3">
                <label htmlFor="postTitle" className="form-label">Title</label>
                <input type="text" className="form-control" id="postTitle" aria-describedby="postTitle" {...register('title', { required: true })} />
            </div>
            <div className="mb-3">
                <label htmlFor="postSlug" className="form-label">Slug</label>
                <input type="text" className="form-control" id="postSlug" aria-describedby="postSlug" {...register('slug', { required: true, disabled: !isNew })} />
            </div>
            <div className="mb-3">
                <label htmlFor="postContent" className="form-label">Content</label>
                <textarea type="text"
                    className="form-control"
                    id="postContent"
                    aria-describedby="postContent" {...register('content', { required: true })}
                    rows="20"></textarea>
            </div>
            <div className="mb-3">
                <button type="submit" className="btn btn-primary">Save</button>
            </div>
        </form>
    )
}

export default PostForm;