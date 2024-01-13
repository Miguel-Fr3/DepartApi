using DepartAPI.Data;
using DepartAPI.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddDbContext<DepartContext>(options =>
    options.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DepartamentoApi;Data Source=BINGAZ"));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DepartContext>();

    var departamento = new Departamento
    {
        Nome = "Departamento A",
        Sigla = "DA"
    };

    departamento.Funcionarios.Add(new Funcionario
    {
        Nome = "Funcionário 1",
        Foto = "foto1.jpg",
        RG = "123456",
    });

    departamento.Funcionarios.Add(new Funcionario
    {
        Nome = "Funcionário 2",
        Foto = "foto2.jpg",
        RG = "789012",
    });

    context.Departamentos.Add(departamento);
    context.SaveChanges();
}

app.Run();
