using CA_ApplicationLayer.Contracts;
using CA_ApplicationLayer.UseCases;
using CA_EnterpriseLayer.Entities;
using CA_EnterpriseLayer.Entities.Rest;
using CA_FrameworksDrivers.Api.Middleware;
using CA_FrameworksDrivers.ExternalServices;
using CA_InterfaceAdapters.Adapters;
using CA_InterfaceAdapters.Adapters.Dto;
using CA_InterfaceAdapters.Data;
using CA_InterfaceAdapters.Mappers.Dto.Requests;
using CA_InterfaceAdapters.Mappers.Mapper;
using CA_InterfaceAdapters.Models;
using CA_InterfaceAdapters.Presenters;
using CA_InterfaceAdapters.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IRepository<Product>, Repository>();
builder.Services.AddScoped<IPresenter<Product, ProductViewModel>, ProductPresenter>();
builder.Services.AddScoped<GetProductService<Product, ProductViewModel>>();
builder.Services.AddScoped<AddProductService<ProductRequestDto>>();
builder.Services.AddScoped<IMapper<ProductRequestDto, Product>, ProductMapper>();
builder.Services.AddScoped<GetPostUseCase>();
builder.Services.AddScoped<IExternalService<PostDto>, PostService>();
builder.Services.AddScoped<IExternalServiceAdapter<Post>, PostExternalServiceAdapter>();

builder.Services.AddHttpClient<IExternalService<PostDto>, PostService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPostData"]);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.MapGet("/product", async(GetProductService<Product, ProductViewModel> getProductService) =>
{
    return await getProductService.ExecuteAsync();
})
.WithName("products")
.WithOpenApi();


app.MapPost("/product", async (ProductRequestDto requestDto,
                               AddProductService<ProductRequestDto> addProductService) 
                               =>
{
     await addProductService.ExecuteAsync(requestDto);
})
.WithName("addProduct")
.WithOpenApi();

app.MapPost("/getItem", async (GetPostUseCase service)
                               =>
{
    return await service.ExecuteAsync();
})
.WithName("getItems")
.WithOpenApi();

app.Run();
