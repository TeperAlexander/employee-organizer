const phoneRegex = new RegExp('^\\+36[0-9]{9}$');


export const validateEmployee = (formData, fieldsToIgnoreArr = []) => {
    const errors = {};
    Object.keys(formData).forEach(key => {
        if (formData[key] === '' && !fieldsToIgnoreArr.includes(key)) {
            errors[key] = 'Field is required';
        }
    });

    if (formData.name.length < 3 && !errors.name) {
        errors.name = 'Name has to be at least 3 characters long'
    }

    if (formData.username.length < 3 && !errors.username) {
        errors.username = 'Username has to be at least 3 characters long'
    }
    if (!fieldsToIgnoreArr.includes('password')) {
        if (formData.password.length < 8 && !errors.password) {
            errors.password = 'Password has to be at least 8 characters long'
        }

        if (formData.confirmPassword !== formData.password && !errors.confirmPassword && !errors.password) {
            errors.confirmPassword = 'Passwords do not match'
        }
    }

    if (!errors.phoneNumber && !phoneRegex.test(formData.phoneNumber)) {
        errors.phoneNumber = 'Has to start with +36 and has to be 12 characters long';
    }
    return errors;
};