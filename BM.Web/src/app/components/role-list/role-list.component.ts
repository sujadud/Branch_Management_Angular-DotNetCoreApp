import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { RoleGridModel } from 'src/app/models/role/role-grid-model';
import { RoleService } from 'src/app/services/role.service';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.scss']
})
export class RoleListComponent {
  roles: RoleGridModel[] = [];
   constructor(private roleService: RoleService, private toastrService: ToastrService, 
      private spinnerService: NgxSpinnerService) { }
      
  ngOnInit() {
    this.getRoles();
  }

  private getRoles(): void {
    this.spinnerService.show();
    this.roleService.getAllAsync().subscribe((result: RoleGridModel[]) => {
      this.roles = result;
      this.spinnerService.hide();
    },
    (error: any) => {
      this.spinnerService.hide();
      this.toastrService.error("Role cannot load! Please, try again.", "Error");
    })
  }

  onClickDelete(roleId: number): void {
    this.spinnerService.show();
    this.roleService.deleteAsync(roleId).subscribe((result: boolean) => {
      this.spinnerService.hide();
      this.getRoles();
      return this.toastrService.success("Role delete successfull.", "Success.");
    },
    (errro: any) => {
      this.spinnerService.hide();
      return this.toastrService.error("Role cannot deleted! Please, try again.", "Error");
    })
  }
}