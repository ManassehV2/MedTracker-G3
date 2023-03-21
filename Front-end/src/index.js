import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import "./styles/global-css.css";
import { SnackbarProvider } from "notistack";
import { Provider } from "react-redux";
import store from "./state/store/store";
import { GoogleOAuthProvider } from '@react-oauth/google';

const root = ReactDOM.createRoot(document.getElementById("root"));

const googleAuthClientId = '738541741916-vad58hqlqrs7n6q9e90cnl4u8b1k33kv.apps.googleusercontent.com'

root.render(
  <GoogleOAuthProvider clientId={googleAuthClientId} >
    <React.StrictMode>
      <Provider store={store}>
        <SnackbarProvider maxSnack={3}>
          <App />
        </SnackbarProvider>
      </Provider>
    </React.StrictMode>
  </GoogleOAuthProvider>
);
