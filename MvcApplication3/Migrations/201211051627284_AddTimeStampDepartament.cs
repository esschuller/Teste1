namespace MvcApplication3.Migrations {
	using System;
	using System.Data.Entity.Migrations;

	public partial class AddTimeStampDepartament : DbMigration {
		public override void Up() {
			AddColumn("dbo.Department", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
		}

		public override void Down() {
			DropColumn("dbo.Department", "Timestamp");
		}
	}
}
