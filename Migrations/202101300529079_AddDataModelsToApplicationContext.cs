namespace ShapeDrawer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataModelsToApplicationContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        MeasurementType_Id = c.Int(),
                        ShapeRule_Id = c.Int(),
                        Shape_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MeasurementTypes", t => t.MeasurementType_Id)
                .ForeignKey("dbo.ShapeRules", t => t.ShapeRule_Id)
                .ForeignKey("dbo.Shapes", t => t.Shape_Id)
                .Index(t => t.MeasurementType_Id)
                .Index(t => t.ShapeRule_Id)
                .Index(t => t.Shape_Id);
            
            CreateTable(
                "dbo.MeasurementTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShapeRules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Shape_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shapes", t => t.Shape_Id)
                .Index(t => t.Shape_Id);
            
            CreateTable(
                "dbo.Shapes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShapeRules", "Shape_Id", "dbo.Shapes");
            DropForeignKey("dbo.Measurements", "Shape_Id", "dbo.Shapes");
            DropForeignKey("dbo.Measurements", "ShapeRule_Id", "dbo.ShapeRules");
            DropForeignKey("dbo.Measurements", "MeasurementType_Id", "dbo.MeasurementTypes");
            DropIndex("dbo.ShapeRules", new[] { "Shape_Id" });
            DropIndex("dbo.Measurements", new[] { "Shape_Id" });
            DropIndex("dbo.Measurements", new[] { "ShapeRule_Id" });
            DropIndex("dbo.Measurements", new[] { "MeasurementType_Id" });
            DropTable("dbo.Shapes");
            DropTable("dbo.ShapeRules");
            DropTable("dbo.MeasurementTypes");
            DropTable("dbo.Measurements");
        }
    }
}
