namespace InvolvedTodo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodoListRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TodoItems", "TodoList_Id", "dbo.TodoLists");
            DropIndex("dbo.TodoItems", new[] { "TodoList_Id" });
            AlterColumn("dbo.TodoItems", "TodoList_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.TodoItems", "TodoList_Id");
            AddForeignKey("dbo.TodoItems", "TodoList_Id", "dbo.TodoLists", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoItems", "TodoList_Id", "dbo.TodoLists");
            DropIndex("dbo.TodoItems", new[] { "TodoList_Id" });
            AlterColumn("dbo.TodoItems", "TodoList_Id", c => c.Int());
            CreateIndex("dbo.TodoItems", "TodoList_Id");
            AddForeignKey("dbo.TodoItems", "TodoList_Id", "dbo.TodoLists", "Id");
        }
    }
}
