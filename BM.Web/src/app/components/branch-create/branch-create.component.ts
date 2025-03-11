import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BranchCreateModel } from 'src/app/models/branch/branch-create-model';
import { CityGridModel } from 'src/app/models/city/city-grid-model';
import { BranchService } from 'src/app/services/branch.service';
import { CityService } from 'src/app/services/city.service';

@Component({
  selector: 'app-branch-create',
  templateUrl: './branch-create.component.html',
  styleUrls: ['./branch-create.component.scss']
})
export class BranchCreateComponent {
  branchCreateModel: BranchCreateModel = new BranchCreateModel();
  cities: CityGridModel[] = [];

  constructor(private branchService: BranchService, private cityService: CityService,
      private toastrService: ToastrService, private spinnerService: NgxSpinnerService,
    private router: Router) { }

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

  private getValidateBranchCreateFromResult(): boolean {
    if(this.branchCreateModel.name == undefined || this.branchCreateModel.name == null || this.branchCreateModel.name == "") {
      this.toastrService.warning("Please, provide name.", "Warning");
      return false;
    }

    if(this.branchCreateModel.cityId == undefined || this.branchCreateModel.cityId == null || this.branchCreateModel.cityId == 0) {
      this.toastrService.warning("Please, select city.", "Warning");
      return false;
    }

    return true;
  }

  private resetBranchCreateFrom(): void {
    this.branchCreateModel = new BranchCreateModel();
  }

  onClickCreateBranch(): void {

    let isBranchCreateFromValidate: boolean = this.getValidateBranchCreateFromResult();

    if(isBranchCreateFromValidate) {
      this.spinnerService.show();
      this.branchService.createAsync(this.branchCreateModel).subscribe((result: BranchCreateModel) => {
        this.spinnerService.hide();
        this.toastrService.success("Branch created.", "Success.");
        this.resetBranchCreateFrom();
        return this.router.navigate(["/branches"]);
      },
      (error: any) => {
        this.spinnerService.hide();
        this.toastrService.error("Branch cannot created! Please, try again.", "Error");
        return;
      })
    }
  }
}
