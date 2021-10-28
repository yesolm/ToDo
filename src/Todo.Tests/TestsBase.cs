using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Abstractions;
using ToDo.Infrastructure;
using ToDo.Infrastructure.Data;

namespace Todo.Tests
{
    public abstract class TestsBase
    {
        private IUnitOfWork _unitOfWork;
        private ApplicationDbContext _dbContext;

        [TestInitialize]
        public void BaseSetup()
        {

            _dbContext = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase("ToDo").Options);

            _unitOfWork = new UnitOfWork(_dbContext);
        }

        [TestCleanup]
        public void BaseCleanUp()
        {
            _dbContext?.Dispose();
            _dbContext = null;

            _unitOfWork?.Dispose();
            _unitOfWork = null;
        }
        protected IUnitOfWork UnitOfWork => _unitOfWork;
    }
}
