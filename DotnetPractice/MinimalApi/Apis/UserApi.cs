using MinimalApi.Data;
using MinimalApi.Repository;
using MinimalApi.ResponseExtension;

namespace MinimalApi.Apis
{
    public static class UserApi
    {
        public static RouteGroupBuilder MapUserApi(this RouteGroupBuilder app)
        {
            app.MapGet("user", async (string username,UserRepository userRepository) =>
            {
                var res = await userRepository.Get(username);
                return res.ToResult();
            });

            app.MapPost("user", async (User model, UserRepository userRepository) =>
            {
                var res = await userRepository.Register(model);
                return res.ToResult();
            });

            app.MapPost("login", async (User model,UserRepository userRepository) =>
            {
                var res = await userRepository.Login(model.UserName, model.Password);
                return res.ToResult();
            });

            return app;
        }
    }
}
