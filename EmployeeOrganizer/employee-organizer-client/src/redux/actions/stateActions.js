import { ActionTypes } from "../constants/action-types"
import { getInitState } from "../../services/apiService";


export const deleteEmployee = (id) => {
    return {
        type: ActionTypes.DELETE_EMPLOYEE,
        payload: id
    }
}

export const updateEmployee = (employee) => {
    return {
        type: ActionTypes.UPDATE_EMPLOYEE,
        payload: employee
    }
}

export const setToaster = (bool) => {
    return {
        type: ActionTypes.SET_TOASTER,
        payload: bool
    }
}

export const addEmployee = (employee) => {
    return {
        type: ActionTypes.ADD_EMPLOYEE,
        payload: employee
    }
}

export const setInitState = (initState) => {
    return {
        type: ActionTypes.SET_INIT_STATE,
        payload: initState
    }
}

export const setLoaded = (bool) => {
    return {
        type: ActionTypes.SET_LOADED,
        payload: bool
    }
}



export const fetchInitState = () => {
    return (dispatch) => {
        getInitState()
            .then(response => {
                if (response.errors) {
                    localStorage.clear();
                    return;
                }
                dispatch(setInitState(response.data));
            })
    }
}
