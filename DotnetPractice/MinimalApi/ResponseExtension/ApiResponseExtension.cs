using Utilities.Response;

namespace MinimalApi.ResponseExtension
{
    public static class ApiResponseExtension
    {
        public static IResult ToResult(this ApiResponse response)
        {
            switch(response.StatusCode)
            {
                case 200: return Results.Ok(response);

                case 400: return Results.BadRequest(response);

                case 500: return Results.InternalServerError(response);

                case 404: return Results.NotFound(response);

                default: return Results.BadRequest();

            };
        }

        public static IResult ToResult<T>(this ApiResponse<T?> response)
        {
            switch (response.StatusCode)
            {
                case 200: return Results.Ok(response);

                case 400: return Results.BadRequest(response);

                case 500: return Results.InternalServerError(response);

                case 404: return Results.NotFound(response);

                default: return Results.BadRequest();

            };
        }
    }
}
