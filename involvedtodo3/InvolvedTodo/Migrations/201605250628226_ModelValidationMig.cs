namespace InvolvedTodo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelValidationMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TodoItems", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.TodoItems", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.TodoLists", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TodoLists", "Title", c => c.String());
            AlterColumn("dbo.TodoItems", "Content", c => c.String());
            AlterColumn("dbo.TodoItems", "Title", c => c.String());
        }
    }
}
