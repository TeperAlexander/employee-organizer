import { useState, useEffect } from "react";
import { Button, Form, Spinner } from "react-bootstrap";
import { useSelector } from 'react-redux';
import { validateEmployee } from '../helpers/validateEmployeeForm';
import { useNavigate } from 'react-router-dom'

export const EmployeeForm = ({ formObject, submit, title, buttonText, updateState, id }) => {

    const [errors, setErrors] = useState({});
    const [formData, setFormData] = useState(formObject);
    const state = useSelector((state) => state);
    const [isSubmitted, setSubmitted] = useState(false);
    const [isPasswordChecked, setPasswordChecked] = useState(false);
    const [isLoading, setLoading] = useState(false);
    const navigator = useNavigate();

    const fieldsToIgnoreArr = id && !isPasswordChecked ? ['password', 'confirmPassword'] : [];



    function handleChange(e) {
        setFormData(prevFormData => {
            return {
                ...prevFormData,
                [e.target.name]: e.target.value
            }
        });
    }

    const showPasswordFields = () => {
        setPasswordChecked(!isPasswordChecked);
    }

    useEffect(() => {
        if (isSubmitted) {
            setErrors(validateEmployee(formData));
        }
    }, [formData]);

    const submitForm = async (e) => {
        e.preventDefault();
        setSubmitted(true);
        const formErrors = validateEmployee(formData, fieldsToIgnoreArr);
        if (Object.keys(formErrors).length > 0) {
            setErrors(formErrors);
            return;
        }
        setLoading(true);
        const result = await submit(formData);
        setLoading(false);
        if (result.errors) {
            setErrors(result.errors);
            return;
        }
        updateState(result.data);
        navigator('/');
    }



    return (
        <div>
            <h1>{title}</h1>
            <Form onSubmit={submitForm} noValidate>
                <Form.Group className="pt-2">
                    <Form.Control type="text" name="name" placeholder="Name" value={formData.name} onChange={handleChange} isInvalid={errors.name}></Form.Control>
                    <Form.Control.Feedback type="invalid">{errors.name}</Form.Control.Feedback>
                </Form.Group>
                <Form.Group className="pt-2">
                    <Form.Control type="text" name="username" placeholder="Username" value={formData.username} onChange={handleChange} isInvalid={errors.username}></Form.Control>
                    <Form.Control.Feedback type="invalid">{errors.username}</Form.Control.Feedback>
                </Form.Group>

                <Form.Group className="pt-2">
                    <Form.Control type="text" name="phoneNumber" placeholder="Phone number" value={formData.phoneNumber} onChange={handleChange} isInvalid={errors.phoneNumber}></Form.Control>
                    <Form.Control.Feedback type="invalid">{errors.phoneNumber}</Form.Control.Feedback>
                    <Form.Text className="text-muted">
                        Example: +36201234567.
                    </Form.Text>
                </Form.Group>

                {!id &&
                    <>
                        <Form.Group className="pt-2">
                            <Form.Control type="password" name="password" placeholder="Password" value={formData.password} onChange={handleChange} isInvalid={errors.password}></Form.Control>
                            <Form.Control.Feedback type="invalid">{errors.password}</Form.Control.Feedback>
                        </Form.Group>
                        <Form.Group className="pt-2">
                            <Form.Control type="password" name="confirmPassword" placeholder="Confirm password" value={formData.confirmPassword} onChange={handleChange} isInvalid={errors.confirmPassword}></Form.Control>
                            <Form.Control.Feedback type="invalid">{errors.confirmPassword}</Form.Control.Feedback>
                        </Form.Group>
                    </>
                }



                <Form.Group className="pt-2">
                    <Form.Select name="rankId" value={formData.rankId} onChange={handleChange} >
                        {state.ranks.map((rank) => (
                            <option key={rank.id} value={rank.id}>{rank.name}</option>
                        ))}
                    </Form.Select>
                    <Form.Control.Feedback type="invalid">{errors.rankId}</Form.Control.Feedback>

                </Form.Group>

                <Form.Group className="pt-2">
                    <Form.Select name="departmentId" value={formData.departmentId} onChange={handleChange} >
                        {state.departments.map((department) => (
                            <option key={department.id} value={department.id}>{department.name} / {department.shortName}</option>
                        ))}
                    </Form.Select>
                    <Form.Control.Feedback type="invalid">{errors.rankId}</Form.Control.Feedback>
                </Form.Group>

                {state.employees.length > 0 &&
                    <Form.Group className="pt-2">
                        <Form.Select name="superiorId" value={formData.superiorId} onChange={handleChange}>
                            {state.employees.filter(e => e.id !== parseInt(id)).map((employee) => (
                                <option key={employee.id} value={employee.id}>{employee.name}</option>
                            ))}
                            <option key={0} value={0}>No superior</option>
                        </Form.Select>
                        <Form.Control.Feedback type="invalid">{errors.rankId}</Form.Control.Feedback>
                    </Form.Group>
                }
                {id &&
                    <Form.Group className="pt-2">
                        <Form.Check
                            inline
                            label="Update password"
                            name="updatePassword"
                            value={isPasswordChecked}
                            onChange={showPasswordFields}
                        />
                    </Form.Group>
                }

                {isPasswordChecked &&
                    <>
                        <Form.Group className="pt-2">
                            <Form.Control type="password" name="password" placeholder="Password" value={formData.password} onChange={handleChange} isInvalid={errors.password}></Form.Control>
                            <Form.Control.Feedback type="invalid">{errors.password}</Form.Control.Feedback>
                        </Form.Group>
                        <Form.Group className="pt-2">
                            <Form.Control type="password" name="confirmPassword" placeholder="Confirm password" value={formData.confirmPassword} onChange={handleChange} isInvalid={errors.confirmPassword}></Form.Control>
                            <Form.Control.Feedback type="invalid">{errors.confirmPassword}</Form.Control.Feedback>
                        </Form.Group>
                    </>
                }
                <Button className="mt-3" variant="primary" type="submit">
                    {!isLoading &&
                        buttonText
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