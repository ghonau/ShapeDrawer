namespace ShapeDrawer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedMeasurementTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Measurements", "MeasurementTypeId", "dbo.MeasurementTypes");
            DropForeignKey("dbo.Measurements", "Shape_Id", "dbo.Shapes");
            DropIndex("dbo.Measurements", new[] { "MeasurementTypeId" });
            DropIndex("dbo.Measurements", new[] { "Shape_Id" });
            DropTable("dbo.Measurements");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeasurementTypeId = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Shape_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Measurements", "Shape_Id");
            CreateIndex("dbo.Measurements", "MeasurementTypeId");
            AddForeignKey("dbo.Measurements", "Shape_Id", "dbo.Shapes", "Id");
            AddForeignKey("dbo.Measurements", "MeasurementTypeId", "dbo.MeasurementTypes", "Id", cascadeDelete: true);
        }
    }
}
