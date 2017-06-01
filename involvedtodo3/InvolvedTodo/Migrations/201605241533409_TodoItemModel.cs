namespace InvolvedTodo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodoItemModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TodoItems", name: "TodoList_Id", newName: "ToDoListId");
            RenameIndex(table: "dbo.TodoItems", name: "IX_TodoList_Id", newName: "IX_ToDoListId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TodoItems", name: "IX_ToDoListId", newName: "IX_TodoList_Id");
            RenameColumn(table: "dbo.TodoItems", name: "ToDoListId", newName: "TodoList_Id");
        }
    }
}
