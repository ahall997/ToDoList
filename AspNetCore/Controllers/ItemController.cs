using Microsoft.AspNetCore.Mvc;
using AspNetCore.Data;
using AspNetCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemRepo _itemRepo;

        public ItemController(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Item>>> Get()
        {
            return Ok(_itemRepo.GetAllItems());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return Ok(_itemRepo.GetItemById(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateItem(string description)
        {
            Item newItem = _itemRepo.CreateItem(description);
            return Ok(newItem);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(int id)
        {
            var existingItem = _itemRepo.GetItemById(id);
            
            if(existingItem == null) {
                return NotFound();
            }
            _itemRepo.Updateitem(existingItem);
            return Ok(existingItem);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteItem(int id) {
            var existingItem = _itemRepo.GetItemById(id);
            _itemRepo.DeleteItem(existingItem);
            return Ok(existingItem);
        }
    }
}