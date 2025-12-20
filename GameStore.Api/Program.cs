using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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
app.MapGet("games/{id}", (int id) => games.FirstOrDefault(game => game.Id == id));



app.Run();
