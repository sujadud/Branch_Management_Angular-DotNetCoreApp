import { EmployeeCreateModel } from "../models/employee/employee-create-model";
import { EmployeeGridModel } from "../models/employee/employee-grid-model";
import { EmployeeUpdateModel } from "../models/employee/employee-update-model";

export interface EmployeeViewModel {
    createModel: EmployeeCreateModel;
    updateModel: EmployeeUpdateModel;
    gridModel: EmployeeGridModel;
}