import { createAsyncThunk, createSlice } from "@reduxjs/toolkit"
import { clientInstance } from "../../config/config"
import { persistAuth, removeAuth } from "../../helpers/authPersistence"
import { loginFullfilled, loginProgress, loginRejected } from "../../helpers/logInstateChangeHelper"
import { getProfileAPI, getUserDataAPI, googleLoginAPI, loginAPI, profileUpdateAPI, SignupAPI } from "../../service/user"

let initialState = {
  loading: false,
  token: localStorage.getItem('token') || '',
  userId: localStorage.getItem('userId') || '',
  fullName: localStorage.getItem('fullName') || '',
  email: localStorage.getItem('email') || '',
  allergies: [],
  medicines: [],
  diagnoses: [],
  vaccines: [],
  documents: [],
  currentUserObjectRaw: '',
  userLogIn: {
    loading: false,
    errorMsg: '',
    successMsg: ''
  },
  userSignup: {
    loading: false,
    errorMsg: '',
    successMsg: ''
  },
  profileUpdate: {
    loading: false,
    errorMsg: '',
    successMsg: ''
  },
  getProfile: {
    loading: false,
    errorMsg: '',
    successMsg: '',
    profileObj: ''
  },
  getUserData: {
    loading: false,
    errorMsg: '',
    successMsg: '',
  }
}


export let userLogin = createAsyncThunk(
  'user/login',
  async ({ email, password }, thunkApi) => {
    try {
      let response = await loginAPI(email, password)
      return response.data

    } catch (error) {
      let errorMsg = error?.response?.data
      return thunkApi.rejectWithValue(errorMsg ? errorMsg : error.message)
    }
  }
)

export let googleLogin = createAsyncThunk(
  'user/googlelogin',
  async ({ token = '' }, thunkApi) => {
    try {
      let response = await googleLoginAPI(token)
      return response.data

    } catch (error) {
      let errorMsg = error?.response?.data
      return thunkApi.rejectWithValue(errorMsg ? errorMsg : error.message)
    }
  }
)


export let userSignup = createAsyncThunk(
  'user/signup',
  async ({ firstName, lastName, email, password }, thunkApi) => {
    try {
      let response = await SignupAPI(firstName, lastName, email, password)
      return response.data

    } catch (error) {
      let errorMsg = error?.response?.data
      return thunkApi.rejectWithValue(errorMsg ? errorMsg : error.message)
    }
  }
)

export let getProfile = createAsyncThunk(
  'user/getProfile',
  async (_ = '', thunkApi) => {
    try {
      console.log('before running***')
      let response = await getProfileAPI()
      console.log('after running***', response)

      return response.data

    } catch (error) {
      console.log('error running***', error)

      let errorMsg = error.response.data?.message
      return thunkApi.rejectWithValue(errorMsg ? errorMsg : error.message)
    }
  }
)

export let getUserData = createAsyncThunk(
  'user/getUserData',
  async (_ = '', thunkApi) => {
    try {
      let response = await getUserDataAPI()

      return response.data

    } catch (error) {

      let errorMsg = error.response.data?.message
      return thunkApi.rejectWithValue(errorMsg ? errorMsg : error.message)
    }
  }
)

export let userProfileUpdate = createAsyncThunk(
  'user/profileUpdate',
  async (profileInformation, thunkApi) => {
    try {
      let response = await profileUpdateAPI(profileInformation)
      return response.data

    } catch (error) {
      let errorMsg = error.response.data?.message
      return thunkApi.rejectWithValue(errorMsg ? errorMsg : error.message)
    }
  }
)



