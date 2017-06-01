namespace InvolvedTodo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodoListMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TodoItems", "TodoList_Id", c => c.Int());
            CreateIndex("dbo.TodoItems", "TodoList_Id");
            AddForeignKey("dbo.TodoItems", "TodoList_Id", "dbo.TodoLists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoItems", "TodoList_Id", "dbo.TodoLists");
            DropIndex("dbo.TodoItems", new[] { "TodoList_Id" });
            DropColumn("dbo.TodoItems", "TodoList_Id");
            DropTable("dbo.TodoLists");
        }
    }
}
