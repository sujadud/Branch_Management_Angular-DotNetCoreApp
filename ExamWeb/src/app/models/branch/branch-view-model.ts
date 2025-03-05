import { BranchCreateModel } from "./branch-create-model";
import { BranchGridModel } from "./branch-grid-model";
import { BranchUpdateModel } from "./branch-update-model";

export class BranchViewModel {
    createModel: BranchCreateModel = new BranchCreateModel();
    updateModel:BranchUpdateModel = new BranchUpdateModel();
    gridModel: BranchGridModel = new BranchGridModel();
}
