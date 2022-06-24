import { Col, Row } from "react-bootstrap"
import not_found from '../assets/not_found.gif'


export const PageNotFound = () => {
    return (
        <Row>
            <Col>
                <h1>404</h1>
                <h2>We are sorry but the page you are looking for was not found</h2>
                <img src={not_found} alt="not found gif" width={300} style={{ paddingTop: "20px" }}></img>
            </Col>
        </Row>
    )
}