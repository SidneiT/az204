using System;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace az204_cosmosdemo
{
  class Program
  {

    // The Azure Cosmos DB endpoint for running this sample.
    private static readonly string EndpointUri = "https://sidneimod04demo01.documents.azure.com:443/";
    // The primary key for the Azure Cosmos account.
    private static readonly string PrimaryKey = "70C7T4MVXA4AuInkk1TRS2wa4F9efYxL7NKuxFXet4gZRKFDTsj1BNkcFbCWw54yJBBqboba993JldaoqTyXmQ==";

    // The Cosmos client instance
    private CosmosClient cosmosClient;

    // The database we will create
    private Database database;

    // The container we will create.
    private Container container;

    // The name of the database and container we will create
    private string databaseId = "az204Database";
    private string containerId = "az204Container";


    public static async Task Main(string[] args)
    {
      try
      {
        Console.WriteLine("Beginning operations...\n");
        Program p = new Program();
        await p.CosmosDemoAsync();

      }
      catch (CosmosException de)
      {
        Exception baseException = de.GetBaseException();
        Console.WriteLine("{0} error occurred: {1}", de.StatusCode, de);
      }
      catch (Exception e)
      {
        Console.WriteLine("Error: {0}", e);
      }
      finally
      {
        Console.WriteLine("End of demo, press any key to exit.");
        Console.ReadKey();
      }
    }

    public async Task CosmosDemoAsync()
    {
      // Create a new instance of the Cosmos Client
      this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
      await this.CreateDatabaseAsync();
      await this.CreateContainerAsync();
      await this.CreateItem();
    }

    private async Task CreateDatabaseAsync()
    {
      // Create a new database
      this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
      Console.WriteLine("Created Database: {0}\n", this.database.Id);
    }

    private async Task CreateContainerAsync()
    {
      // Create a new container
      this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/LastName");
      Console.WriteLine("Created Container: {0}\n", this.container.Id);
    }

    private async Task CreateItem()
    {

      this.container = this.database.GetContainer(containerId);

      var item = new
      {
        id = "1",
        FirstName = "Sidnei",
        LastName = "Teixeira"
      };

      var itemIncluido = await this.container.CreateItemAsync(item);

      Console.WriteLine("Item Created");
    }


  }
}
