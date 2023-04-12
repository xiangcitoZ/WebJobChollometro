
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebJobChollometro.Data;
using WebJobChollometro.Repositories;

string connectionString =
    @"Data Source=sqlxiang.database.windows.net;Initial Catalog=AZURETAJAMAR;Persist Security Info=True;User ID=adminsql;Password=Admin123";

var provider = 
    new ServiceCollection()
    .AddTransient<RepositoryChollos>()
    .AddDbContext<ChollometroContext>
    (options => options.UseSqlServer(connectionString))
    .BuildServiceProvider();

//RECUPERAMOS EL REPO DESDE LA INYECCION
RepositoryChollos repo = provider.GetService<RepositoryChollos>();
Console.WriteLine("Pulse ENTER para iniciar");
Console.ReadLine();
await repo.PopulateChollosAsync();
Console.WriteLine("Proceso completado. Pulse Enter para finalizar");
Console.ReadLine();