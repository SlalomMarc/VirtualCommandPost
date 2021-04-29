using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace sdcs.vcp
{
    public class DocumentDbService : IDocumentDbService
    {
        public List<Case> Items { get; private set; }
        DocumentClient client;
        Uri collectionLink;

        public DocumentDbService()
        {
            client = new DocumentClient(new Uri(Constants.EndpointUri), Constants.PrimaryKey);
            collectionLink = UriFactory.CreateDocumentCollectionUri(Constants.DatabaseName, Constants.CollectionName);
        }

        public async Task CreateDatabase(string databaseName)
        {
            try
            {
                await client.CreateDatabaseIfNotExistsAsync(new Database
                {
                    Id = databaseName
                });
            }
            catch (DocumentClientException ex)
            {
                Debug.WriteLine("Error: ", ex.Message);
            }
        }

        public async Task CreateDocumentCollection(string databaseName, string collectionName)
        {
            try
            {
                // Create collection with 400 RU/s
                await client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection
                    {
                        Id = collectionName
                    },
                    new RequestOptions
                    {
                        OfferThroughput = 400
                    });
            }
            catch (DocumentClientException ex)
            {
                Debug.WriteLine("Error: ", ex.Message);
            }
        }

        public async Task<List<Case>> GetCasesAsync()
        {
            Items = new List<Case>();

            try
            {
                var query = client.CreateDocumentQuery<Case>(collectionLink).AsDocumentQuery();
                while (query.HasMoreResults)
                {
                    Items.AddRange(await query.ExecuteNextAsync<Case>());
                }
            }
            catch (DocumentClientException ex)
            {
                Debug.WriteLine("Error: ", ex.Message);
            }

            return Items;
        }

        public async Task SaveCaseAsync(Case myCase, CpUser myUser, bool isNewItem)
        {
            try
            {
                myCase.LastUpdated = DateTime.Now;
                myCase.LastUpdatedBy = myUser;
                if (isNewItem)
                {
                    myCase.Created = DateTime.Now;
                    myCase.CreatedBy = myUser;
                    myCase.IsDeleted = false;
                    await client.CreateDocumentAsync(collectionLink, myCase);
                }
                else
                {
                    await client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(Constants.DatabaseName, Constants.CollectionName, myCase.Id), myCase);
                }
            }
            catch (DocumentClientException ex)
            {
                Debug.WriteLine("Error: ", ex.Message);
            }
        }

        public async Task DeleteCase(Case myCase, CpUser myUser)
        {
            myCase.IsDeleted = true;
            await SaveCaseAsync(myCase, myUser, false);
        }
    }
}