using System.Collections.Generic;
using System.Linq;
using Hospital.DNA.API.Business;
using Hospital.DNA.API.Interface;
using Hospital.DNA.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.DNA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DNAController : ControllerBase
    {
        private readonly IDNABusiness _dnaBusiness;
        public DNAController()
        {
            _dnaBusiness = new DNABusiness();
        }
        // GET api/dna/analisadna
        [HttpPost]
        [Route("analisadna")]
        public ActionResult<IList<string>> AnalisaDNA(DnaVM dna)
        {
            return _dnaBusiness.AnalisaDNA(dna).ToList();
        }
    }
}
