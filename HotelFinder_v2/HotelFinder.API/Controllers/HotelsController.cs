using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            //_hotelService = new HotelManager();
            _hotelService = hotelService;
        }

        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get() //public List<Hotel> Get()
        {
            var hotels = await _hotelService.GetAllHotels();
            return Ok(hotels);//200 + data
        }

        /// <summary>
        /// Get Hotel by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("[action]/{id}")] //api/hotels/gethotelbyid/2
        public async Task<IActionResult> GetHotelById(int id)// public Hotel Get(int id)
        {
            var hotel =await _hotelService.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{name}")] //api/hotels/gethotelbyname/2
        public async Task<IActionResult> GetHotelByName(string name)// public Hotel Get(int id)
        {
            var hotel = await _hotelService.GetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel); //200 + data
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]")] //api/hotels/GetHotelByIdAndName/?id=1&name=istanbul
        public IActionResult GetHotelByIdAndName(int id,string name)
        {
            return Ok();
        }

        /// <summary>
        /// Create an Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateHotel")]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel) // public Hotel Post([FromBody] Hotel hotel)
        {
            //if(ModelState.IsValid) //ApiController kullanıldığı için kontrol etmeye gerek kalmıyor
            //{
                var createdHotel= await _hotelService.CreateHotel(hotel);
                return CreatedAtAction("Get",new {id = createdHotel.Id}); //201 + data
            //}
            //return BadRequest(ModelState);

        }

        /// <summary>
        /// Update the Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateHotel([FromBody] Hotel hotel)
        {
            if(await _hotelService.GetHotelById(hotel.Id)!=null)
            {
                return Ok(await _hotelService.UpdateHotel(hotel));//200 + data
            }
            return NotFound();
        }

        /// <summary>
        /// Delete the Hotel
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(int id) // public void Delete(int id)
        {
            if (await _hotelService.GetHotelById(id) != null)
            {
                await _hotelService.DeleteHotel(id);
                return Ok();//200
            }
            return NotFound();

        }

    }
}
