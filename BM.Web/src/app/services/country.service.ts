import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environments';
import { CountryGridModel } from '../models/country/country-grid-model';
import { Observable } from 'rxjs';
import { CountryUpdateModel } from '../models/country/country-update-model';
import { CountryCreateModel } from '../models/country/country-create-model';
import { CountryViewModel } from '../models/country/country-view-model';

@Injectable({
  providedIn: 'root'
})

export class CountryService {

  private appBaseUrl: string = environment.apiUrl;
  constructor(private httpClient: HttpClient) { }

  // Get countries
  getAllAsync(): Observable<CountryGridModel[]> {   
    const getAllAsyncUrl: string = `${this.appBaseUrl}country/getAll`;
    let getCountries: Observable<CountryGridModel[]> = this.httpClient.get<CountryGridModel[]>(getAllAsyncUrl);

    return getCountries;
  }

  // Get country by id
  getByIdAsync(id: number): Observable<CountryViewModel> {   
    const getByIdAsyncUrl: string = `${this.appBaseUrl}country/getById/${id}`;
    let getCountry: Observable<CountryViewModel> = this.httpClient.get<CountryViewModel>(getByIdAsyncUrl);

    return getCountry;
  }

  // Create country
  createAsync(createModel: CountryCreateModel): Observable<CountryCreateModel> {
    const createAsyncUrl: string = `${this.appBaseUrl}country/create`;
    let createCountry: Observable<CountryCreateModel> = this.httpClient.post<CountryCreateModel>(createAsyncUrl, createModel);

    return createCountry;
  }

  // Update country
  updateAsync(updateModel: CountryUpdateModel): Observable<CountryUpdateModel> {
    const updateAsyncUrl: string = `${this.appBaseUrl}country/update`;
    let updateCountry: Observable<CountryUpdateModel> = this.httpClient.put<CountryUpdateModel>(updateAsyncUrl, updateModel);

    return updateCountry;
  }  

  // Delete country by id
  deleteAsync(id: number): Observable<boolean> {
    const deleteAsyncUrl: string = `${this.appBaseUrl}country/delete/${id}`;
    let deleteCountry: Observable<boolean> = this.httpClient.delete<boolean>(deleteAsyncUrl);

    return deleteCountry;
  } 
}