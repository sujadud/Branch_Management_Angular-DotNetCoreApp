import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environments';
import { RoleGridModel } from '../models/role/role-grid-model';
import { Observable } from 'rxjs';
import { RoleViewModel } from '../models/role/role-view-model';
import { RoleCreateModel } from '../models/role/role-create-model';
import { RoleUpdateModel } from '../models/role/role-update-model';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  private appBaseUrl: string = environment.apiUrl;
  constructor(private httpClient: HttpClient) { }

  getAllAsync(): Observable<RoleGridModel[]> {
    const getAllAsyncUrl: string = `${this.appBaseUrl}role/getAll`;
    let getRoles: Observable<RoleGridModel[]> = this.httpClient.get<RoleGridModel[]>(getAllAsyncUrl);
    return getRoles;
  }

  getByIdAsync(id: number): Observable<RoleViewModel> {
    const getByIdAsyncUrl: string = `${this.appBaseUrl}role/getById/${id}`;
    let getRole: Observable<RoleViewModel> = this.httpClient.get<RoleViewModel>(getByIdAsyncUrl);
    return getRole;
  }

  createAsync(createModel: RoleCreateModel): Observable<RoleCreateModel> {
    const createAsyncUrl: string = `${this.appBaseUrl}role/create`;
    let createRole: Observable<RoleCreateModel> = this.httpClient.post<RoleCreateModel>(createAsyncUrl, createModel);
    return createRole;
  }

  updateAsync(updateModel: RoleUpdateModel): Observable<RoleUpdateModel> {
    const updateAsyncUrl: string = `${this.appBaseUrl}role/update`;
    let updateRole: Observable<RoleUpdateModel> = this.httpClient.put<RoleUpdateModel>(updateAsyncUrl, updateModel);

    return updateRole;
  }

  deleteAsync(id: number): Observable<boolean> {
    const deleteAsyncUrl: string = `${this.appBaseUrl}role/delete/${id}`;
    let deleteRole: Observable<boolean> = this.httpClient.delete<boolean>(deleteAsyncUrl);
    return deleteRole;
  }
}
