import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environments';
import { CityGridModel } from '../models/city/city-grid-model';
import { Observable } from 'rxjs';
import { CityCreateModel } from '../models/city/city-create-model';
import { CityUpdateModel } from '../models/city/city-update-model';
import { CityViewModel } from '../models/city/city-view-model';


@Injectable({
  providedIn: 'root'
})
export class CityService {

  private appBaseUrl: string = environment.apiUrl;
  constructor(private httpClient: HttpClient) { }
  
  getAllAsync(): Observable<CityGridModel[]> {
    const getAllAsyncUrl: string = `${this.appBaseUrl}city/getAll`;
    let getCities: Observable<CityGridModel[]> = this.httpClient.get<CityGridModel[]>(getAllAsyncUrl);
    return getCities;
  }

  getByIdAsync(id: number): Observable<CityViewModel> {
    const getByIdAsyncUrl: string = `${this.appBaseUrl}city/getById/${id}`;
    let getCity: Observable<CityViewModel> = this.httpClient.get<CityViewModel>(getByIdAsyncUrl);
    return getCity;
  }

  createAsync(createModel: CityCreateModel): Observable<CityCreateModel> {
    const createAsyncUrl: string = `${this.appBaseUrl}city/create`;
    let createCity: Observable<CityCreateModel> = this.httpClient.post<CityCreateModel>(createAsyncUrl, createModel);
    return createCity;
  }

  updateAsync(updateModel: CityUpdateModel): Observable<CityUpdateModel> {
    const updateAsyncUrl: string = `${this.appBaseUrl}city/update`;
    let updateCity: Observable<CityUpdateModel> = this.httpClient.put<CityUpdateModel>(updateAsyncUrl, updateModel);
    return updateCity;
  }

  deleteAsync(id: number): Observable<boolean> {
    const deleteAsyncUrl: string = `${this.appBaseUrl}city/delete/${id}`;
    let deleteCity: Observable<boolean> = this.httpClient.delete<boolean>(deleteAsyncUrl);
    return deleteCity;
  }
}
