﻿using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.Repositories;
using iTechArt.Shook.Repositories.DbContexts;

namespace iTechArt.Shook.Repositories.UnitsOfWorks
{
    public class SurveyUnitOfWork : UnitOfWork<SurveyApplicationDbContext>, ISurveyUnitOfWork
    {
        public IUserRepository UserRepository => (IUserRepository)GetRepository<User>();


        public SurveyUnitOfWork(ILog logger, SurveyApplicationDbContext context)
            : base(logger, context)
        {
            RegisterRepository<User, UserRepository>();
        }
    }
}