using System;

using Azure.Identity;

using Azure.Security;

using Azure.Security.KeyVault.Secrets;

namespace key_vault_console_app

{

  class Mod07

  {

    private const string _clientId = "89d0466f-7e55-4d8c-9409-e45f390f0864";
    private const string _clientSecret = "c.Z-3KeH45.o4hj831XHYe7v.fWJah8aQf";
    private const string _tenantId = "a036f98b-5da1-4ac8-890f-7f14769679c1";
    private const string _keyVaultName = "myKeyVault11495";

    static void Main(string[] args)

    {

      string kvUri = $"https://{_keyVaultName}.vault.azure.net";

      var credentials = new ClientSecretCredential(_tenantId, _clientId, _clientSecret);

      var client = new SecretClient(new Uri(kvUri), credentials);
      //   client.SetSecret("mySecret", "P@$$w0rd");

      KeyVaultSecret secret = client.GetSecret("mySecret");
      //   Console.WriteLine($"Name: {secret.Name} - Value: {secret.Value}");

      client.StartDeleteSecret("mySecret");

    }

  }

}