# CompanyRecordAPI 

WebAPI solution in C# for a middle tier “Company API.”  

 

Using this WebAPI, an end user should be able to:

 

Create a Company record specifying the Name, Stock Ticker, Exchange, ISIN, and optionally a website URL. You are not allowed to create two Companies with the same ISIN. The first two characters of an ISIN must be letters / non numeric.
Retrieve an existing Company by Id
Retrieve a Company by ISIN
Retrieve a collection of all Companies
Update an existing Company

in order to get the Dababase for this project the Developer should use the Migrations or access the script on CompanyRecordAPI Resorce folder.

For validation of JWT token the caller need to login first using the default login and password as below:
Login:admin
Pass:admin


This solution will contains the following projects:

CompanyRecordAPI
CompanyRecordIntegrationTest
CompanyRecordUnitTest
RecordModel

Many Thanks

Rodrigo



