using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DTOs;

namespace WithoutLibConsumeGQL
{
  internal static class Program
  {
    public static async Task Main()
    {
      Console.WriteLine("Hello, World! again");

      // The GraphQL endpoint URL
      const string endpointGQLUrl = "http://localhost:8081/v1/graphql";

      // add authorization token here without prepending 'Bearer ' to it.
      const string tokenBearer =
        "";

      var httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenBearer);

      const string query = @"
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
        ";

      var requestBody = new { query };
      var jsonRequestBody = JsonSerializer.Serialize(requestBody);
      var httpContent = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

      try
      {
        var response = await httpClient.PostAsync(endpointGQLUrl, httpContent).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        if (response.IsSuccessStatusCode)
        {
          var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
          var responseDto = JsonSerializer.Deserialize<GraphQLResponseDto<PvadminDto<GetCurrentUserDto>>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
          CurrentUser currentUser = responseDto.Data.Pvadmin_.GetCurrentUser;
          Console.WriteLine("Here is the data:\n" + currentUser);
        }
        else
        {
          Console.WriteLine("Status code: " + response.StatusCode);
        }
      }
      catch (HttpRequestException httpEx)
      {
        Console.WriteLine("HTTP Exception:\n" + httpEx.Message);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Something went wrong: \n" + ex.Message);
      }
    }
  }
}