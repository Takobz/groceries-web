namespace Groceries.Core.Application.ApiReoutes
{
    public static class BasketRoutes
    {
        public static WebApplication MapBasketRoutes(this WebApplication app)
        {
            app.MapGet("/api/basket", async (IConfiguration configuration) => $"{nameof(configuration)}")
                .WithName("GetBasket")
                .WithOpenApi();
            return app;
        }
    }
}
