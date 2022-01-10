using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAngularPractico.Controllers
{
    public class CryptoController : ControllerBase
    {
        private readonly ILogger<CryptoController> _logger;

        static readonly Models.CryptoRepository repository = new Models.CryptoRepository();

        public CryptoController(ILogger<CryptoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/cryptomonedas/{key}")]
        public string GetAllCryptomonedas(string key)
        {
            return repository.GetAllCryptomonedas(key);
        }
    }
}
