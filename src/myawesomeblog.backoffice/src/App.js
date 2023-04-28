import React, { useEffect, useState } from 'react';
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
  const [blazorStarted, setBlazorStarted] = useState(false)
  const [starting, setStarting] = useState(false)

  useEffect(() => {
    const startBlazor = async () => {
      if (!blazorStarted && !starting) {
        setStarting(true);

        await window.Blazor.start();
        
        setBlazorStarted(true);
      }
    }

    startBlazor();
  }, [blazorStarted, setBlazorStarted, setStarting, starting])

  return (
    <>
      { blazorStarted && <AppContext.Provider value={userInfo}>
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
      </AppContext.Provider> }
    </>
  );
}

export default App;
