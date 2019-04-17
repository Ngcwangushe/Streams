namespace Streams.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeBirthdateNullableInCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: false));
        }
    }
}
