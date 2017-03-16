namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypesToAddName : DbMigration
    {
        public override void Up()
        {
            Sql("Update membershiptypes set  name='PayAsYouGo' where id=1");
            Sql("Update membershiptypes set  name='Monthly' where id=2");
            Sql("Update membershiptypes set  name='Quarterly' where id=3");
            Sql("Update membershiptypes set  name='Annual' where id=4");
        }
        
        public override void Down()
        {
        }
    }
}
