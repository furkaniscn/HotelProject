using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class mig_add_staff_updateImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StaffImage",
                table: "Staffs",
                newName: "StaffImageUrl");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Staffs",
                newName: "SocialMedia3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StaffImageUrl",
                table: "Staffs",
                newName: "StaffImage");

            migrationBuilder.RenameColumn(
                name: "SocialMedia3",
                table: "Staffs",
                newName: "ImageUrl");
        }
    }
}
