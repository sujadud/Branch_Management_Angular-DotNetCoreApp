import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { CountryListComponent } from './components/country-list/country-list.component';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { CountryCreateComponent } from './components/country-create/country-create.component';
import { CountryUpdateComponent } from './components/country-update/country-update.component';
import { CityListComponent } from './components/city-list/city-list.component';
import { CityCreateComponent } from './components/city-create/city-create.component';
import { CityUpdateComponent } from './components/city-update/city-update.component';
import { BranchListComponent } from './components/branch-list/branch-list.component';
import { BranchCreateComponent } from './components/branch-create/branch-create.component';
import { BranchUpdateComponent } from './components/branch-update/branch-update.component';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { RoleListComponent } from './components/role-list/role-list.component';
import { RoleCreateComponent } from './components/role-create/role-create.component';
import { RoleUpdateComponent } from './components/role-update/role-update.component';

@NgModule({
  declarations: [	
    AppComponent,
    EmployeeComponent,
    CountryListComponent,
    CountryCreateComponent,
    CountryUpdateComponent,
    CityListComponent,
    CityCreateComponent,
    CityUpdateComponent,
    BranchListComponent,
    BranchCreateComponent,
    BranchUpdateComponent,
    EmployeeListComponent,
    RoleListComponent,
    RoleCreateComponent,
    RoleUpdateComponent
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    NgxSpinnerModule
  ],

  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }