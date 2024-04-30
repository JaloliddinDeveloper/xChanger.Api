using xChanger.Core.POC.Brokers.Sheets;
using xChanger.Core.POC.Brokers.Storages;
using xChanger.Core.POC.Services.Coordinations;
using xChanger.Core.POC.Services.Foundations.ExternalPersons;
using xChanger.Core.POC.Services.Foundations.Persons;
using xChanger.Core.POC.Services.Foundations.Pets;
using xChanger.Core.POC.Services.Orchestrations.ExternalPersons;
using xChanger.Core.POC.Services.Orchestrations.PersonPets;
using xChanger.Core.POC.Services.Processings.ExternalPersons;
using xChanger.Core.POC.Services.Processings.Persons;
using xChanger.Core.POC.Services.Processings.Pets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<ISheetBroker,SheetBroker>();
builder.Services.AddTransient<IStorageBroker,StorageBroker>();
builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IPetService, PetService>();
builder.Services.AddTransient<IExternalPersonService, ExternalPersonService>();
builder.Services.AddTransient<IPersonProcessingService, PersonProcessingService>();
builder.Services.AddTransient<IPetProcessingService, PetProcessingService>();
builder.Services.AddTransient<IExternalPersonProcessingService, ExternalPersonProcessingService>();
builder.Services.AddTransient<IPersonPetOrchestrationService, PersonPetOrchestrationService>();
builder.Services.AddTransient<IExternalPersonOrchestrationService, ExternalPersonOrchestrationService>();
builder.Services.AddTransient<IExternalPersonWithPetsCoordinationService, ExternalPersonWithPetsCoordinationService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
