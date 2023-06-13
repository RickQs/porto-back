using Microsoft.EntityFrameworkCore;
using porto_back;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PortoDb>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

var conteiner = app.MapGroup("/conteiner");

conteiner.MapPost("/", CreateConteiner);
conteiner.MapGet("/{id}", GetConteinerById);
conteiner.MapPut("/{id}", InsertMovimentacoes);

app.Run();

static async Task<IResult> CreateConteiner(Conteiner conteiner, PortoDb db)
{
    db.Conteineres.Add(conteiner);
    await db.SaveChangesAsync();

    return TypedResults.Created($"/conteiner/{conteiner.NumConteiner}", conteiner);
}

static async Task<IResult> GetConteinerById(string id, PortoDb db)
{
    var conteiner = await db.Conteineres.FindAsync(id);
    if (conteiner is not null)
    {
        return TypedResults.Ok(new ConteinerDto
        {
            NumConteiner = conteiner.NumConteiner,
            Cliente = conteiner.Cliente,
            TipoConteiner = conteiner.TipoConteiner,
            Status = conteiner.Status.ToString(),
            Categoria = conteiner.Categoria.ToString(),
        });
    }

    return TypedResults.NotFound();
}

static async Task<IResult> InsertMovimentacoes(Movimentacao inputMovimentacao, string id, PortoDb db)
{
    var conteiner = await db.Conteineres.FindAsync(id);

    if (conteiner is null) return TypedResults.NotFound();

    inputMovimentacao.NumConteiner = id;
    conteiner.Movimentacoes?.Add(inputMovimentacao);
    db.Conteineres.Update(conteiner);
    db.Movimentacoes.Add(inputMovimentacao);
    await db.SaveChangesAsync();

    return TypedResults.NoContent();
}