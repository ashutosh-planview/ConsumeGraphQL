using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DTOs;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace WithLibConsumeGQL
{
  internal static class Program
  {
    public static async Task Main()
    {
      Console.WriteLine("Hello, World!");

      // The GraphQL endpoint URL
      const string endpointGQLUrl = "http://localhost:8081/v1/graphql";

      // add authorization token here without prepending 'Bearer ' to it.
      const string tokenBearer =
        "";

      var httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenBearer);

      var graphQLClient = new GraphQLHttpClient(endpointGQLUrl, new NewtonsoftJsonSerializer(), httpClient);

      var request = new GraphQLRequest
      {
        Query = @"
          query GetCurrentUser {
            pvadmin_ {
              getCurrentUser {
                id
                firstName
                lastName
                email
                role
              }
            }
          }
        "
      };

      try
      {
        var response = await graphQLClient.SendQueryAsync<PvadminDto<GetCurrentUserDto>>(request).ConfigureAwait(false);
        
        if (response.Errors == null || response.Errors.Length == 0)
        {
          var currentUser = response.Data.Pvadmin_.GetCurrentUser;
          Console.WriteLine("Current User: \n" + currentUser);
        }
        else
        {
          Console.WriteLine("Something went wrong: \n" + response.Errors);
        }
      }
      catch (Exception e)
      {
        Console.WriteLine("Some exception \n" + e.Message);
      }
    }
  }
}