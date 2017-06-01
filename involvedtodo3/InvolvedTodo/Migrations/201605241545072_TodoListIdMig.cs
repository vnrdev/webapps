namespace InvolvedTodo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodoListIdMig : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TodoItems", new[] { "ToDoListId" });
            CreateIndex("dbo.TodoItems", "TodoListId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TodoItems", new[] { "TodoListId" });
            CreateIndex("dbo.TodoItems", "ToDoListId");
        }
    }
}
