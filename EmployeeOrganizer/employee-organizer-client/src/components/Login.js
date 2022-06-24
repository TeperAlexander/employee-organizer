import { useState } from "react"
import { useNavigate } from "react-router-dom";
import { fetchInitState } from "../redux/actions/stateActions";
import { store } from '../redux/store';
import { Button, Form, Spinner } from "react-bootstrap";
import { login } from "../services/apiService";


export const Login = () => {

    const [loginData, setLoginData] = useState({ username: '', password: '' });
    const [errors, setErros] = useState({ username: '', password: '' });
    const [showValidate, setShowValidate] = useState(false);
    const [isInValidCredential, setInValidCredential] = useState(false);
    const [isLoading, setLoading] = useState(false);

    const navigator = useNavigate();


    const submit = async (e) => {
        e.preventDefault();
        const form = e.currentTarget;
        if (!form.checkValidity()) {
            setErros({ username: 'Username is required', password: 'Password is required' });
            setShowValidate(true);
            return;
        }
        setLoading(true);
        var response = await login(loginData);
        setLoading(false);

        if (response.errors) {
            setInValidCredential(true);
            setErros(response.errors);
            setShowValidate(false);
            return;
        }
        setInValidCredential(false);
        localStorage.setItem('token', response.data.token);
        localStorage.setItem('userId', response.data.userId);
        localStorage.setItem('username', response.data.username);
        store.dispatch(fetchInitState());
        navigator('/');
    }

    const handleChange = (e) => {
        setLoginData(prevFormData => {
            return {
                ...prevFormData,
                [e.target.name]: e.target.value
            }
        })
    }

    return (
        <div>
            <h3>Login</h3>
            <Form onSubmit={submit} noValidate validated={showValidate} >
                <Form.Group className="pt-2">
                    <Form.Control type="text" name="username" placeholder="Username" value={loginData.username} onChange={handleChange} required isInvalid={isInValidCredential} />
                    <Form.Control.Feedback type="invalid">
                        {errors.username && errors.username}
                    </Form.Control.Feedback>
                </Form.Group>

                <Form.Group className="mt-2">
                    <Form.Control type="password" name="password" placeholder="Password" value={loginData.password} onChange={handleChange} required isInvalid={isInValidCredential} />
                    <Form.Control.Feedback type="invalid">
                        {errors.password}
                    </Form.Control.Feedback>
                </Form.Group>

                <Button className="mt-3" variant="primary" type="submit">

                    {!isLoading &&
                        'Login'
                    }
                    {
                        isLoading &&

                        <Spinner
                            as="span"
                            animation="border"
                            size="sm"
                            role="status"
                            aria-hidden="true"
                        />
                    }
                </Button>
            </Form>
        </div>
    )
}