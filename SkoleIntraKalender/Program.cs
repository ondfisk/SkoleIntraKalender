var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc(o =>
{
    o.OutputFormatters.Insert(0, new CalendarOutputFormatter(new CalendarConverter()));
});

builder.Services.Configure<MvcOptions>(o =>
{
    o.Filters.Add(new RequireHttpsAttribute());
});

builder.Services.AddOptions();
builder.Services.Configure<CalendarOptions>(builder.Configuration.GetSection("CalendarService"));

builder.Services.AddScoped<DelegatingHandler, AuthorizedHandler>();
builder.Services.AddScoped<ICalendarService, CalendarService>();
builder.Services.AddScoped<ICalendarConverter, CalendarConverter>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();