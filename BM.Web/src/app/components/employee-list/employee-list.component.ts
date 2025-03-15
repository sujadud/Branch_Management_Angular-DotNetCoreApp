import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { EmployeeGridModel } from 'src/app/models/employee/employee-grid-model';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent {
  employees: EmployeeGridModel[] = [];

  constructor(private empService: EmployeeService, private toastrService: ToastrService, 
    private spinnerService: NgxSpinnerService) {}
  
  ngOnInit() {
    this.getEmployees();
  }

  private getEmployees(): void {
    this.spinnerService.show();
    this.empService.getAllAsync().subscribe((result: EmployeeGridModel[]) => {
      this.employees = result;
      this.spinnerService.hide();
    },
    (error: any) => {
      this.spinnerService.hide();
      this.toastrService.error("Employee cannot load! Please, try again.", "Error");
    })
  }

  onClickDelete(employeeId: number): void {
    this.spinnerService.show();
    this.empService.deleteAsync(employeeId).subscribe((result: boolean) => {
      this.spinnerService.hide();
      this.getEmployees();
      return this.toastrService.success("Employee delete successfull.", "Success.");
    },
    (errro: any) => {
      this.spinnerService.hide();
      return this.toastrService.error("Employee cannot deleted! Please, try again.", "Error");
    })
  }
}
