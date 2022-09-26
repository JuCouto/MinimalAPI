using Microsoft.EntityFrameworkCore;
using MinimalAPI.Contexto;
using MinimalAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ConexaoPadrao")));


builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer(); //permite abrir no navegador

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("ListarProdutos", async ( Contexto contexto) =>
{
        await contexto.Produto.ToListAsync();
    
});

app.MapGet("ObterProduto/{id}", async (int id, Contexto contexto) =>
{
    await contexto.Produto.FirstOrDefaultAsync(x => x.Id == id);

});

app.MapPost("AdicionaProduto", async (Produto produto, Contexto contexto)=>
{
    contexto.Produto.Add(produto);
    await contexto.SaveChangesAsync();
}
    );

app.MapDelete("DeletarProduto/{id}", async (int id, Contexto contexto) =>
{
    var produtoExcluir = await contexto.Produto.FirstOrDefaultAsync(x => x.Id == id);
    if (produtoExcluir != null)
    { 
    contexto.Produto.Add(produtoExcluir);
    await contexto.SaveChangesAsync();
    }
});

app.Run();
