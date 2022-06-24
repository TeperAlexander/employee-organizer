
import { useParams } from 'react-router-dom'
import { useSelector } from 'react-redux';
import { store } from '../redux/store';
import { putEmployee } from '../services/apiService';
import { updateEmployee } from '../redux/actions/stateActions';
import { EmployeeForm } from './EmployeeForm';
import { EmployeDoesNotExist } from './EmployeeDoesNotExist';


export const UpdateEmployee = () => {

    const state = useSelector((state) => state);
    const { id } = useParams();
    const employee = state.employees.find(e => e.id === parseInt(id));

    const formData = {
        id: id,
        name: employee?.name,
        username: employee?.username,
        phoneNumber: employee?.phoneNumber,
        password: '',
        confirmPassword: '',
        rankId: employee ? employee.rankId : '',
        departmentId: employee ? employee.departmentId : '',
        superiorId: employee?.superiorId ? employee?.superiorId : 0,
    };

    const submit = async (data) => {
        return await putEmployee(data);

    }

    const updateState = (data) => {
        store.dispatch(updateEmployee(data));
    }

    if (!employee) {
        return (
            <div>
                <EmployeDoesNotExist></EmployeDoesNotExist>
            </div>
        )
    }

    return (
        <div>
            <EmployeeForm title={'Update employee'} buttonText={'Update'} formObject={formData} submit={submit} updateState={updateState} id={id}></EmployeeForm>
        </div>
    );
}