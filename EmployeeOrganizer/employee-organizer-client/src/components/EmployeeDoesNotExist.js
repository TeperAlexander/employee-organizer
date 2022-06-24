import { Row, Col } from 'react-bootstrap';
import fustrated from '../assets/fustrated.gif'

export const EmployeDoesNotExist = () => {
    return (
        <Row>
            <Col>
                <h1>Invalid id</h1>
                <h2>Employee with the given id does not exist</h2>
                <img src={fustrated} alt="fustrated guy" style={{ paddingTop: "20px" }}></img>
            </Col>
        </Row>
    )
}