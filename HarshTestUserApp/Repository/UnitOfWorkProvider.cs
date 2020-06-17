using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HarshTestUserApp.Models;

namespace HarshTestUserApp.Repository
{
    public sealed class UnitOfWorkProvider
    {
        private DataFoundryDBEntities _dbEntities;
        private GenericRepository<tblUser> _userRepository;


        public UnitOfWorkProvider()
        {
            _dbEntities = new DataFoundryDBEntities();
        }


        public GenericRepository<tblUser> UserRepository
        {
            get
            {

                if (this._userRepository == null)
                {
                    this._userRepository = new GenericRepository<tblUser>(_dbEntities);
                }
                return _userRepository;
            }
        }
    }
}