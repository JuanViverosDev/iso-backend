using Dissau.DigisignCol.Infrastructure.Persistence;
using Iso.Backend.Application.Common.Interfaces;
using Iso.Backend.Application.Services.Orders.Implementation;
using Iso.Backend.Application.Services.Orders.Interfaces;
using Iso.Backend.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000", "http://localhost:5173");
            policy.AllowCredentials();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("SQLConnection");
builder.Services.AddDbContext<IsoBackendDbContext>(options =>
    options.UseNpgsql(connectionString));
NpgsqlConnection.GlobalTypeMapper.EnableDynamicJson();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

#region Application Services

builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

builder.Services.AddScoped<IItemsService, ItemsService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.AddScoped<IDesignsService, DesignsService>();
builder.Services.AddScoped<IDesignRepository, DesignRepository>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }


app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
