import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import './index.css'
import TripApp from "./TripApp.jsx";
import TripForm from "./TripForm.jsx";

ReactDOM.createRoot(document.getElementById('root')).render(
  //<React.StrictMode>
    <TripApp />
  //</React.StrictMode>,
)
