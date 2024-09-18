using Microsoft.AspNetCore.Mvc;
using StaffMinimalApi.Data.Repository;
using StaffMinimalApi.Models;

namespace StaffMinimalApi.MapEndpoint
{
    public  static class StaffEndpoints
    {
        public static void MapStaffEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/v1/api/Staff", async ([FromServices] IStaffRepository repo) =>
            {
                return await repo.GetAll();
            })
            .WithName("GetAllStaff");

            routes.MapGet("/v1/api/Staff/{id}", async (long id, [FromServices] IStaffRepository repo) =>
            {
                return await repo.GetOne(id)
                    is StaffModel model
                        ? Results.Ok(model)
                        : Results.NotFound();
            })
            .WithName("GetStaffById");

            routes.MapPut("/v1/api/Staff/{id}", async (long id, StaffModel staffModel, [FromServices] IStaffRepository repo) =>
            {
                var staffFromDb = await repo.GetOne(id);
                if (staffFromDb == null)
                    return Results.NotFound();

                staffModel.Id = staffFromDb.Id;
                staffModel.InternalId = staffFromDb.InternalId;
                await repo.Update(staffModel);
                return Results.Ok(staffModel);
            })
            .WithName("UpdateStaff");

            routes.MapPost("/v1/api/Staff/", async (StaffModel staffModel, [FromServices] IStaffRepository repo) =>
            {
                staffModel.Id = await repo.GetNextId();
                await repo.Create(staffModel);

                return Results.Created($"/Staff/{staffModel.InternalId}", staffModel);
            })
            .WithName("CreateStaff");

            routes.MapDelete("/v1/api/Staff/{id}", async (long id, [FromServices] IStaffRepository repo) =>
            {
                var post = await repo.GetOne(id);
                if (post == null)
                    return Results.NotFound();
                await repo.Delete(id);
                return Results.Ok();
            })
            .WithName("DeleteStaff");
        }
    }
}
