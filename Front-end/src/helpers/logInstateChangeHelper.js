import { clientInstance } from "../config/config"
import { persistAuth } from "./authPersistence"

export let loginProgress = (state) => {
    state.userLogIn.loading = true
    state.userLogIn.errorMsg = ''
    state.userLogIn.successMsg = ''
}

export let loginFullfilled = (state, action) => {
    state.token = action.payload.token
    clientInstance.defaults.headers = {
        "Content-Type": "application/json",
        "ngrok-skip-browser-warning": "true",
        "Authorization": `${state.token}`,
        "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
    }
    state.userLogIn.loading = false
    state.currentUserObjectRaw = action.payload.user
    state.allergies = action.payload.user.allergies
    state.vaccines = action.payload.user.vaccines
    state.diagnoses = action.payload.user.diagnoses
    state.medicines = action.payload.user.medicines
    state.documents = action.payload.user.documents
    state.email = action.payload.user.email
    state.fullName = action.payload.user.fullName
    state.userLogIn.errorMsg = ''
    state.userId = action.payload.user.userId
    persistAuth({ token: state.token, userId: state.userId, email: state.email, fullName: state.fullName })
    state.userLogIn.successMsg = "User Logged in Successfully"
}

export let loginRejected = (state, action) => {
    state.userLogIn.loading = false
    state.userLogIn.errorMsg = action.payload
    state.userLogIn.successMsg = ''
}

