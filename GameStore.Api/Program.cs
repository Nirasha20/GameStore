using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDto> games = [
    new (
        1,
        "Street Fighter V",
        "Fighting",
        19.99M,
        new DateOnly(2016, 2, 16)
    ),
    new (
        2,
        "Final Fantasy VII Remake",
        "Roleplaying",
        59.99M,
        new DateOnly(2020, 4, 10)
    ),
    new(
        3,
        "FIFA 22",
        "Sports",
        69.99M,
        new DateOnly(2021, 10, 19)
    )
];
//GET /games
app.MapGet("/games", () => games);

//GET/games/1
app.MapGet("games/{id}", (int id) => games.FirstOrDefault(game => game.Id == id))
.WithName(GetGameEndpointName);

//POST
app.MapPost("/games", (CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);
    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
    
});

//PUT /games
app.MapPut("/games/{id}", (int id, UpdateGameDto updatedGame) =>
{

    var index = games.FindIndex(game => game.Id == id);
    
    games[index] = new GameDto(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );
    return Results.NoContent();
});


app.Run();
