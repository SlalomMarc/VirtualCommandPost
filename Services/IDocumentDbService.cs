using System.Collections.Generic;
using System.Threading.Tasks;

namespace sdcs.vcp
{
    public interface IDocumentDbService
    {
        Task CreateDatabase(string databaseName);

        Task CreateDocumentCollection(string databaseName, string collectionName);

        Task<List<Case>> GetCasesAsync();

        Task SaveCaseAsync(Case MyCase, CpUser myUser, bool isNewItem);

        Task DeleteCase(Case myCase);
    }
}