import { useContext } from 'react';
import { NavLink } from 'react-router-dom';
import { AppContext } from '../App';

function Navbar() {
    const appContext = useContext(AppContext);

    return (
        <nav className="navbar navbar-expand-lg bg-light">
            <div className="container-fluid">
                <a className="navbar-brand" href="/">
                    <span>My awesome blog</span>
                </a>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav">
                        <li className="nav-item">
                            <NavLink className="nav-link" to="/">Dashboard</NavLink>
                        </li>
                        <li className="nav-item">
                            <NavLink className="nav-link" to="/new">Create new post</NavLink>
                        </li>
                        <li className='nav-item'>
                            <span>{appContext.userName}</span>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    )
}

export default Navbar;