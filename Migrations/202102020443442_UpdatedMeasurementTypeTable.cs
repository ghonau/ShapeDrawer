namespace ShapeDrawer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMeasurementTypeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MeasurementTypes", "ShapeRule_Id", "dbo.ShapeRules");
            DropForeignKey("dbo.ShapeRules", "Shape_Id", "dbo.Shapes");
            DropIndex("dbo.MeasurementTypes", new[] { "ShapeRule_Id" });
            DropIndex("dbo.ShapeRules", new[] { "Shape_Id" });
            RenameColumn(table: "dbo.ShapeRules", name: "Shape_Id", newName: "ShapeId");
            AddColumn("dbo.ShapeRules", "MeasurementTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.ShapeRules", "ShapeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ShapeRules", "ShapeId");
            CreateIndex("dbo.ShapeRules", "MeasurementTypeId");
            AddForeignKey("dbo.ShapeRules", "MeasurementTypeId", "dbo.MeasurementTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ShapeRules", "ShapeId", "dbo.Shapes", "Id", cascadeDelete: true);
            DropColumn("dbo.MeasurementTypes", "ShapeRule_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MeasurementTypes", "ShapeRule_Id", c => c.Int());
            DropForeignKey("dbo.ShapeRules", "ShapeId", "dbo.Shapes");
            DropForeignKey("dbo.ShapeRules", "MeasurementTypeId", "dbo.MeasurementTypes");
            DropIndex("dbo.ShapeRules", new[] { "MeasurementTypeId" });
            DropIndex("dbo.ShapeRules", new[] { "ShapeId" });
            AlterColumn("dbo.ShapeRules", "ShapeId", c => c.Int());
            DropColumn("dbo.ShapeRules", "MeasurementTypeId");
            RenameColumn(table: "dbo.ShapeRules", name: "ShapeId", newName: "Shape_Id");
            CreateIndex("dbo.ShapeRules", "Shape_Id");
            CreateIndex("dbo.MeasurementTypes", "ShapeRule_Id");
            AddForeignKey("dbo.ShapeRules", "Shape_Id", "dbo.Shapes", "Id");
            AddForeignKey("dbo.MeasurementTypes", "ShapeRule_Id", "dbo.ShapeRules", "Id");
        }
    }
}
