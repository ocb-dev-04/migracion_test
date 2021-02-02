import React, { Component } from 'react';
import {  Navbar, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';

export class Personas extends Component {
  static displayName = Personas.name;

  constructor(props) {
    super(props);
    this.state = { personas: [], loading: true };
  }

  componentDidMount() {
    this.getInfo();
  }

  static renderPersonasTable(personas) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Apellido</th>
            <th>Pasaporte</th>
            <th>Direccion</th>
            <th>Sexo</th>
          </tr>
        </thead>
        <tbody>
          {personas.map(personas =>
            <tr key={personas.id}>
              <td>{personas.nombre}</td>
              <td>{personas.apellido}</td>
              <td>{personas.pasaporte}</td>
              <td>{personas.direccion}</td>
              <td>{personas.sexo}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Cargando informacion...</em></p>
      :  Personas.renderPersonasTable(this.state.personas);

    return (
      <div>
        <h1 id="tabelLabel" >Listado de personas</h1>
        {contents}
      </div>
    );
  }

  async getInfo()  {
    const response = await fetch('https://localhost:5001/api/personas');
    const data = await response.json();
    this.setState({ personas: data, loading: false, });
  }
}
