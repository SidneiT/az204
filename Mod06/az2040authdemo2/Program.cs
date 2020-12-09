﻿using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace az2040authdemo
{
  class Program
  {

    private const string _clientId = "60422046-5178-460b-b6ec-c9d4a3286b8f";
    private const string _tenantId = "a036f98b-5da1-4ac8-890f-7f14769679c1";

    public static async Task Main(string[] args)
    {
        var app = PublicClientApplicationBuilder
                    .Create(_clientId)
                    .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
                    .WithRedirectUri("http://localhost")
                    .Build();

      string[] scopes = { "user.read" };

      AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

      Console.WriteLine($"Token:\t{result.AccessToken}");

    }
  }
}
