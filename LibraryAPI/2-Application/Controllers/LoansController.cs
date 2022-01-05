using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Context;
using LibraryAPI._3_Domain.Entities;
using LibraryAPI._3_Domain.Models.Loan;
using LibraryAPI._3_Domain.Interfaces;

namespace LibraryAPI._2_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost]
        [Route("ReturnBook")]
        public async Task<ActionResult> ReturnBook(LoanRequest loan)
        {
            await _loanService.ReturnBook(loan);
            return Ok();
        }

        [HttpPost]
        [Route("RealizeLoan")]
        public async Task<ActionResult<Loan>> RealizeLoan(LoanRequest loan)
        {
            try
            {
                return Ok(await _loanService.RealizeLoan(loan));
            }
            catch (Exception)
            {
                throw;

            }
        }

    }
}
