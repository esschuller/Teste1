namespace MvcApplication3.Migrations {
	using System;
	using System.Data.Entity.Migrations;

	public partial class AddStudentObs3 : DbMigration {
		public override void Up() {

			
			AddColumn("dbo.Student", "Obs3", c => c.String(maxLength: 200));
		}

		public override void Down() {
			DropColumn("dbo.Student", "Obs3");

		}
	}
}
