import React, { useEffect } from 'react';
import { Route, Routes } from 'react-router-dom';
import Dashboard from './components/Dashboard';
import './App.css';
import Navbar from './components/Navbar';
import PostDetail from './components/PostDetail';
import CreatePost from './components/CreatePost';
import PostComments from './components/PostComments';

const userInfo = {
  userRole: 'administrator',
  userName: 'Admin'
};

export const AppContext = React.createContext({})

function App() {
  useEffect(() => {
    sessionStorage.setItem('user:role', userInfo.userRole);
    sessionStorage.setItem('user:name', userInfo.userName);
  }, [])

  return (
    <>
      <AppContext.Provider value={userInfo}>
        <header>
          <Navbar />
        </header>
        <main>
          <div className="container-fluid">
            <Routes>
              <Route path='/' element={<Dashboard />} />
              <Route path='/post/:id/:slug' element={<PostDetail />} />
              <Route path='/new' element={<CreatePost />} />
              <Route path='/post/:id/:slug/comments' element={<PostComments />} />
            </Routes>
          </div>
        </main>
      </AppContext.Provider>
    </>
  );
}

export default App;
