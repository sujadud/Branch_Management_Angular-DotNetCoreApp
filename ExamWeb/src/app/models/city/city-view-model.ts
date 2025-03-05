import { CityCreateModel } from "./city-create-model";
import { CityUpdateModel } from "./city-update-model";
import { CityGridModel } from "./city-grid-model";

export class CityViewModel {
    createModel: CityCreateModel = new CityCreateModel();
    updateModel:CityUpdateModel = new CityUpdateModel();
    gridModel: CityGridModel = new CityGridModel();
}