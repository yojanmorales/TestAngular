import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { TestServices } from '../../testServices';
import { Customers } from '../../interfaces/Customers';

import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
    selector: 'customersData',
    templateUrl: './Customers.html'
})

export class CustomerDataComponent {
    public title: string = "Hello customers";
    public customerslist: Customers[];
    public objCustomer: Customers;


    constructor(public http: Http, private _testServices: TestServices) {
        this.getCustomers();
        this.initializeForm();

    }


    getCustomers() {
        debugger;
        this._testServices.getCustomers().subscribe(

            data => this.customerslist = data as Customers[]
            
            
        )

        debugger;
    }

    initializeForm() {
        this.objCustomer = {} as Customers;
    }



    save() {


        this._testServices.saveCustomer(this.objCustomer)
            .subscribe((data) => {
                this.initializeForm();
                this.customerslist.push(data as Customers);
                
            }, error => console.error(error));


    }


}
