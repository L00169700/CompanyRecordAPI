﻿using Microsoft.EntityFrameworkCore;
using RecordsModel;

namespace CompanyRedordUnitTest
{
    public static class DbContextMock
    {
        public static ApplicationDBContext GetApplicationDBContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new ApplicationDBContext(options);

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}
