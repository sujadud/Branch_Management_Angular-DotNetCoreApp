import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { CountryGridModel } from 'src/app/models/country/country-grid-model';
import { CountryService } from 'src/app/services/country.service';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.css']
})

export class CountryListComponent implements OnInit {

  // Countries data source
  countries: CountryGridModel[] = [];

  constructor(private countryService: CountryService, private toastrService: ToastrService, 
    private spinnerService: NgxSpinnerService) { }

  ngOnInit() {
    this.getCountries();
  }

  // Get countries
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

  // Delete country
  onClickDelete(countryId: number): void {
    this.spinnerService.show();
    this.countryService.deleteAsync(countryId).subscribe((result: boolean) => {
      this.spinnerService.hide();
      this.getCountries();
      return this.toastrService.success("Country delete successfull.", "Success.");
    },
    (errro: any) => {
      this.spinnerService.hide();
      return this.toastrService.error("Country cannot deleted! Please, try again.", "Error");
    })
  }
}