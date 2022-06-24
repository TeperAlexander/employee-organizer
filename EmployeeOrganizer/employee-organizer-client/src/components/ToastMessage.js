
import { Row, Col, Toast, ToastContainer } from "react-bootstrap";
import { useEffect, useState } from 'react';
import { store } from "../redux/store";
import { setToaster } from "../redux/actions/stateActions";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCircleCheck, faCircleXmark } from '@fortawesome/free-solid-svg-icons'


export const ToastMessage = ({ message, variant }) => {

    const [show, setShow] = useState(true);
    useEffect(() => {
        if (!show) {
            store.dispatch(setToaster())
        }
    }, [show])

    const icon = variant === 'success' ? faCircleCheck : faCircleXmark;

    return (
        <Row>
            <Col xs={6}>
                <ToastContainer position={"top-end"}>
                    <Toast onClose={() => setShow(false)} show={show} delay={2000} autohide bg={variant}>
                        <Toast.Body className="text-white">{message} <br /> <FontAwesomeIcon icon={icon} size="2x" style={{ paddingTop: "10px" }} /></Toast.Body>
                    </Toast>
                </ToastContainer>
            </Col>
        </Row>
    );
} 