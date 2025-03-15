import { EmployeeCreateModel } from "./employee-create-model";
import { EmployeeGridModel } from "./employee-grid-model";
import { EmployeeUpdateModel } from "./employee-update-model";

export class EmployeeViewModel {
    createModel: EmployeeCreateModel = new EmployeeCreateModel();    
    employeeUpdate: EmployeeUpdateModel = new EmployeeUpdateModel();
    gridModel: EmployeeGridModel = new EmployeeGridModel();
}