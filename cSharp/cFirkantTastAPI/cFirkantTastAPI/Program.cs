using cFirkantTastAPI.Contracts;
using cFirkantTastAPI.Controllers.Circles.v0___Puke;
using cFirkantTastAPI.Controllers.Friends.v0___Puke;
using cFirkantTastAPI.Controllers.Posts.v0___Puke;
using cFirkantTastAPI.Controllers.User.v0___Puke;

// Testing XDDDDD

// Testing XDDDDD

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins",
            builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
    });
}

// Add services to the container.
builder.Services.AddSingleton<IPostsAPI, Posts>();
builder.Services.AddSingleton<IUserAPI, UserAPI>();
builder.Services.AddSingleton<ICirclesAPI, CirclesAPI>();
builder.Services.AddSingleton<IFriendsAPI, FriendsAPI>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAllOrigins");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
