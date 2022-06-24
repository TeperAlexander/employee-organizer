import axios from 'axios';



const Activites = {
    UPDATE_EMPLOYEE: 'UPDATE_EMPLOYEE',
    DELETE_EMPLOYEE: 'DELETE_EMPLOYEE',
    ADD_EMPLOYEE: 'ADD_EMPLOYEE'
}

const baseUrl = 'https://localhost:44329/api/';
const client = axios.create({
    baseURL: baseUrl,
});

// Using interceptors because at creation the token is not present in the localstorage
client.interceptors.request.use(
    config => {
        config.headers = {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + localStorage.getItem('token')
        }
        return config;
    },
    error => {
        Promise.reject(error);
    });

client.interceptors.response.use((response) => {
    return response;
},
    (error) => {

        if (error.response.status === 401) {
            localStorage.clear();
            window.location.href = '/login';
        }
        return Promise.reject(error);

    });

export const postEmployee = async (employee) => {
    const errors = {};
    var response;
    try {
        response = await client.post('employee', employee);
        postActivity(Activites.ADD_EMPLOYEE, response.data.id);
    } catch (err) {
        errors.username = 'The username is taken';
    }
    return { data: response?.data, errors: checkForErrors(errors) };
}

export const putEmployee = async (employee) => {
    const errors = {};
    var response;
    try {
        response = await client.put('employee', employee);
        postActivity(Activites.UPDATE_EMPLOYEE, response.data.id);
    } catch (err) {
        errors.username = 'The username is taken';
    }
    return { data: response?.data, errors: checkForErrors(errors) };
}

export const deleteEmployeee = async (employeeId) => {
    const errors = {};

    try {
        await client.delete('employee/' + employeeId);
        postActivity(Activites.DELETE_EMPLOYEE, employeeId);
    } catch (err) {
        errors.message = 'Error during deleting the employee';
    }


    return { errors: checkForErrors(errors) }
}

export const login = async (credentials) => {
    const errors = {};
    // Not using the client here because this is an unauthroized request
    var response;
    try {
        response = await axios.post(baseUrl + 'auth', credentials);
    } catch (err) {
        errors.password = 'Username or password is invalid';
    }
    return { data: response?.data, errors: checkForErrors(errors) };
}

export const getInitState = async () => {
    const errors = {};
    var response;
    try {
        response = await client.get('home');
    } catch (err) {
        errors.message = 'Unauthorized request!'
    }

    return { data: response?.data, errors: checkForErrors(errors) }
}

const postActivity = (action, employeeId) => {
    const activity = {
        userId: localStorage.getItem('userId'),
        username: localStorage.getItem('username'),
        name: action,
        employeeId: employeeId
    }
    client.post('activity', activity);
}


const checkForErrors = (errors) => {
    return Object.keys(errors).length > 0 ? errors : null;
}


