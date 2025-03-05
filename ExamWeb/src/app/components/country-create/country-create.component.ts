import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { CountryCreateModel } from 'src/app/models/country/country-create-model';
import { CountryService } from 'src/app/services/country.service';

@Component({
  selector: 'app-country-create',
  templateUrl: './country-create.component.html',
  styleUrls: ['./country-create.component.css']
})

export class CountryCreateComponent implements OnInit {
  
  // Country create model
  countryCreateModel: CountryCreateModel = new CountryCreateModel();
 
  constructor(private countryService: CountryService, private toastrService: ToastrService, 
    private spinnerService: NgxSpinnerService) { }
 
  ngOnInit() { }
 
  // Create country
  onClickUpsertCountry(): void {

    // Check country create from valid or not
    let isCountryCreateFromValidate: boolean = this.getValidateCountryCreateFromResult();

    if(isCountryCreateFromValidate) {
      this.spinnerService.show();
      this.countryService.createAsync(this.countryCreateModel).subscribe((result: CountryCreateModel) => {
        this.spinnerService.hide();
        this.toastrService.success("Country created.", "Success.");
        this.resetCountryCreateFrom();
        return;
      },
      (error: any) => {
        this.spinnerService.hide();
        this.toastrService.error("Country cannot created! Please, try again.", "Error");
        return;
      })
    }

  }

  // Validation country create from
  private getValidateCountryCreateFromResult(): boolean {
    if(this.countryCreateModel.name == undefined || this.countryCreateModel.name == null || this.countryCreateModel.name == "") {
      this.toastrService.warning("Please, provide name.", "Warning");
      return false;
    }

    return true;
  }

  // Reset country create from
  private resetCountryCreateFrom(): void {
    this.countryCreateModel = new CountryCreateModel();
  }
}