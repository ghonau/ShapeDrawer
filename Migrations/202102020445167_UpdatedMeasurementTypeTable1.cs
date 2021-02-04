namespace ShapeDrawer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMeasurementTypeTable1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ShapeRules", newName: "ShapeMeasurementTypes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ShapeMeasurementTypes", newName: "ShapeRules");
        }
    }
}
