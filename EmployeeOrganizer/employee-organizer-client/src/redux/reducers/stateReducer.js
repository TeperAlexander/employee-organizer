import { ActionTypes } from "../constants/action-types";

export const initialState = {
    employees: [],
    ranks: [],
    departments: [],
    toaster: false,
    isLoaded: false,
};


export const stateReducer = (state = initialState, { type, payload }) => {
    switch (type) {
        case ActionTypes.SET_INIT_STATE:
            mapEmployees(payload);
            return { ...state, employees: payload.employees, ranks: payload.ranks, departments: payload.departments, isLoaded: true };
        case ActionTypes.ADD_EMPLOYEE:
            mapEmployee(payload, state);
            return { ...state, employees: [...state.employees, payload] }
        case ActionTypes.DELETE_EMPLOYEE:
            return { ...state, employees: state.employees.filter(e => e.id !== payload) }
        case ActionTypes.UPDATE_EMPLOYEE:
            mapEmployee(payload, state)
            return { ...state, employees: state.employees.map(e => e.id === payload.id ? payload : e) }
        case ActionTypes.SET_TOASTER:
            return { ...state, toaster: payload }
        case ActionTypes.SET_LOADED:
            return { ...state, isLoaded: payload }
        default:
            return state;
    }
}

// Gets the rank, department and superior objects for the employee
// I do it here because I don't want to join the tables on the server side to get the data
const mapEmployee = (employee, state) => {
    employee.rank = state.ranks.find(r => r.id === employee.rankId);
    employee.department = state.departments.find(d => d.id === employee.departmentId);
    employee.superior = state.employees.find(e => e.id === employee.superiorId);
}

const mapEmployees = (payload) => {
    payload.employees.forEach(employee => {
        employee.rank = payload.ranks.find(r => r.id === employee.rankId);
        employee.department = payload.departments.find(d => d.id === employee.departmentId);
        employee.superior = payload.employees.find(e => e.id === employee.superiorId);
    })
}


