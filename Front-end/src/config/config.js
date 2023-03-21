import axios from "axios"

export const BASE_URL = 'https://e762-2a0d-5600-41-c000-00-6279.ngrok.io/'

let token = localStorage.getItem('token')

export let clientInstance = axios.create({
    headers: {
        "Content-Type": "application/json",
        "ngrok-skip-browser-warning": "true",
        // "Access-Control-Allow-Origin": "*",
        "Authorization":`${token}`,
        "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
    },
    baseURL: BASE_URL
})

