using ShapeDrawer.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ShapeDrawer.Migrations
{    

    internal sealed class Configuration : DbMigrationsConfiguration<ShapeDrawer.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }     

        protected override void Seed(ShapeDrawer.Models.ApplicationDbContext context)
        {
            
        }
    }
}


