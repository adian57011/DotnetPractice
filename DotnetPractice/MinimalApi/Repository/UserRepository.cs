using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using Utilities.Helper;
using Utilities.Response;

namespace MinimalApi.Repository
{
    public class UserRepository(ApplicationDbContext context,ILogger<UserRepository> logger)
    {
        public async Task<ApiResponse<User?>> Get(string userName)
        {
            var res = await context.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if (res is null)
                return ApiResponse<User?>.Fail(400);


            return ApiResponse<User?>.Success(res);
        }

        public async Task<ApiResponse> Register(User model)
        {
            if (model is null || string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
                return ApiResponse.Fail();

            await context.Users.AddAsync(model);
            
            try
            {
                await context.SaveChangesAsync();
                return ApiResponse.Success();
            }
            catch (Exception ex)
            {
                logger.LogError("Exception occurred || {ex}", ex);
                return ApiResponse.Fail();
            }
        }

        public async Task<ApiResponse<User?>> Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return ApiResponse<User?>.Fail();

            var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user is null)
                return ApiResponse<User?>.Fail(404,"No user found");

            bool isPasswordMatch = Hash.CompareHashValues(password, user.HashedPassword);

            if (!isPasswordMatch)
                return ApiResponse<User?>.Fail(404, "Invalid username or password");

            return ApiResponse<User?>.Success(user);
        }
    }
}
