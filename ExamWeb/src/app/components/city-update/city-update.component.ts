import { Component } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { CityUpdateModel } from 'src/app/models/city/city-update-model';
import { CityViewModel } from 'src/app/models/city/city-view-model';
import { CountryGridModel } from 'src/app/models/country/country-grid-model';
import { CityService } from 'src/app/services/city.service';
import { CountryService } from 'src/app/services/country.service';

@Component({
  selector: 'app-city-update',
  templateUrl: './city-update.component.html',
  styleUrls: ['./city-update.component.scss']
})
export class CityUpdateComponent {

  cityUpdateModel: CityUpdateModel = new CityUpdateModel();
  private _cityId: number | undefined;
  countries: CountryGridModel[] = [];

  constructor(private cityService: CityService, private countryService: CountryService, 
    private toastrService: ToastrService, private spinnerService: NgxSpinnerService,
    private activatedRoute: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.getCountries();
    this.getCityIdByUrl();
    this.getCityById();
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

  private getCityIdByUrl(): void {
    this.activatedRoute.params.subscribe(params => {
      this._cityId = +params["recordId"];
    });
  }
  
  private getCityById(): void {
    this.spinnerService.show();
    this.cityService.getByIdAsync(this._cityId!).subscribe((result: CityViewModel) => {
      this.cityUpdateModel = result.updateModel;
      this.spinnerService.hide();
    },
    (error: any) => {
      this.spinnerService.hide();
      this.toastrService.error("City cannot found! Please, try again.", "Error");
    })
  }

  private getCityUpdateFormValidateResult(): boolean {
    if(this.cityUpdateModel.name == undefined || this.cityUpdateModel.name == null || this.cityUpdateModel.name == "") {
      this.toastrService.warning("Please, provide name.", "Warning");
      return false;
    }

    if(this.cityUpdateModel.countryId == undefined || this.cityUpdateModel.countryId == null) {
      this.toastrService.warning("Please, select country.", "Warning");
      return false;
    }

    return true;
  }

  onClickCityUpdate(): void {
    let isCityUpdateFormValidate: boolean = this.getCityUpdateFormValidateResult();

    if(isCityUpdateFormValidate) {
      this.spinnerService.show();
      this.cityService.updateAsync(this.cityUpdateModel).subscribe((result: CityUpdateModel) => {
        this.spinnerService.hide();
        this.toastrService.success("City updated.", "Success.");
        this.router.navigateByUrl("/city-list");
        return this.router.navigate(["/cities"]);
      },
      (error: any) => {
        this.spinnerService.hide();
        this.toastrService.error("City cannot updated! Please, try again.", "Error");
        return;
      })
    }
  }
}
