import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BranchGridModel } from 'src/app/models/branch/branch-grid-model';
import { EmployeeCreateModel } from 'src/app/models/employee/employee-create-model';
import { RoleGridModel } from 'src/app/models/role/role-grid-model';
import { BranchService } from 'src/app/services/branch.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { RoleService } from 'src/app/services/role.service';

@Component({
  selector: 'app-employee-create',
  templateUrl: './employee-create.component.html',
  styleUrls: ['./employee-create.component.scss']
})
export class EmployeeCreateComponent {
  employeeCreateModel: EmployeeCreateModel = new EmployeeCreateModel();
  branchs: BranchGridModel[] = [];
  roles: RoleGridModel[] = [];

  constructor(private empService: EmployeeService, private branchService: BranchService, 
    private roleService: RoleService, private toastrService: ToastrService, 
    private spinnerService: NgxSpinnerService, private router: Router) { }

  ngOnInit() {
    this.getBranchs();
    this.getRoles();
  }    

  private getBranchs(): void {
    this.spinnerService.show();
    this.branchService.getAllAsync().subscribe((result: BranchGridModel[]) => {
      this.branchs = result;
      this.spinnerService.hide();
    },
    (error: any) => {
      this.spinnerService.hide();
      this.toastrService.error("Branch cannot load! Please, try again.", "Error");
    })
  }

  private getRoles(): void {
    this.spinnerService.show();
    this.roleService.getAllAsync().subscribe((result: RoleGridModel[]) => {
      this.roles = result;
      this.spinnerService.hide();
    },
    (error: any) => {
      this.spinnerService.hide();
      this.toastrService.error("Role cannot load! Please, try again.", "Error");
    })
  }

  private getValidateEmployeeCreateFromResult(): boolean {
    if(this.employeeCreateModel.name == undefined || this.employeeCreateModel.name == null || this.employeeCreateModel.name == "") {
      this.toastrService.warning("Please, provide employee name.", "Warning");
      return false;
    }

    if(this.employeeCreateModel.code == undefined || this.employeeCreateModel.code == null || this.employeeCreateModel.code == "") {
      this.toastrService.warning("Please, provide employee code.", "Warning");
      return false;
    }

    if(this.employeeCreateModel.code.length <= 4) {
      console.log(this.employeeCreateModel.code.length);
      this.toastrService.warning("Employee code must be less than 4 characters.", "Warning");
      return false;
    }

    if(this.employeeCreateModel.branchId == undefined || this.employeeCreateModel.branchId == null || this.employeeCreateModel.branchId == 0) {
      this.toastrService.warning("Please, select branch.", "Warning");
      return false;
    }

    if(this.employeeCreateModel.roleId == undefined || this.employeeCreateModel.roleId == null || this.employeeCreateModel.roleId == 0) {
      this.toastrService.warning("Please, select role.", "Warning");
      return false;
    }

    return true;
  }

  private resetEmployeeCreateFrom(): void {
    this.employeeCreateModel = new EmployeeCreateModel();
  }

  onClickCreateEmployee(): void {
    if(this.getValidateEmployeeCreateFromResult()) {
      this.spinnerService.show();
      this.empService.createAsync(this.employeeCreateModel).subscribe((result: EmployeeCreateModel) => {
        this.spinnerService.hide();
        this.toastrService.success("Employee created.", "Success.");
        this.resetEmployeeCreateFrom();
        return this.router.navigate(["/employees"]);
      },
      (error: any) => {
        this.spinnerService.hide();
        this.toastrService.error("Employee cannot created! Please, try again.", "Error");
        return;
      })
    }
  }
}
