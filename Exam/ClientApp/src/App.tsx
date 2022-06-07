import React, { Component } from 'react';
import { Route , Routes} from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';

import './custom.css'
import {CreditForm} from "./components/CreditForm";

export default class App extends Component {
    static displayName = App.name;

  render () {
    return (
        <Layout>
            <Routes>
                <Route path='/' element={<Home/>} />
                <Route path='/pageCredit' element={<CreditForm/>}/>
            </Routes>
        </Layout>
    );
  }
}

/*
import * as React from 'react';
import {Route} from 'react-router';
import {Layout} from './components/Layout';
import {Home} from './components/Home';
import {CreditForm} from './components/CreditForm';
import {FetchData} from './components/FetchData';

import './custom.css'

export function App() {
    return (
        <Layout>
            <Route exact path='/' component={Home}/>
            <Route path='/pageCredit' component={CreditForm}/>
            <Route path='/fetch-data' component={FetchData}/>
        </Layout>
    )
}*/
