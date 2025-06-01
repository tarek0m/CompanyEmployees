using CompanyEmployees.Extenstions;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add controllers dependencies to DI container
builder.Services.AddControllers();

// Register DbContext for runtime
builder.Services.ConfigureSqlContext(builder.Configuration);

// Add dependency to DI container
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

// Add configurations/options to DI container
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();


var app = builder.Build();
// There will be no addition/modification allowed 
// and DI container is sealed

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
