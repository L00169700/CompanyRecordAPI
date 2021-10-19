using CompanyRecordAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using RecordsModel.Model;
using RecordsModel.Repository;
using System.Linq;
using Xunit;

namespace CompanyRedordUnitTest
{
    public class CompanyRecordControllerUnitTest
    {

        [Fact]
        public static void TestGetCompanies()
        {
            // Arrange
            var dbContext = DbContextMock.GetApplicationDBContext(nameof(TestGetCompanies));
            RepositoryWrap repositoryWrap = new RepositoryWrap(dbContext);
            var controller = new CompanyRecordController(repositoryWrap);

            // Act
            var response = controller.GetCompanies() as ObjectResult;
            var value = response.Value as IQueryable<CompanyRecord>;

            dbContext.Dispose();

            // Assert
            Assert.NotEmpty(value);
        }


        [Fact]
        public static void TestGetById()
        {
            // Arrange
            var dbContext = DbContextMock.GetApplicationDBContext(nameof(TestGetById));
            RepositoryWrap repositoryWrap = new RepositoryWrap(dbContext);
            var controller = new CompanyRecordController(repositoryWrap);
            var companyID = 1;
            // Act
            var response = controller.GetById(companyID) as ObjectResult;
            var value = response.Value as CompanyRecord;

            dbContext.Dispose();

            // Assert
            Assert.NotNull(value);
        }

        [Fact]
        public static void TestGetByISIN()
        {
            // Arrange
            var dbContext = DbContextMock.GetApplicationDBContext(nameof(TestGetByISIN));
            RepositoryWrap repositoryWrap = new RepositoryWrap(dbContext);
            var controller = new CompanyRecordController(repositoryWrap);
            var companyISIN = "US3866800000";
            // Act
            var response = controller.GetByISIN(companyISIN) as ObjectResult;
            var value = response.Value as CompanyRecord;

            dbContext.Dispose();

            // Assert
            Assert.NotNull(value);
        }


        [Fact]
        public static void TestCreate()
        {
            // Arrange
            var dbContext = DbContextMock.GetApplicationDBContext(nameof(TestCreate));
            RepositoryWrap repositoryWrap = new RepositoryWrap(dbContext);
            var controller = new CompanyRecordController(repositoryWrap);
            CompanyRecord testCompany = new CompanyRecord
            {
                Name = "Test Create",
                Exchange = "Exchange 1",
                Ticker = "6752",
                ISIN = "BB3866800000",
                Website = "Test.com"
            };
            
            // Act
            var response = controller.GetByISIN(testCompany.ISIN) as ObjectResult;
           
            dbContext.Dispose();

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public static void TestUpdate()
        {
            // Arrange
            var dbContext = DbContextMock.GetApplicationDBContext(nameof(TestUpdate));
            RepositoryWrap repositoryWrap = new RepositoryWrap(dbContext);
            var controller = new CompanyRecordController(repositoryWrap);
            CompanyRecord actualCompany = new CompanyRecord
            {
                Name = "Test Update",
                Id = 1,
                Exchange = "Exchange 1",
                Ticker = "6752",
                ISIN = "LL3866800000",
                Website = "Test.com"
            };
            // Act
            var response = controller.Create(actualCompany) as ObjectResult;
            var actual = response.Value as CompanyRecord;

            var exp = controller.GetByISIN("LL3866800000") as ObjectResult;
            var expected = exp.Value as CompanyRecord;

            dbContext.Dispose();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
