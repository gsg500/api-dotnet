using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/teste", () => new {Name = "teste"});
// incluindo informações no cabeçalho
app.MapPost("/segundo", (HttpResponse response) => {
    response.Headers.Add("Teste", "Guilherme Santos Gomes");
    response.Headers.Add("Segundo", "Terceiro");
    return new {Name = "Guilherme Santos Gomes"};
    });

app.MapPost("/users", (Usuarios users) => {
    return new {Codigo = users.Cod, Nome = users.name};    
});

//Query Params - http://localhost:3000/getusers?dataStart={valor}&dateEnd={valor}
app.MapGet("/getusers", ([FromQuery] string dataStart, [FromQuery] string dateEnd) => {
    return new {DataInicio = dataStart, DataFim = dateEnd};    
});

//string code - http://localhost:3000/getusers/{code}
app.MapGet("/getusers/{code}", ([FromRoute] string code) => {
    return new {valor = code};    
});

app.Run();

public class Usuarios {
    public int Cod {get; set;}
    public string name {get; set;}
}