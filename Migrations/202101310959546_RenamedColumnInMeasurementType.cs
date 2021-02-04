namespace ShapeDrawer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedColumnInMeasurementType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MeasurementTypes", "AttributeName", c => c.String());
            DropColumn("dbo.MeasurementTypes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MeasurementTypes", "Name", c => c.String());
            DropColumn("dbo.MeasurementTypes", "AttributeName");
        }
    }
}
