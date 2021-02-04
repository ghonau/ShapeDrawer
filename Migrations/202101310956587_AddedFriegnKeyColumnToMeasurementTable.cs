namespace ShapeDrawer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFriegnKeyColumnToMeasurementTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Measurements", "MeasurementType_Id", "dbo.MeasurementTypes");
            DropIndex("dbo.Measurements", new[] { "MeasurementType_Id" });
            RenameColumn(table: "dbo.Measurements", name: "MeasurementType_Id", newName: "MeasurementTypeId");
            AlterColumn("dbo.Measurements", "MeasurementTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Measurements", "MeasurementTypeId");
            AddForeignKey("dbo.Measurements", "MeasurementTypeId", "dbo.MeasurementTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Measurements", "MeasurementTypeId", "dbo.MeasurementTypes");
            DropIndex("dbo.Measurements", new[] { "MeasurementTypeId" });
            AlterColumn("dbo.Measurements", "MeasurementTypeId", c => c.Int());
            RenameColumn(table: "dbo.Measurements", name: "MeasurementTypeId", newName: "MeasurementType_Id");
            CreateIndex("dbo.Measurements", "MeasurementType_Id");
            AddForeignKey("dbo.Measurements", "MeasurementType_Id", "dbo.MeasurementTypes", "Id");
        }
    }
}
