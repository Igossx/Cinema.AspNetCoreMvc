using CarWorkshop.Application.ApplicationUser;
using Cinema.Application.Interfaces;
using Cinema.Application.Movie.Commands.CreateMovie;
using Cinema.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateMovieCommand));

            services.AddValidatorsFromAssemblyContaining<CreateMovieCommandValidator>()
                   .AddFluentValidationAutoValidation()
                   .AddFluentValidationClientsideAdapters();

            services.AddScoped<ICinemaHallService, CinemaHallService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserContext, UserContext>();
        }
    }
}
