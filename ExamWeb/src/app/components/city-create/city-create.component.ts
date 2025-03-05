import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { CityCreateModel } from 'src/app/models/city/city-create-model';
import { CountryGridModel } from 'src/app/models/country/country-grid-model';
import { CityService } from 'src/app/services/city.service';
import { CountryService } from 'src/app/services/country.service';

@Component({
  selector: 'app-city-create',
  templateUrl: './city-create.component.html',
  styleUrls: ['./city-create.component.scss']
})
export class CityCreateComponent {

  cityCreateModel: CityCreateModel = new CityCreateModel();
  countries: CountryGridModel[] = [];

  constructor(private cityService: CityService, private countryService: CountryService, 
    private toastrService: ToastrService, private spinnerService: NgxSpinnerService,
   private router: Router) { }

  ngOnInit() { 
    this.getCountries();
  }

  private getCountries(): void {
    this.spinnerService.show();
    this.countryService.getAllAsync().subscribe((result: CountryGridModel[]) => {
      this.countries = result;
      this.spinnerService.hide();
    },
    (error: any) => {
      this.spinnerService.hide();
      this.toastrService.error("Country cannot load! Please, try again.", "Error");
    })
  }
  
  onClickCreateCity(): void {

    let isCityCreateFromValidate: boolean = this.getValidateCityCreateFromResult();

    if(isCityCreateFromValidate) {
      this.spinnerService.show();
      this.cityService.createAsync(this.cityCreateModel).subscribe((result: CityCreateModel) => {
        this.spinnerService.hide();
        this.toastrService.success("City created.", "Success.");
        this.resetCityCreateFrom();
        return this.router.navigate(["/cities"]);
      },
      (error: any) => {
        this.spinnerService.hide();
        this.toastrService.error("City cannot created! Please, try again.", "Error");
        return;
      })
    }
  }

  private getValidateCityCreateFromResult(): boolean {
    if(this.cityCreateModel.name == undefined || this.cityCreateModel.name == null || this.cityCreateModel.name == "") {
      this.toastrService.warning("Please, provide name.", "Warning");
      return false;
    }
    if(this.cityCreateModel.countryId == undefined || this.cityCreateModel.countryId == null || this.cityCreateModel.countryId == 0) {
      this.toastrService.warning("Please, select country.", "Warning");
      return false;
    }

    return true;
  }

  private resetCityCreateFrom(): void {
    this.cityCreateModel = new CityCreateModel();
  }
}
