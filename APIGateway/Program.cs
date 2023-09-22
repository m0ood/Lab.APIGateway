var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient("UserMicroservice", client =>
{
    client.BaseAddress = new Uri("https://localhost:7092/");
});

builder.Services.AddHttpClient("ProductMicroservice", client =>
{
    client.BaseAddress = new Uri("https://localhost:7177/");
});

builder.Services.AddHttpClient("OrderMicroservice", client =>
{
    client.BaseAddress = new Uri("https://localhost:7274/");
});
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
// Добавьте маршруты для микросервисов
app.Map("/user/{*path}", HandleUserRequest);
app.Map("/product/{*path}", HandleProductRequest);
app.Map("/order/{*path}", HandleOrderRequest);

app.Run();
// Обработчики запросов к микросервисам
async Task HandleUserRequest(HttpContext context)
{
    var httpClient = context.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient("UserMicroservice");
    var response = await httpClient.GetAsync(context.Request.Path);

    if (response.IsSuccessStatusCode)
    {
        await context.Response.WriteAsync(await response.Content.ReadAsStringAsync());
    }
    else
    {
        context.Response.StatusCode = (int)response.StatusCode;
        await context.Response.WriteAsync("Error contacting User service.");
    }
}

async Task HandleProductRequest(HttpContext context)
{
    var httpClient = context.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient("ProductMicroservice");
    var response = await httpClient.GetAsync(context.Request.Path);

    if (response.IsSuccessStatusCode)
    {
        await context.Response.WriteAsync(await response.Content.ReadAsStringAsync());
    }
    else
    {
        context.Response.StatusCode = (int)response.StatusCode;
        await context.Response.WriteAsync("Error contacting User service.");
    }
}

async Task HandleOrderRequest(HttpContext context)
{
    var httpClient = context.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient("OrderMicroservice");
    var response = await httpClient.GetAsync(context.Request.Path);

    if (response.IsSuccessStatusCode)
    {
        await context.Response.WriteAsync(await response.Content.ReadAsStringAsync());
    }
    else
    {
        context.Response.StatusCode = (int)response.StatusCode;
        await context.Response.WriteAsync("Error contacting User service.");
    }
}

