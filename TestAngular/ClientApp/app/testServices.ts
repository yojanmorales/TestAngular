import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable() 
export class TestServices {
    myAppUrl: string = "";
    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getCustomers() {
        return this._http.get(this.myAppUrl + 'api/Customers')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getCustomersById(id: number) {
        return this._http.get(this.myAppUrl + "api/Customers/Details/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    saveCustomer(customer) {
        return this._http.post(this.myAppUrl + 'api/Customers', customer)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updateCustomers(Customers) {
        return this._http.put(this.myAppUrl + 'api/Customers/Edit', Customers)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deleteCustomers(id) {
        return this._http.delete(this.myAppUrl + "api/Customers/Delete/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}

