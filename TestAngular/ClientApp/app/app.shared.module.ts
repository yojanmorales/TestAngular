import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { CustomerDataComponent } from './components/Customers/customersController';
import { TestServices } from '../app/testServices';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        CustomerDataComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'customers', component: CustomerDataComponent },
            { path: '**', redirectTo: 'home' },
            
        ])
    ],
    providers: [TestServices]
})
export class AppModuleShared {
}