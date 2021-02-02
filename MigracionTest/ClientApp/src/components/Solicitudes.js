import React, { Component } from 'react';

export class Solicitudes extends Component {
  static displayName = Solicitudes.name;

  constructor(props) {
    super(props);
    this.state = { solicitudes: [], loading: true };
  }

  componentDidMount() {
    this.getInfo();
  }

  static renderSolicitudesTable(solicitudes) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Persona</th>
            <th>Estado</th>
            <th>Fecha Creacion</th>
          </tr>
        </thead>
        <tbody>
          {solicitudes.map(solicitudes =>
            <tr key={solicitudes.id}>
              <td>{solicitudes.persona}</td>
              <td>{solicitudes.estado}</td>
              <td>{solicitudes.fechaCreacion}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Cargando informacion...</em></p>
      :  Solicitudes.renderSolicitudesTable(this.state.solicitudes);

    return (
      <div>
        <h1 id="tabelLabel" >Listado de Solicitudes</h1>
        {contents}
      </div>
    );
  }

  async getInfo()  {
    const response = await fetch('https://localhost:5001/api/solicituds');
    const data = await response.json();
    this.setState({ solicitudes: data, loading: false, });
  }
}
