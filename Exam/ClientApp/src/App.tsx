import React, { Component } from 'react';
import { Route , Routes} from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';

import './custom.css'
import {CreditForm} from "./components/CreditForm";
import {FetchData} from "./components/FetchData";

export default class App extends Component {
    static displayName = App.name;

  render () {
    return (
        <Layout>
            <Routes>
                <Route path='/' element={<Home/>} />
                <Route path='/Credit' element={<CreditForm/>}/>
                <Route path='/fetch-data' element={<FetchData/>}/>
                
            </Routes>
        </Layout>
    );
  }
}
