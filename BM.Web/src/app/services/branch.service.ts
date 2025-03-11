import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environments';
import { BranchGridModel } from '../models/branch/branch-grid-model';
import { BranchViewModel } from '../models/branch/branch-view-model';
import { BranchCreateModel } from '../models/branch/branch-create-model';
import { BranchUpdateModel } from '../models/branch/branch-update-model';

@Injectable({
  providedIn: 'root'
})
export class BranchService {
  private appBaseUrl: string = environment.apiUrl;
  constructor(private httpclient: HttpClient) { }

  getAllAsync(): Observable<BranchGridModel[]> {
    const getAllAsyncUrl: string = `${this.appBaseUrl}branch/getAll`;
    let getBranches: Observable<BranchGridModel[]> = this.httpclient.get<BranchGridModel[]>(getAllAsyncUrl);
    return getBranches;
  }

  getByIdAsync(id: number): Observable<BranchViewModel> {
    console.log(id);
    const getByIdAsyncUrl: string = `${this.appBaseUrl}branch/getById/${id}`;
    let getBranch: Observable<BranchViewModel> = this.httpclient.get<BranchViewModel>(getByIdAsyncUrl);
    return getBranch;
  }

  createAsync(createModel: BranchCreateModel): Observable<BranchCreateModel> {
    const createAsyncUrl: string = `${this.appBaseUrl}branch/create`;
    let createBranch: Observable<BranchCreateModel> = this.httpclient.post<BranchCreateModel>(createAsyncUrl, createModel);
    return createBranch;
  }

  updateAsync(updateModel: BranchUpdateModel): Observable<BranchUpdateModel> {
    const updateAsyncUrl: string = `${this.appBaseUrl}branch/update`;
    let updateBranch: Observable<BranchUpdateModel> = this.httpclient.put<BranchUpdateModel>(updateAsyncUrl, updateModel);
    return updateBranch;
  }

  deleteAsync(id: number): Observable<boolean> {
    const deleteAsyncUrl: string = `${this.appBaseUrl}branch/delete/${id}`;
    let deleteBranch: Observable<boolean> = this.httpclient.delete<boolean>(deleteAsyncUrl);
    return deleteBranch;
  }
}
