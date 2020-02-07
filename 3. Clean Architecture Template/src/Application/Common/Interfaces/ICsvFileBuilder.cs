using DefaultTemplate.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace DefaultTemplate.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
