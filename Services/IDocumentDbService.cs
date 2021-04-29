using System.Collections.Generic;
using System.Threading.Tasks;

namespace sdcs.vcp
{
    public interface IDocumentDbService
    {
        Task CreateDatabase(string databaseName);

        Task CreateDocumentCollection(string databaseName, string collectionName);

        Task<List<Case>> GetCasesAsync();

        Task SaveCaseAsync(Case item, bool isNewItem);

        Task DeleteTodoItemAsync(string id);
    }
}