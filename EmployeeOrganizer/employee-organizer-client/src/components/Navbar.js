import { Container, Navbar, Nav } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import { persistor } from "../redux/store";
import { useNavigate } from "react-router-dom";

const NavBar = () => {


    const navigator = useNavigate();
    const logout = () => {
        localStorage.clear();
        persistor.purge();
        navigator("/login")
    }

    const token = localStorage.getItem("token");
    const username = localStorage.getItem('username');

    return (
        <div>
            <Navbar bg="dark" variant="dark">
                <Container>
                    <Navbar.Brand>Employee Organizer</Navbar.Brand>
                    {token &&
                        <>
                            <Nav className="me-auto">
                                <Nav.Link href="/">Home</Nav.Link>
                                <Nav.Link href="/register">New employee</Nav.Link>
                                <Nav.Link onClick={logout}>Logout</Nav.Link>
                            </Nav>
                            <Navbar.Brand>{username}</Navbar.Brand>
                        </>
                    }
                </Container>
            </Navbar>
            <br />
        </div>
    );
}

export default NavBar;