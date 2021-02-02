import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Personas } from './components/Personas';
import { Solicitudes } from './components/Solicitudes';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/personas' component={Personas} />
        <Route path='/solicitudes' component={Solicitudes} />
      </Layout>
    );
  }
}
