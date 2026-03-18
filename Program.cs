var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Swagger for dev
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Add a simple root endpoint so browsing / shows something
app.MapGet("/", () => "Hello from ASP.NET Core on port 1000!");

// Bind the app to port 1000
app.Urls.Add("http://*:1000");

// Run the app
app.Run();