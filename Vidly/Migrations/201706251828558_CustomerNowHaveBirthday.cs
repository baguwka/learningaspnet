namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerNowHaveBirthday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birtday", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Birtday");
        }
    }
}
