namespace ShapeDrawer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAttributeNameFromMeasurementTypeTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MeasurementTypes", "AttributeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MeasurementTypes", "AttributeName", c => c.String());
        }
    }
}
