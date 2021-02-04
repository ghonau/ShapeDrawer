namespace ShapeDrawer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedShapeRuleTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Measurements", "ShapeRule_Id", "dbo.ShapeRules");
            DropIndex("dbo.Measurements", new[] { "ShapeRule_Id" });
            AddColumn("dbo.MeasurementTypes", "DispalyName", c => c.String());
            AddColumn("dbo.MeasurementTypes", "ShapeRule_Id", c => c.Int());
            CreateIndex("dbo.MeasurementTypes", "ShapeRule_Id");
            AddForeignKey("dbo.MeasurementTypes", "ShapeRule_Id", "dbo.ShapeRules", "Id");
            DropColumn("dbo.Measurements", "ShapeRule_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Measurements", "ShapeRule_Id", c => c.Int());
            DropForeignKey("dbo.MeasurementTypes", "ShapeRule_Id", "dbo.ShapeRules");
            DropIndex("dbo.MeasurementTypes", new[] { "ShapeRule_Id" });
            DropColumn("dbo.MeasurementTypes", "ShapeRule_Id");
            DropColumn("dbo.MeasurementTypes", "DispalyName");
            CreateIndex("dbo.Measurements", "ShapeRule_Id");
            AddForeignKey("dbo.Measurements", "ShapeRule_Id", "dbo.ShapeRules", "Id");
        }
    }
}
