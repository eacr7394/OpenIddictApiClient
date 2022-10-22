using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
#region Swagger
builder.Services.AddEndpointsApiExplorer()
.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Plain Digital Signature Api",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert grant_type With Bearer into field",
        Name = "grant_type",
        Type = SecuritySchemeType.ApiKey
    });
    var oass = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    var oasr = new OpenApiSecurityRequirement { { oass, new string[] { } } };
    c.AddSecurityRequirement(oasr);
});
#endregion
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options => {
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOpenIdConnect(o =>
{
    o.ClientId = "console";
    o.ClientSecret = "AQAAAAEAACcQAAAAEAXTHW8CCuaIKIxFW2h/oJjikXChmMYn978vM7EZ7uCcjkUXtnHkmjTQZVMExZ3fYg==";
    o.Authority = "https://localhost:7029/oidc";
    o.ResponseType = "code";
    o.GetClaimsFromUserInfoEndpoint = true;
}
);

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

app.UseAuthentication();

// This is needed if running behind a reverse proxy
// like ngrok which is great for testing while developing
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    RequireHeaderSymmetry = false,
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.Run();
