using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamCore.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitEmployeeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeBranches_Branches_BranchId",
                table: "EmployeeBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeBranches_Employees_EmployeeId",
                table: "EmployeeBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeBranches_Roles_RoleId",
                table: "EmployeeBranches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeBranches",
                table: "EmployeeBranches");

            migrationBuilder.RenameTable(
                name: "EmployeeBranches",
                newName: "BranchEmployees");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeBranches_RoleId",
                table: "BranchEmployees",
                newName: "IX_BranchEmployees_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeBranches_EmployeeId",
                table: "BranchEmployees",
                newName: "IX_BranchEmployees_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeBranches_BranchId",
                table: "BranchEmployees",
                newName: "IX_BranchEmployees_BranchId");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Employees",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchEmployees",
                table: "BranchEmployees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchEmployees_Branches_BranchId",
                table: "BranchEmployees",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchEmployees_Employees_EmployeeId",
                table: "BranchEmployees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchEmployees_Roles_RoleId",
                table: "BranchEmployees",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchEmployees_Branches_BranchId",
                table: "BranchEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchEmployees_Employees_EmployeeId",
                table: "BranchEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchEmployees_Roles_RoleId",
                table: "BranchEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchEmployees",
                table: "BranchEmployees");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "BranchEmployees",
                newName: "EmployeeBranches");

            migrationBuilder.RenameIndex(
                name: "IX_BranchEmployees_RoleId",
                table: "EmployeeBranches",
                newName: "IX_EmployeeBranches_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_BranchEmployees_EmployeeId",
                table: "EmployeeBranches",
                newName: "IX_EmployeeBranches_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_BranchEmployees_BranchId",
                table: "EmployeeBranches",
                newName: "IX_EmployeeBranches_BranchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeBranches",
                table: "EmployeeBranches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeBranches_Branches_BranchId",
                table: "EmployeeBranches",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeBranches_Employees_EmployeeId",
                table: "EmployeeBranches",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeBranches_Roles_RoleId",
                table: "EmployeeBranches",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
