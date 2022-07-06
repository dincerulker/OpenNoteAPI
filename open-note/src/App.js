import './App.css';
import axios from 'axios';

import React, { Component } from 'react'
import { Button, Container, Col, Row, Form, ListGroup } from 'react-bootstrap';


export class App extends Component {

  constructor(props) {
    super(props);
    this.state = { notes: [], note: { id: 0, title: "", content: "" } };
    this.handleChange = this.handleChange.bind(this);
    this.openNote = this.openNote.bind(this);
  }

  componentDidMount() {
    axios.get('https://localhost:7104/api/Notes')
      .then((response) => {
        this.setState({ notes: response.data });
      });
  }

  handleChange(event) {
    this.setState({
      note: {
        ...this.state.note,
        [event.target.name]: event.target.value
      }
    });
  }

  openNote(note, event) {
    event.preventDefault();
    this.setState({
      note: { ...note }
    });
  }


  render() {
    const title = this.state.note.title;
    const content = this.state.note.content;

    return (
      <div className="App h-100">
        <Container fluid className="h-100">
          <Row className="h-100">
            <Col sm="4" md="3" lg="2" className="py-3 bg-light">
              <h1>Notes</h1>
              <ListGroup>
                {this.state.notes.map((x, i) =>
                  <ListGroup.Item key={i} active={x.id == this.state.note.id} action href="#" onClick={(e) => this.openNote(x, e)}  >
                    {x.title}
                  </ListGroup.Item>
                )}
              </ListGroup>
            </Col>
            <Col sm="8" md="9" lg="10" className="py-3" >
              <Form className="h-100 d-flex flex-column">
                <Form.Group className="mb-2">
                  <Form.Control name="title" value={title} onChange={this.handleChange} type="text" placeholder="title" />
                </Form.Group>
                <Form.Group className="mb-2 flex-fill">
                  <Form.Control className="h-100" as="textarea" name="content" value={content} onChange={this.handleChange} cols="30" rows="10" placeholder="write something.." />
                </Form.Group>
                <div>
                  <Button variant="primary" className="me-2">Save</Button>
                  <Button variant="danger">Delete</Button>
                </div>
              </Form>
            </Col>
          </Row>
        </Container>
      </div>
    )
  }
}


export default App;
