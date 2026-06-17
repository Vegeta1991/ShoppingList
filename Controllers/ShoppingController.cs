using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models;
using ShoppingList.Repositories;

namespace ShoppingList.Controllers
{
    [ApiController]//Rest API controller 
    [Route("api/[controller]")]//url api/shopping
    public class ShoppingController : ControllerBase
    {
        private readonly ShoppingRepository _repository;

        public ShoppingController(ShoppingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]//Get all shopping items
        public IActionResult GetAll()
        {
            var items = _repository.GetAll();
            return Ok(items);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _repository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Add([FromBody] ShoppingItem item)
        {
            _repository.Add(item);
            return Ok(item);
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var item = _repository.Remove(id);
            if(item == null)
            {
                return NotFound();
            }
            return NoContent();//204 no content, does not return the deleted item
        }
        [HttpPut("{id}")]

        public IActionResult Update(int id, [FromBody] ShoppingItem item)
        {
            if (id != item.Id) // check if the id in the URL matches the id in the body
            {
                return BadRequest();
            }
            var existingItem = _repository.GetById(id);// check if the item exists before updating
            if (existingItem == null)
            {
                return NotFound();
            }
            var updatedItem = _repository.Update(item);// update the item in the repository

            return Ok(updatedItem);// return the updated item in the response
        }
    }
}
