import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { RoleUpdateModel } from 'src/app/models/role/role-update-model';
import { RoleViewModel } from 'src/app/models/role/role-view-model';
import { RoleService } from 'src/app/services/role.service';

@Component({
  selector: 'app-role-update',
  templateUrl: './role-update.component.html',
  styleUrls: ['./role-update.component.scss']
})
export class RoleUpdateComponent {
  roleUpdateModel: RoleUpdateModel = new RoleUpdateModel();
  private _roleId: number | undefined;
  constructor(private roleService: RoleService, private toastrService: ToastrService, 
    private spinnerService: NgxSpinnerService, private activatedRoute: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.getRoleIdByUrl();
    this.getRoleById();
  }

  getRoleIdByUrl(): void {
    this.activatedRoute.params.subscribe(params => {
      this._roleId = +params["recordId"];
    });
  }

  getRoleById(): void {
    this.spinnerService.show();
    this.roleService.getByIdAsync(this._roleId!).subscribe((result: RoleViewModel) => {
      this.roleUpdateModel = result.updateModel;
      this.spinnerService.hide();
    },
    (error: any) => {
      this.spinnerService.hide();
      this.toastrService.error("Role cannot found! Please, try again.", "Error");
    })
  }

  private getRoleUpdateFormValidateResult(): boolean {
    if(this.roleUpdateModel.name == undefined || this.roleUpdateModel.name == null || this.roleUpdateModel.name == "") {
      this.toastrService.warning("Please, provide name.", "Warning");
      return false;
    }    
    return true;
  }

  onClickRoleUpdate(): void {
    if(this.getRoleUpdateFormValidateResult()) {
      this.spinnerService.show();
      this.roleService.updateAsync(this.roleUpdateModel).subscribe((result: RoleUpdateModel) => {
        this.spinnerService.hide();
        this.toastrService.success("Role has been updated.", "Success");
        this.router.navigateByUrl("/role-list");
        return this.router.navigate(["roles"]);
      },
      (error: any) => {
        this.spinnerService.hide();
        this.toastrService.error("Role cannot updated! Please, try again.", "Error");
      })
    }
  }
}
