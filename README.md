# Introduction
This is a repository of the SquadGame solution.
- `.github/workflows` contains CI/CD pipeline definitions
- `frontend/squadgame-web-ui` - main web app portal (React 18)
- `src` - contains whole backend (.NET 8)
- `scripts` - contains useful powershell scripts and commands to improve development experience

# Dev tools
- [Visual Studio Code](https://code.visualstudio.com/download) with extensions: 
  - [YAML](https://marketplace.visualstudio.com/items?itemName=redhat.vscode-yaml)
- [Rider](https://www.jetbrains.com/rider/download/#section=windows)
- [GitHub Desktop](https://desktop.github.com/)
- [Postman](https://www.postman.com/downloads/)

# Running the solution

## Prerequisites 

- [Node v16](https://nodejs.org/en/download/)
- `npm i`
- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

## Run API project
Run API project by executing from the repo root directory:
`dotnet run --project ./src/SquadGame.Core.Service/SquadGame.Core.Service.csproj`

Backend will be availale at http://localhost:5161 and swagger definition at http://localhost:5161/swagger

## Run frontend

Navigate to the `frontend\squadgame-web-ui\squadgame-web-ui` folder and run:
`npm i` - this will install dependencies. Then run `npm start` to start serving the project in development mode.

Frontend will be available at http://localhost:3000/

# Continuous Integration

Continuous integration runs on GitHub Actions and each of the solutions (frontend, API, etc) has a configured:

Basic CI steps of each pipeline:

- Fetch source codes
- Setup build dependencies (.NET, NPM, etc)
- Restore project dependencies (dotnet restore, npm install, etc)
- Build
- Run Tests (if applicable) (in progress)
- Publish Artifacts 

# Continuous Delivery
< TO DO >

### API Controller

```csharp
[ApiVersion("1.0")]
[ApiController]
[Route("api/teams")]
[Route("api/v{version:apiVersion}/teams")]
public partial class TeamsController : ControllerBase
{
  [HttpGet]
  [ProducesResponseType(typeof(SuccessResult<GetTeamResponse>), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> GetTeams([FromQuery] GetTeamRequest query)
  {
      if (query == null) throw new InvalidParameterException(nameof(query));

      var response = await _teamService.GetAllTeamsPerLeague(query.League, query.SeasonYear);

      return new SuccessResult(response);
  }
}