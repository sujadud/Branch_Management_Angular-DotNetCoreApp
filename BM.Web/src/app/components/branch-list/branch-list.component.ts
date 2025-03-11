import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BranchGridModel } from 'src/app/models/branch/branch-grid-model';
import { BranchService } from 'src/app/services/branch.service';

@Component({
  selector: 'app-branch-list',
  templateUrl: './branch-list.component.html',
  styleUrls: ['./branch-list.component.scss']
})
export class BranchListComponent {
  branches: BranchGridModel[] = [];
  constructor(private branchService: BranchService, private toastrService: ToastrService, 
      private spinnerService: NgxSpinnerService) { }

  ngOnInit() {
    this.getBranches();
  }

  private getBranches(): void {
    this.spinnerService.show();
    this.branchService.getAllAsync().subscribe((result: BranchGridModel[]) => {
      this.branches = result;
      this.spinnerService.hide();
    },
    (error: any) => {
      this.spinnerService.hide();
      this.toastrService.error("Branch cannot load! Please, try again.", "Error");
    })
  }

  onClickDelete(branchId: number): void {
    this.spinnerService.show();
    this.branchService.deleteAsync(branchId).subscribe((result: boolean) => {
      this.spinnerService.hide();
      this.getBranches();
      return this.toastrService.success("Branch delete successfull.", "Success.");
    },
    (errro: any) => {
      this.spinnerService.hide();
      return this.toastrService.error("Branch cannot deleted! Please, try again.", "Error");
    })
  }
}