using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecordsModel.Model;
using RecordsModel.Repository.Interface;
using System;

namespace CompanyRecordAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CompanyRecordController : ControllerBase
    {
        private IRepositoryWrap _repositoryWrap;
        public CompanyRecordController(IRepositoryWrap repositoryWrap)
        {
            _repositoryWrap = repositoryWrap;
        }

        #region Logger

        ILog logger = log4net.LogManager.GetLogger(typeof(CompanyRecordController));

        #endregion

        /// <summary>
        /// Return a list of Companies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetCompanies()
        {
            try
            {
                var companies = _repositoryWrap.CompanyRecord.FindAll();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                logger.Error($"Something went wrong inside getCompanies action: {ex.Message}");
                return BadRequest("Internal server error");
            }
        }

        /// <summary>
        /// Return a Companies filter by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>       
        [HttpGet]
        [Authorize("Bearer")]
        [Route("id/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetById(int id)
        {
            try
            {
                var company = _repositoryWrap.CompanyRecord.FindByID(id);
                if (company == null)
                {
                    return BadRequest("Invalid Company ID");
                }
                return Ok(company);
            }
            catch (Exception ex)
            {
                logger.Error($"Something went wrong inside GetCompanyById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }


        /// <summary>
        /// Return a Companies filter by ISIN
        /// </summary>
        /// <param name="isin"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        [Route("isin/{isin}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetByISIN(string isin)
        {
            try
            {
                var company = _repositoryWrap.CompanyRecord.FindByISIN(isin);
                if (company == null)
                {
                    return BadRequest("Invalid Company ISNI");
                }
                return Ok(company);
            }
            catch (Exception ex)
            {
                logger.Error($"Something went wrong inside GetCompanyByISIN action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }


        /// <summary>
        /// Create or Update a Company
        /// if an ID is provided the order is updated
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] CompanyRecord company)
        {
            try
            {
                if (company == null)
                {
                    logger.Error("company object sent from client is null.");
                    return BadRequest("Invalid Company");
                }

                if (!ModelState.IsValid)
                {
                    logger.Error("Invalid company object sent from client.");
                    return BadRequest("Invalid Company");
                }
                var listErrors = _repositoryWrap.CompanyRecord.ValidateCompanyISIN(company);
                if (listErrors.Count == 0)
                {
                    _repositoryWrap.CompanyRecord.Create(company);
                    _repositoryWrap.Save();
                    return Ok(new { id = company.Id });
                }
                else
                {
                    logger.Error("Invalid company validation " + string.Join(",", listErrors.ToArray()));
                    return BadRequest("Invalid company validation " + string.Join(", ", listErrors.ToArray()));
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Something went wrong inside CreateCompany action: {ex.Message}");
                return BadRequest("Internal server error");
            }
        }

        /// <summary>
        /// Create or Update a Company
        /// if an ID is provided the order is updated
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize("Bearer")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Update([FromBody] CompanyRecord company)
        {
            try
            {
                if (company == null)
                {
                    logger.Error("company object sent from client is null.");
                    return BadRequest("Invalid Company");
                }

                if (!ModelState.IsValid)
                {
                    logger.Error("Invalid company object sent from client.");
                    return BadRequest("Invalid Company");
                }

                CompanyRecord companyToUpate = _repositoryWrap.CompanyRecord.FindByID(company.Id);
                if (companyToUpate != null)
                {
                    if (company.ISIN != companyToUpate.ISIN)
                    {
                        var listErrors = _repositoryWrap.CompanyRecord.ValidateCompanyISIN(company);
                        if (listErrors.Count == 0)
                        {
                            _repositoryWrap.CompanyRecord.Create(company);
                            _repositoryWrap.Save();
                            return Ok(new { id = company.Id });
                        }
                        else
                        {
                            logger.Error("Invalid company validation " + string.Join(",", listErrors.ToArray()));
                            return BadRequest("Invalid company validation " + string.Join(", ", listErrors.ToArray()));
                        }

                    }
                    _repositoryWrap.CompanyRecord.Create(company);
                    _repositoryWrap.Save();
                    return Ok(new { id = company.Id });
                }
                else
                {
                    string error = "Invalid company id, Company Record could not be found....";
                    logger.Error(error);
                    return BadRequest(error);
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Something went wrong inside CreateCompany action: {ex.Message}");
                return BadRequest("Internal server error");
            }
        }
    }
}
