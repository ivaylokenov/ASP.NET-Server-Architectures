using DefaultTemplate.Application.Common.Mappings;
using DefaultTemplate.Domain.Entities;

namespace DefaultTemplate.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
