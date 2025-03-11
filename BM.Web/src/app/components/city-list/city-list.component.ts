import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { CityGridModel } from 'src/app/models/city/city-grid-model';
import { CityService } from 'src/app/services/city.service';

@Component({
  selector: 'app-city-list',
  templateUrl: './city-list.component.html',
  styleUrls: ['./city-list.component.scss']
})
export class CityListComponent {
    
  cities: CityGridModel[] = [];

  constructor(private cityService: CityService, private toastrService: ToastrService, 
    private spinnerService: NgxSpinnerService) { }

  ngOnInit() {
    this.getCities();
  }
  
  private getCities(): void {
    this.spinnerService.show();
    this.cityService.getAllAsync().subscribe((result: CityGridModel[]) => {
      this.cities = result;
      this.spinnerService.hide();
    },
    (error: any) => {
      this.spinnerService.hide();
      this.toastrService.error("City cannot load! Please, try again.", "Error");
    })
  }
  
  onClickDelete(cityId: number): void {
    this.spinnerService.show();
    this.cityService.deleteAsync(cityId).subscribe((result: boolean) => {
      this.spinnerService.hide();
      this.getCities();
      return this.toastrService.success("City delete successfull.", "Success.");
    },
    (errro: any) => {
      this.spinnerService.hide();
      return this.toastrService.error("City cannot deleted! Please, try again.", "Error");
    })
  }  
}
