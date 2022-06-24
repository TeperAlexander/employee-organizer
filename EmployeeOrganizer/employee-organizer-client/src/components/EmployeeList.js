import React, { useEffect, useState } from 'react';
import { Row, Col, Container, Table, Form, Button } from "react-bootstrap";
import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom'
import { deleteEmployee, setToaster } from '../redux/actions/stateActions';
import { DeleteConfirmation } from './DeleteConfirmation';
import { store } from '../redux/store';
import { deleteEmployeee } from '../services/apiService';
import { ToastMessage } from './ToastMessage';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTrashCan, faPen } from '@fortawesome/free-solid-svg-icons'
import "bootstrap/dist/css/bootstrap.min.css";



function EmployeeList() {

    const state = useSelector((state) => state);
    const [searches, setSearches] = useState({ name: '', department: '' });
    const [filteredEmployees, setFilteredEmployees] = useState(state.employees);
    const [id, setId] = useState(null);
    const [displayConfirmationModal, setDisplayConfirmationModal] = useState(false);
    const [toast, setToast] = useState({ message: '', variant: '' });
    const navigator = useNavigate();




    const hideConfirmationModal = () => {
        setDisplayConfirmationModal(false);
    };

    const showDeleteModal = (id) => {
        setId(id);
        setDisplayConfirmationModal(true);
    };

    const handleChange = (e) => {

        setSearches(prevSearches => {
            return {
                ...prevSearches,
                [e.target.name]: e.target.value
            }
        });

    }

    const clearFilters = () => {
        setSearches({ name: '', department: '' })
    }


    const handleDelete = async (id) => {
        setDisplayConfirmationModal(false);
        const response = await deleteEmployeee(id);
        if (response.errors) {
            setToast({ message: 'Something went wrong with deleting the employee!', variant: 'danger' });
            store.dispatch(setToaster(true));
            return;
        }

        setToast({ message: 'The employee was succesfully deleted!', variant: 'success' });
        store.dispatch(setToaster(true));
        store.dispatch(deleteEmployee(id));
    }

    const handleUpdate = async (id) => {
        navigator('/update/' + id);
    }

    useEffect(() => {
        setFilteredEmployees(state.employees);
    }, [state])

    useEffect(() => {
        var filteredList = [];
        if (searches.name !== '' || searches.department !== '') {
            filteredList = state.employees.filter(e =>
                e.name.toLowerCase().includes(searches.name.toLowerCase()) &&
                (
                    e.department.name.toLowerCase().includes(searches.department.toLocaleLowerCase()) ||
                    e.department.shortName.toLowerCase().includes(searches.department.toLocaleLowerCase())
                )
            );
        } else {
            filteredList = state.employees;
        }
        setFilteredEmployees(filteredList);
    }, [searches])

    if (state.employees.length > 0) {
        return (
            <Container>

                <div>
                    <h1>Employees</h1>

                    {state.toaster &&
                        <ToastMessage message={toast.message} variant={toast.variant}></ToastMessage>
                    }
                    <Row className='align-items-center'>

                        <Col>
                            <Form className="align-items-center mb-3 mt-3">
                                <Form.Control name="name" className="sm" type="text" placeholder='Search by name' value={searches.name} onChange={handleChange} />
                            </Form>
                        </Col>
                        <Col>
                            <Form className="align-items-center mb-3 mt-3">
                                <Form.Control name="department" className="sm" type="text" placeholder='Search by department' value={searches.department} onChange={handleChange} />

                            </Form>
                        </Col>
                        <Col xs={2}>
                            <Button variant="primary" onClick={clearFilters}>Clear filters</Button>
                        </Col>

                    </Row>
                    <Table striped bordered hover size="sm">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Rank</th>
                                <th>PhoneNumber</th>
                                <th>Department</th>
                                <th colSpan={2}>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            {filteredEmployees.map((element) => (
                                <tr key={element.id}>
                                    <td>{element.name}</td>
                                    <td>{element?.rank?.name}</td>
                                    <td>{element.phoneNumber}</td>
                                    <td>{element?.department?.name} / {element?.department?.shortName}</td>
                                    <td onClick={() => {
                                        showDeleteModal(element.id)
                                    }}>
                                        <div style={{ padding: "5px", cursor: "pointer" }}>
                                            <FontAwesomeIcon icon={faTrashCan} color="red" fixedWidth />
                                        </div>
                                    </td>
                                    <td onClick={() => {
                                        handleUpdate(element.id)
                                    }}>
                                        <div style={{ padding: "5px", cursor: "pointer" }}>
                                            <FontAwesomeIcon icon={faPen} fixedWidth />
                                        </div>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </Table>

                    <DeleteConfirmation
                        showModal={displayConfirmationModal}
                        confirmModal={handleDelete}
                        hideModal={hideConfirmationModal}
                        id={id} message={'Are you sure you want to delete this employee?'} />
                </div>
            </Container>

        )
    } else {
        return <h3>There are currently no employees in the system</h3>
    }
}

export default EmployeeList;
