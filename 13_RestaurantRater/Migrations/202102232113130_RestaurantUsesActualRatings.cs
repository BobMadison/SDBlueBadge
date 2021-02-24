namespace _13_RestaurantRater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantUsesActualRatings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Owner", c => c.String());
            DropColumn("dbo.Restaurants", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Rating", c => c.Double(nullable: false));
            DropColumn("dbo.Restaurants", "Owner");
        }
    }
}
