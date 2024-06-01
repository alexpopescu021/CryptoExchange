using CryptoExchange.Domain.Dto;
using CryptoExchange.Domain.Models;
using CryptoExchange.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoExchange.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IPortofolioService _portofolioService;

        public TransactionsController(ITransactionService transactionService, IPortofolioService portofolioService)
        {
            _transactionService = transactionService;
            _portofolioService = portofolioService;
        }
        // GET: api/<TransactionsController>
        [HttpGet]
        public async Task<IEnumerable<TransactionGetDto>> Get()
        {
            return await _transactionService.GetAllTransactions();
        }

        // GET api/<TransactionsController>/5
        [HttpGet("id/{id}")]
        public async Task<Transaction> Get(int id)
        {
            return await _transactionService.GetTransactionById(id);
        }

        // GET api/<TransactionsController>/5
        [HttpGet("currency/{currency}")]
        public decimal? Get(string currency)
        {
            return _portofolioService.GetPortofolioVAlueForCurrentCurrency(currency);
        }

        // POST api/<TransactionsController>
        [HttpPost]
        public void Post([FromBody] TransactionPostDto value)
        {
        }

        // POST api/<TransactionsController>/convert
        [HttpPost("convert")]
        public async Task<double> Convert([FromBody] TransactionPostDto value, [FromHeader] double amount)
        {
            return await _transactionService.Convert(value.SourceCurrencyCode, value.TargetCurrencyCode, amount);
        }

        // DELETE api/<TransactionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
