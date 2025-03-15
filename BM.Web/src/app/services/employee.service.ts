import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { EmployeeGridModel } from '../models/employee/employee-grid-model';
import { EmployeeCreateModel } from '../models/employee/employee-create-model';
import { EmployeeViewModel } from '../models/employee/employee-view-model';
import { EmployeeUpdateModel } from '../models/employee/employee-update-model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private appBaseUrl: string = environment.apiUrl;
  constructor(private httpclient: HttpClient) { }

  getAllAsync(): Observable<EmployeeGridModel[]> {
    const getAllAsyncUrl: string = `${this.appBaseUrl}employee/getAll`;
    let getEmployees: Observable<EmployeeGridModel[]> = this.httpclient.get<EmployeeGridModel[]>(getAllAsyncUrl);
    return getEmployees;
  }

  getByIdAsync(id: number): Observable<EmployeeViewModel> {
    const getByIdAsyncUrl: string = `${this.appBaseUrl}employee/getById/${id}`;
    let getEmployee: Observable<EmployeeViewModel> = this.httpclient.get<EmployeeViewModel>(getByIdAsyncUrl);
    return getEmployee;
  }

  createAsync(createModel: EmployeeCreateModel): Observable<EmployeeCreateModel> {
    const createAsyncUrl: string = `${this.appBaseUrl}employee/create`;
    let createEmployee: Observable<EmployeeCreateModel> = this.httpclient.post<EmployeeCreateModel>(createAsyncUrl, createModel);
    return createEmployee;
  }

  updateAsync(updateModel: EmployeeUpdateModel): Observable<EmployeeUpdateModel> {
    const updateAsyncUrl: string = `${this.appBaseUrl}employee/update`;
    let updateEmployee: Observable<EmployeeUpdateModel> = this.httpclient.put<EmployeeUpdateModel>(updateAsyncUrl, updateModel);
    return updateEmployee;
  }

  deleteAsync(id: number): Observable<boolean> {
    const deleteAsyncUrl: string = `${this.appBaseUrl}employee/delete/${id}`;
    let deleteEmployee: Observable<boolean> = this.httpclient.delete<boolean>(deleteAsyncUrl);
    return deleteEmployee;
  }
}
