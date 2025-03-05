import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { CountryUpdateModel } from 'src/app/models/country/country-update-model';
import { CountryViewModel } from 'src/app/models/country/country-view-model';
import { CountryService } from 'src/app/services/country.service';

@Component({
  selector: 'app-country-update',
  templateUrl: './country-update.component.html',
  styleUrls: ['./country-update.component.css']
})

export class CountryUpdateComponent implements OnInit {


  // Country update model
  countryUpdateModel: CountryUpdateModel = new CountryUpdateModel();
  private _countryId: number | undefined;

  constructor(private countryService: CountryService, private toastrService: ToastrService, 
    private spinnerService: NgxSpinnerService, private activatedRoute: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    // Get country id by url
    this.getCountryIdByUrl();

    // Get country by id
    this.getCountryById();
  }

  // Get country id
  private getCountryIdByUrl(): void {
    this.activatedRoute.params.subscribe(params => {
      this._countryId = +params["recordId"]; 
    });
  }

  // Get customer by id
  private getCountryById(): void {
    this.spinnerService.show();
    this.countryService.getByIdAsync(this._countryId!).subscribe((result: CountryViewModel) => {
      this.countryUpdateModel = result.updateModel;
      this.spinnerService.hide();
    },
    (error: any) => {
      this.spinnerService.hide();
      this.toastrService.error("Country cannot found! Please, try again.");
    })
  }

  // Update customer
  onClickCountryUpdate(): void {
    let isCountryFormValidate: boolean = this.getCountryFormValidateResult();

    if(isCountryFormValidate) {
      this.spinnerService.show();
      this.countryService.updateAsync(this.countryUpdateModel).subscribe((result: CountryUpdateModel) => {
        this.spinnerService.hide();
        this.toastrService.success("Country update successfull.", "Successfull");
        return this.router.navigate(["/countries"]);
      },
      (error: any) => {
        this.spinnerService.hide();
        this.toastrService.error("Country cnnot updated! Please, try again.", "Error");
      })
    }  
  }

  // Country form validation
  private getCountryFormValidateResult(): boolean {
    if(this.countryUpdateModel.name == undefined || this.countryUpdateModel.name == null 
      || this.countryUpdateModel.name == "") {
      this.toastrService.warning("Please, provied name.", "Warning.");
      return false;
    }
   
    return true;
  }
}