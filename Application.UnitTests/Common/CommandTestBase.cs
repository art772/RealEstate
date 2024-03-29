﻿using Moq;
using RealEstate.Persistance;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly EstateDbContext _context;
        protected readonly Mock<EstateDbContext> _contextMock;

        public CommandTestBase()
        {
            _contextMock = EstateDbContextFactory.Create();
            _context = _contextMock.Object;
        }

        public void Dispose()
        {
            EstateDbContextFactory.Destroy(_context);
        }
    }
}