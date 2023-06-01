import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import UrlCreator from "./pages/urlCreator";
import UrlList from "./pages/urlList";
import "./app.css";

const App = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<UrlCreator />}></Route>
        <Route path="/url-list" element={<UrlList />}></Route>
      </Routes>
    </BrowserRouter>
  );
};

export default App;
