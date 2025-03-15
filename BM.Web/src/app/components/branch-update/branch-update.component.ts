import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BranchUpdateModel } from 'src/app/models/branch/branch-update-model';
import { BranchViewModel } from 'src/app/models/branch/branch-view-model';
import { CityGridModel } from 'src/app/models/city/city-grid-model';
import { BranchService } from 'src/app/services/branch.service';
import { CityService } from 'src/app/services/city.service';

@Component({
  selector: 'app-branch-update',
  templateUrl: './branch-update.component.html',
  styleUrls: ['./branch-update.component.scss']
})
export class BranchUpdateComponent {
  branchUpdateModel: BranchUpdateModel = new BranchUpdateModel();
  private _branchId: number | undefined;
  cities: CityGridModel[] = [];

  constructor(private branchService: BranchService, private cityService: CityService,
        private toastrService: ToastrService, private spinnerService: NgxSpinnerService,
        private activatedRoute: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.getCities();
    this.getBranchIdByUrl();
    this.getBranchById();
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

  private getBranchIdByUrl(): void {
    this.activatedRoute.params.subscribe(params => {
      this._branchId = +params["recordId"];
    });
  }

  private getBranchById(): void {
    this.spinnerService.show();
    this.branchService.getByIdAsync(this._branchId!).subscribe((result: BranchViewModel) => {
      this.branchUpdateModel = result.updateModel;
      this.spinnerService.hide();
    },
    (error: any) => {
      this.spinnerService.hide();
      this.toastrService.error("City cannot found! Please, try again.", "Error");
    })
  }

  private getValidateBranchCreateFromResult(): boolean {
    if(this.branchUpdateModel.name == undefined || this.branchUpdateModel.name == null || this.branchUpdateModel.name == "") {
      this.toastrService.warning("Please, provide name.", "Warning");
      return false;
    }

    if(this.branchUpdateModel.cityId == undefined || this.branchUpdateModel.cityId == null || this.branchUpdateModel.cityId == 0) {
      this.toastrService.warning("Please, select city.", "Warning");
      return false;
    }

    return true;
  }

  onClickUpdateBranch(): void {

    let isBranchCreateFromValidate: boolean = this.getValidateBranchCreateFromResult();

    if(isBranchCreateFromValidate) {
      this.spinnerService.show();      
      this.branchService.updateAsync(this.branchUpdateModel).subscribe((result: BranchUpdateModel) => {
        this.spinnerService.hide();
        this.toastrService.success("Branch successfully updated.", "Success.");
        return this.router.navigate(["/branches"]);
      },
      (error: any) => {
        this.spinnerService.hide();
        this.toastrService.error("Branch cannot updated! Please, try again.", "Error");
        return;
      })
    }
  }
}
