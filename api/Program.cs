using api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add the CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()  // Allow any origin (you can restrict this to specific domains for production)
                   .AllowAnyMethod()  // Allow any HTTP method (GET, POST, PUT, DELETE, etc.)
                   .AllowAnyHeader(); // Allow any headers
        });
});

builder.Services.AddScoped<SmhiService>();
builder.Services.AddHttpClient<SmhiService>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use the CORS policy
app.UseCors("AllowAll");  // Apply the CORS policy to all endpoints

app.MapControllers();

app.Run();
