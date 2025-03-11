import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { RoleCreateModel } from 'src/app/models/role/role-create-model';
import { RoleService } from 'src/app/services/role.service';

@Component({
  selector: 'app-role-create',
  templateUrl: './role-create.component.html',
  styleUrls: ['./role-create.component.scss']
})
export class RoleCreateComponent {
  roleCreateModel: RoleCreateModel = new RoleCreateModel();
  constructor(private roleService: RoleService, private toastrService: ToastrService, 
      private spinnerService: NgxSpinnerService, private router: Router) { }
   
    ngOnInit() { }
   
  private getValidateCityCreateFromResult(): boolean {
      if(this.roleCreateModel.name == undefined || this.roleCreateModel.name == null || this.roleCreateModel.name == "") {
        this.toastrService.warning("Please, provide role name.", "Warning");
        return false;
      }
  
      return true;
    }
  
  private resetCityCreateFrom(): void {
    this.roleCreateModel = new RoleCreateModel();
  }

onClickCreateRole(): void {

    let isCityCreateFromValidate: boolean = this.getValidateCityCreateFromResult();

    if(isCityCreateFromValidate) {
      this.spinnerService.show();
      console.log(this.roleCreateModel);
      this.roleService.createAsync(this.roleCreateModel).subscribe((result: RoleCreateModel) => {
        console.log(this.roleCreateModel);
        this.spinnerService.hide();
        this.toastrService.success("City created.", "Success.");
        this.resetCityCreateFrom();
        return this.router.navigate(["/roles"]);
      },
      (error: any) => {
        this.spinnerService.hide();
        this.toastrService.error("City cannot created! Please, try again.", "Error");
        return;
      })
    }
  }
}
