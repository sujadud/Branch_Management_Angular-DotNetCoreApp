import { RoleCreateModel } from "./role-create-model";
import { RoleGridModel } from "./role-grid-model";
import { RoleUpdateModel } from "./role-update-model";

export class RoleViewModel{
    createModel: RoleCreateModel = new RoleCreateModel();
    updateModel: RoleUpdateModel = new RoleUpdateModel();
    gridModel: RoleGridModel = new RoleGridModel();
}