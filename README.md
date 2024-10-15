# ConsumeGraphQLQueries
## The purpose of this solution was to explore, investigate and identify the various ways to consume the GraphQL queries/endpoints.

### Introduction
The requirement was for Portfolios (PVEWeb) C# .Net framework application/code base/repository to be able to consume GraphQL queries/endpoints (exposed by PVAdmin).
<p>For this purpose an existing PVAdmin's <code>GetCurrentUser</code> GQL query/endpoint was used as it was already available in the local system.</p>
For authorization the JWT token was used, that the local system was using and manually provided in the code by extracting it from running application's requests.

### Prerequisites
Ensure existing setup of action-boards (Portfolios Overview and widgets) is up and running.
This makes the above-mentioned GQL queries with Authorization token available in the local system with the background DB and infrastructure without any need for additional setup.

It contains 3 projects
1. ResponseDto: A class library project that contains the response classes for the GraphQL queries.
2. WithLibConsumeGQL: A console application that consumes the GraphQL Queries using GraphQL.Client library/package and other related libraries/packages.
3. WithoutLibConsumeGQL: A console application that consumes the GraphQL Queries without using any libraries/packages meant specially for GraphQL.

### How to run.
1. Clone the repository.
2. Open the solution in Visual Studio.
3. Restore the Nuget Packages.
4. Provide the <b>Authorization</b> <i>Bearer Token</i> value for the respective tokenBearer string variable.
5. Build the solution.
6. Select any project to as startup project and run it or run the individual projects.
7. The console application will run and display the responses in the console.

**Note**: This is a basic investigation and implementation and <b>Authorization </b> of requests is not a part of this as it will depend on the implementation, or it would already exist.
It would involve getting authorization token for PVAdmin and using the same to authorize any requests that is beyond the scope of this.
