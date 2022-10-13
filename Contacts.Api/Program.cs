using Microsoft.EntityFrameworkCore;
using Saphyre.Contact.Context;
using Saphyre.Contact.Providers;
using Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.AddDbContext<ContactContext>(options =>

/////I used Sql server on azure for testing
////options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSql"),
////sqlServerOptionsAction: sqlOptions =>
////{
////    sqlOptions.EnableRetryOnFailure(
////    maxRetryCount: 10,
////    maxRetryDelay: TimeSpan.FromSeconds(3),
////    errorNumbersToAdd: null);
////}));

var options = new DbContextOptionsBuilder<ContactContext>()
                .UseInMemoryDatabase("ContactDB").Options;

builder.Services.AddSingleton<ContactContext>(c =>
 {
     var context =  new ContactContext(options: options);
     context.init();
     return context;
 });


//builder.Services.AddDbContext<ContactContext>(options =>
//options.UseInMemoryDatabase("ContactDB")
//);


builder.Services.AddCors(options =>
{
    options.AddPolicy("CustomPolicy", builder =>
     builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
});

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ContactValidator>();
builder.Services.AddScoped<ContactProvider>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
    app.UseSwagger();
    app.UseSwaggerUI();
app.UseCors("CustomPolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();
