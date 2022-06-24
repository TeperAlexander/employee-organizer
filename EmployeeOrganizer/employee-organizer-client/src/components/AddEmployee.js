import { useSelector } from 'react-redux';
import { store } from '../redux/store';
import { addEmployee } from '../redux/actions/stateActions';
import { postEmployee } from '../services/apiService';
import { EmployeeForm } from './EmployeeForm';

export const AddEmployee = () => {
    const state = useSelector((state) => state);

    const formData = {
        name: '',
        username: '',
        phoneNumber: '',
        password: '',
        confirmPassword: '',
        rankId: state?.ranks[0]?.id,
        departmentId: state?.departments[0]?.id,
        superiorId: state?.employees[0]?.id,
    };



    const submit = async (data) => {
        return await postEmployee(data);
    }

    const updateState = (data) => {
        store.dispatch(addEmployee(data));
    }

    return (
        <div>
            <EmployeeForm title={'Register'} buttonText={'Register'} formObject={formData} submit={submit} updateState={updateState}></EmployeeForm>
        </div>
    );
}
