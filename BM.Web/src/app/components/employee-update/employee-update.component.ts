import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BranchGridModel } from 'src/app/models/branch/branch-grid-model';
import { EmployeeUpdateModel } from 'src/app/models/employee/employee-update-model';
import { EmployeeViewModel } from 'src/app/models/employee/employee-view-model';
import { RoleGridModel } from 'src/app/models/role/role-grid-model';
import { BranchService } from 'src/app/services/branch.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { RoleService } from 'src/app/services/role.service';

@Component({
  selector: 'app-employee-update',
  templateUrl: './employee-update.component.html',
  styleUrls: ['./employee-update.component.scss']
})
export class EmployeeUpdateComponent {
  employeeUpdateModel: EmployeeUpdateModel;
  branchs: BranchGridModel[] = [];
  roles: RoleGridModel[] = [];
  private _empId: number | undefined;

  constructor(private empService: EmployeeService, private branchService: BranchService, 
    private roleService: RoleService, private toastrService: ToastrService, 
    private spinnerService: NgxSpinnerService, private router: Router, 
    private activatedRoute: ActivatedRoute) {
      this.employeeUpdateModel = new EmployeeUpdateModel();
    }

  ngOnInit() {
    this.getBranchs();
    this.getRoles();
    this.getEmployeeIdByUrl();
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

  private getEmployeeIdByUrl(): void{
    this.activatedRoute.params.subscribe(params => {
      this._empId = +params["recordId"];
      this.getEmployeeById();
    });
  }

  private getEmployeeById(): void {
    this.spinnerService.show();
    this.empService.getByIdAsync(this._empId!).subscribe((result: EmployeeViewModel) => {
      debugger
      console.log('api data', result);
      console.log('api data updateModel', result); 
          this.employeeUpdateModel = result.employeeUpdate;
          console.log('model load', this.employeeUpdateModel);
         
      this.spinnerService.hide();
    },
    (error: any) => {
      this.spinnerService.hide();
      this.toastrService.error("Employee cannot be found! Please, try again.", "Error");
    });
  }

  private getValidateEmployeeCreateFromResult(): boolean {
    if(this.employeeUpdateModel.name == undefined || this.employeeUpdateModel.name == null || this.employeeUpdateModel.name == "") {
      this.toastrService.warning("Please, provide employee name.", "Warning");
      return false;
    }

    if(this.employeeUpdateModel.code == undefined || this.employeeUpdateModel.code == null || this.employeeUpdateModel.code == "") {
      this.toastrService.warning("Please, provide employee code.", "Warning");
      return false;
    }

    if(this.employeeUpdateModel.code.length <= 4) {
      console.log(this.employeeUpdateModel.code.length);
      this.toastrService.warning("Employee code must be less than 4 characters.", "Warning");
      return false;
    }

    if(this.employeeUpdateModel.branchId == undefined || this.employeeUpdateModel.branchId == null || this.employeeUpdateModel.branchId == 0) {
      this.toastrService.warning("Please, select branch.", "Warning");
      return false;
    }

    if(this.employeeUpdateModel.roleId == undefined || this.employeeUpdateModel.roleId == null || this.employeeUpdateModel.roleId == 0) {
      this.toastrService.warning("Please, select role.", "Warning");
      return false;
    }

    return true;
  }
  
  onClickUpdateEmployee(): void{
    if(this.getValidateEmployeeCreateFromResult()) {
      this.spinnerService.show();
      this.empService.updateAsync(this.employeeUpdateModel).subscribe((result: EmployeeUpdateModel) => {
        this.spinnerService.hide();
        this.toastrService.success("Employee is updated.", "Success");
        return this.router.navigate(["/employees"]);
      },
      (error: any) => {
        this.spinnerService.hide();
        this.toastrService.error("Employee cannot updated! Please, try again.", "Error");
      })
    }
  }
}
