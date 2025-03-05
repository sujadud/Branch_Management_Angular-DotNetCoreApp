import { CountryCreateModel } from "./country-create-model"
import { CountryUpdateModel } from "./country-update-model";
import { CountryGridModel } from "./country-grid-model";

export class CountryViewModel {
    createModel: CountryCreateModel = new CountryCreateModel();
    updateModel:CountryUpdateModel = new CountryUpdateModel();
    gridModel: CountryGridModel = new CountryGridModel();
}