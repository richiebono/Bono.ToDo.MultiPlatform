using Microsoft.Extensions.DependencyInjection;
using System;
using Bono.ToDo.Application.Interfaces;
using Bono.ToDo.Application.Services;
using Bono.ToDo.Data.Repositories;
using Bono.ToDo.Domain.Interfaces.Repository;
using Bono.ToDo.Domain.Validations;
using Bono.ToDo.Infrastructure.Utils;

namespace Bono.ToDo.Infrastructure.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<ITaskToDoService, TaskToDoService>();
            services.AddScoped<ITaskToDoInviteService, TaskToDoInviteService>();
            services.AddScoped<ITaskToDoUserService, TaskToDoUserService>();

            #endregion

            #region Domain

            services.AddScoped<ValidationResult, ValidationResult>();

            #endregion 

            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<ITaskToDoRepository, TaskToDoRepository>();
            services.AddScoped<ITaskToDoInviteRepository, TaskToDoInviteRepository>();
            services.AddScoped<ITaskToDoUserRepository, TaskToDoUserRepository>();

            #endregion

            #region Utils
                        
            services.AddScoped<Settings, Settings>();
            services.AddScoped<Security, Security>();
            

            #endregion 
        }
    }
}
