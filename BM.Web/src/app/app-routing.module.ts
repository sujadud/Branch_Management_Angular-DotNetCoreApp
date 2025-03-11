import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CountryListComponent } from './components/country-list/country-list.component';
import { CountryCreateComponent } from './components/country-create/country-create.component';
import { CountryUpdateComponent } from './components/country-update/country-update.component';
import { CityListComponent } from './components/city-list/city-list.component';
import { CityCreateComponent } from './components/city-create/city-create.component';
import { CityUpdateComponent } from './components/city-update/city-update.component';
import { BranchListComponent } from './components/branch-list/branch-list.component';
import { BranchCreateComponent } from './components/branch-create/branch-create.component';
import { BranchUpdateComponent } from './components/branch-update/branch-update.component';
import { RoleListComponent } from './components/role-list/role-list.component';
import { RoleCreateComponent } from './components/role-create/role-create.component';
import { RoleUpdateComponent } from './components/role-update/role-update.component';

const routes: Routes = [
  // For not match url
  { path: "", component: CountryListComponent, pathMatch: "full" },
  { path: "*", component: CountryListComponent, pathMatch: "full" }, 

  // For country
  { path: "countries", component: CountryListComponent, pathMatch: "full" },
  { path: "country/create", component: CountryCreateComponent, pathMatch: "full" },
  { path: "country/update/:recordId", component: CountryUpdateComponent, pathMatch: "full" }, 

  // for city
  { path: "cities", component: CityListComponent, pathMatch: "full" },
  { path: "city/create", component: CityCreateComponent, pathMatch: "full" },
  { path: "city/update/:recordId", component: CityUpdateComponent, pathMatch: "full" },

  // for branch
  { path: "branches", component: BranchListComponent, pathMatch: "full" },
  { path: "branch/create", component: BranchCreateComponent, pathMatch: "full" },
  { path: "branch/update/:recordId", component: BranchUpdateComponent, pathMatch: "full" },

  // for roel
  { path: "roles", component: RoleListComponent, pathMatch: "full" },
  { path: "role/create", component: RoleCreateComponent, pathMatch: "full" },
  { path: "role/update/:recordId", component: RoleUpdateComponent, pathMatch: "full" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }