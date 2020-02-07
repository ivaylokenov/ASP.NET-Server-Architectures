using DefaultTemplate.Application.Common.Interfaces;
using DefaultTemplate.Application.TodoLists.Queries.ExportTodos;
using DefaultTemplate.Infrastructure.Files.Maps;
using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace DefaultTemplate.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);

                csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}
