import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { EmployeeGridModel } from 'src/app/models/employee/employee-grid-model';
import { EmployeeService } from 'src/app/services/employee.service';
import { RoleService } from 'src/app/services/role.service';
import { BranchService } from 'src/app/services/branch.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent {
  employees: EmployeeGridModel[] = [];
  filteredEmployees: EmployeeGridModel[] = [];

  roles: any[] = [];
  branches: any[] = [];

  selectedRole: string | null = null;
  selectedBranch: string | null = null;

  constructor(
    private empService: EmployeeService,
    private roleService: RoleService,
    private branchService: BranchService,
    private toastrService: ToastrService,
    private spinnerService: NgxSpinnerService
  ) {}

  ngOnInit() {
    this.loadRoles();
    this.loadBranches();
    this.getEmployees();
  }

  private loadRoles(): void {
    this.roleService.getAllAsync().subscribe(
      (result: any[]) => this.roles = result,
      () => this.toastrService.error("Roles cannot load! Please, try again.", "Error")
    );
  }

  private loadBranches(): void {
    this.branchService.getAllAsync().subscribe(
      (result: any[]) => this.branches = result,
      () => this.toastrService.error("Branches cannot load! Please, try again.", "Error")
    );
  }

  private getEmployees(): void {
    this.spinnerService.show();
    this.empService.getAllAsync().subscribe(
      (result: EmployeeGridModel[]) => {
        this.employees = result;
        this.filteredEmployees = [...this.employees];
        this.spinnerService.hide();
      },
      () => {
        this.spinnerService.hide();
        this.toastrService.error("Employee cannot load! Please, try again.", "Error");
      }
    );
  }

  applyFilters(): void {
    this.filteredEmployees = this.employees.filter(emp =>
      (this.selectedRole ? emp.roleName === this.selectedRole : true) &&
      (this.selectedBranch ? emp.branchName === this.selectedBranch : true)
    );
  }

  resetFilters(): void {
    this.selectedRole = null;
    this.selectedBranch = null;
    this.filteredEmployees = [...this.employees];
  }

  onClickDelete(employeeId: number): void {
    this.spinnerService.show();
    this.empService.deleteAsync(employeeId).subscribe(
      () => {
        this.spinnerService.hide();
        this.getEmployees();
        this.toastrService.success("Employee deleted successfully.", "Success.");
      },
      () => {
        this.spinnerService.hide();
        this.toastrService.error("Employee cannot be deleted! Please, try again.", "Error");
      }
    );
  }
}