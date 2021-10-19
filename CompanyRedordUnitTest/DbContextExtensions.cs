using RecordsModel;

namespace CompanyRedordUnitTest
{
    public static class DbContextExtensions
    {
        public static void Seed(this ApplicationDBContext dbContext)
        {
            //Add entities for DbContext instance
            dbContext.CompanyRecords.Add(new RecordsModel.Model.CompanyRecord
            {
                Name = "Test 1",
                Exchange = "Exchange 1",
                Ticker = "6752",
                ISIN = "JP3866800000",
                Website = "Test.com"


            });


            dbContext.CompanyRecords.Add(new RecordsModel.Model.CompanyRecord
            {
                Name = "Test 2",
                Exchange = "Exchange 2",
                Ticker = "3456",
                ISIN = "US3866800000",
                Website = "Test.com"


            });


            dbContext.CompanyRecords.Add(new RecordsModel.Model.CompanyRecord
            {
                Name = "Test 3",
                Exchange = "Exchange 3",
                Ticker = "9667",
                ISIN = "NL3866800000",
                Website = "Test.com"


            });

            dbContext.CompanyRecords.Add(new RecordsModel.Model.CompanyRecord
            {
                Name = "Test 4",
                Exchange = "Exchange 4",
                Ticker = "7647",
                ISIN = "NL3866800000",
                Website = "Test.com"


            });


            dbContext.SaveChanges();
        }
    }
}
