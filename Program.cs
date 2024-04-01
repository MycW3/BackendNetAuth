using Microsoft.EntityFrameworkCore;
using backendnet.Data;

var builder = WebApplication.CreateBuilder(args);

//Agrega el soporte para MySQL
var connectionString = builder.Configuration.GetConnectionString("DataContext");
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

//Agrega el soporte para CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3001", "http://localhost:8080")
            .AllowAnyHeader()
            .WithMethods("GET", "POST", "PUT", "DELETE");
        }
    );
});

//agrega la funcionalidad de controladores
builder.Services.AddControllers();

//agrega la documentación de la API
builder.Services.AddSwaggerGen();

//contruye la app web
var app = builder.Build();

//si queremos mostrar la documentación de la API en laraiz
if(app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Redirige a HTTPS
app.UseHttpsRedirection();

//utiliza rutas para los endpoints de los controladores
app.UseRouting();

//Usa CORS con la policy definida anteriormente
app.UseCors();
//establece el uso de tutas sin especificar una por defult
app.MapControllers();

app.Run();
