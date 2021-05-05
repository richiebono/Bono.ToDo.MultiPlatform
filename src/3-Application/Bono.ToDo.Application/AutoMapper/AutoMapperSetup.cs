using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Bono.ToDo.Application.ViewModels;
using Bono.ToDo.Domain.Entities;

namespace Bono.ToDo.Application.AutoMapper
{
    public class AutoMapperSetup: Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain

            CreateMap<UserViewModel, User>();

            #endregion

            #region DomainToViewModel

            CreateMap<User, UserViewModel>();

            #endregion
        }
    }
}