let userSlice = createSlice({
  name: 'user',
  initialState,
  reducers: {

    googleLoginError: (state) => {
      state.userLogIn.errorMsg = 'Google Log in Failled Tryi Again!'
    },
    resetLoginFormStatus: (state) => {
      state.userLogIn.errorMsg = ''
      state.userLogIn.successMsg = ''
      state.userLogIn.loading = false
    },
    resetProfileUpdateFormStatus: (state) => {
      state.profileUpdate.errorMsg = ''
      state.profileUpdate.successMsg = ''
      state.profileUpdate.loading = false
    },
    resetGetProfileStatus: (state) => {
      state.getProfile.errorMsg = ''
      state.getProfile.successMsg = ''
      state.getProfile.loading = false
    },
    resetSignupFormStatus: (state) => {
      state.userSignup.errorMsg = ''
      state.userSignup.successMsg = ''
      state.userSignup.loading = false
    },
    logout: (state) => {
      removeAuth()
      state.allergies = []
      state.diagnoses = []
      state.documents = []
      state.vaccines = []
      state.medicines = []
      state.email = ''
      state.fullName = ''
      state.userId = ''
      state.currentUserObjectRaw = ''
      state.token = ''
      state.getProfile.profileObj = ''
      clientInstance.defaults.headers = {
        "Content-Type": "application/json",
        "ngrok-skip-browser-warning": "true",
        "Authorization": ``,
        "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
      }
    },
    resetUserData: (state) => {
      state.allergies = []
      state.diagnoses = []
      state.documents = []
      state.vaccines = []
      state.medicines = []
      state.email = ''
      state.fullName = ''
    }
  },

  extraReducers: (builder) => {

    // sign up reducer
    builder.addCase(userSignup.pending, (state) => {
      state.userSignup.loading = true
      state.userSignup.errorMsg = ''
      state.userSignup.successMsg = ''
    })

    builder.addCase(userSignup.fulfilled, (state, action) => {
      state.userSignup.loading = false
      state.userSignup.errorMsg = ''
      state.userSignup.successMsg = "Sign up Successfully"
    })

    builder.addCase(userSignup.rejected, (state, action) => {
      state.userSignup.loading = false
      state.userSignup.errorMsg = action.payload
      state.userSignup.successMsg = ''
    })

    // log in reducer
    builder.addCase(userLogin.pending, (state) => {
      loginProgress(state)
    })

    builder.addCase(userLogin.fulfilled, (state, action) => {
     loginFullfilled(state,action)
    })

    builder.addCase(userLogin.rejected, (state, action) => {
      loginRejected(state,action)
    })


    // google log in reducer
    builder.addCase(googleLogin.pending, (state) => {
      loginProgress(state)
    })

    builder.addCase(googleLogin.fulfilled, (state, action) => {
    loginFullfilled(state,action)
    })

    builder.addCase(googleLogin.rejected, (state, action) => {
      loginRejected(state,action)
    })


    // get user data in reducer
    builder.addCase(getUserData.pending, (state) => {
      state.getUserData.loading = true
      state.getUserData.errorMsg = ''
      state.getUserData.successMsg = ''
    })

    builder.addCase(getUserData.fulfilled, (state, action) => {
      state.getUserData.loading = false
      state.currentUserObjectRaw = { user: action.payload }
      state.allergies = action.payload.allergies
      state.vaccines = action.payload.vaccines
      state.diagnoses = action.payload.diagnoses
      state.medicines = action.payload.medicines
      state.documents = action.payload.documents
      state.email = action.payload.email
      state.fullName = action.payload.fullName
      state.userId = action.payload.userId
      state.getUserData.successMsg = "User Data Fetched in Successfully"
      state.getUserData.errorMsg = ''
    })

    builder.addCase(getUserData.rejected, (state, action) => {
      console.log('get user data in faillded', action)
      state.getUserData.loading = false
      state.getUserData.errorMsg = action.payload
      state.getUserData.successMsg = ''
    })

    // profile update reducer
    builder.addCase(userProfileUpdate.pending, (state) => {
      state.profileUpdate.loading = true
      state.profileUpdate.errorMsg = ''
      state.profileUpdate.successMsg = ''
    })

    builder.addCase(userProfileUpdate.fulfilled, (state, action) => {
      state.profileUpdate.loading = false
      state.profileUpdate.errorMsg = ''
      state.profileUpdate.successMsg = 'Profile Update Successfuly'
    })
    builder.addCase(userProfileUpdate.rejected, (state, action) => {
      state.profileUpdate.loading = false
      state.profileUpdate.errorMsg = action.payload
      state.profileUpdate.successMsg = ''
    })

    // get profile data reducer
    builder.addCase(getProfile.pending, (state) => {
      state.getProfile.loading = true
      state.getProfile.errorMsg = ''
      state.getProfile.successMsg = ''
    })

    builder.addCase(getProfile.fulfilled, (state, action) => {
      console.log('profile fetched succwe', action)
      state.getProfile.loading = false
      state.getProfile.errorMsg = ''
      state.getProfile.successMsg = 'Profile Fetched Successfuly'
      state.getProfile.profileObj = action.payload
    })
    builder.addCase(getProfile.rejected, (state, action) => {
      state.getProfile.loading = false
      state.getProfile.errorMsg = action.payload
      state.getProfile.successMsg = ''
    })
  }
})


let userReducer = userSlice.reducer
export let { resetLoginFormStatus, logout, googleLoginError, resetUserData, resetGetProfileStatus, resetSignupFormStatus, resetProfileUpdateFormStatus } = userSlice.actions

export default userReducer