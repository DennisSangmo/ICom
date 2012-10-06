using FluentMigrator;

namespace ICom.Migrations._2012_09_03_Initials
{
    [Migration(1)]
    class UsersTable_201209032333 : Migration
    {
        public override void Up()
        {
            Create.Table("users");
        }

        public override void Down()
        {
            Delete.Table("users");
        }
    }
}
