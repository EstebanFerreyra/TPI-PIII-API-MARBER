using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Services.Services;

namespace Interface.Controllers
{
    [Route("Marber/BeerController")]
    public class BeerController : Controller
    {

        private readonly BeerService _beerService;
        public BeerController(BeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpGet("GetBeers")]
        public ActionResult<List<Beer>> GetBeers()
        {
            var response = _beerService.GetListBeer();
            return Ok(response);
        }

        // AGREAGAR GetBeerById

        //[HttpPost("AddBeer")]
        //public ActionResult AddBeer([FromBody] Beer beer)
        //{

        //    // agregar que devuelva url por header y objeto agregado por body


        //    var response = _beerService.AddBeer(beer);
        //    return Ok(response);
        //}


        //[HttpPut("ModifyBeerById/{id}")]
        //public ActionResult<List<Beer>> ModifyBeer(int id, [FromBody] decimal price)
        //{
        //    var response = _beerService.ModifyBeer(id, price);
        //    return Ok(response);
        //}



        //[HttpDelete("deletebeerbyid/{id}")]
        //public ActionResult<List<Beer>> deletebeerbyid(int id)
        //{
        //    var response = _beerService.DeleteBeerById(id);
        //    return Ok(response);
        //}

    }
}
