using CryptoExchange.Domain.Dto;
using CryptoExchange.Domain.Models;
using CryptoExchange.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        // GET: api/<TransactionsController>
        [HttpGet]
        public async Task<IEnumerable<TransactionGetDto>> Get()
        {
            return await _transactionService.GetAllTransactions();
        }

        // GET api/<TransactionsController>/5
        [HttpGet("{id}")]
        public async Task<Transaction> Get(int id)
        {
            return await _transactionService.GetTransactionById(id);
        }

        // POST api/<TransactionsController>
        [HttpPost]
        public void Post([FromBody] TransactionPostDto value)
        {
        }

        // PUT api/<TransactionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransactionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
