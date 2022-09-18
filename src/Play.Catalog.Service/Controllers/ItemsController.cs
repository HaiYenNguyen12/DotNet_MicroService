using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.DTOs;

namespace Play.Catalog.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDto> items = new()
        {
            new ItemDto(Guid.NewGuid(), "Potion1","Nice1",1, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Potion2","Nice2",2, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Potion3","Nice3", 3,DateTimeOffset.UtcNow),
        };
        [HttpGet]
        public ActionResult<IEnumerable<ItemDto>> Get()
        {
            return items;
        }
        

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetById(Guid id)
        {
            var item = items.Where(item => item.Id== id).SingleOrDefault();
            if(item==null)
            {
                return    NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<ItemDto> Post(CreateItem createItemDto)
        {
            ItemDto item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price, DateTimeOffset.UtcNow);
            items.Add(item);

            return CreatedAtAction(nameof(GetById), new{id = item.Id} , item);
        }
     
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, UpdateTimeDto updateItemDto)
        {
            var item =  items.Where(item => item.Id == id).FirstOrDefault();
            if(item==null)
            {
                return  NotFound();
            }

            var updateItem = item with 
            {
                Name = updateItemDto.Name,
                Description = updateItemDto.Description,
                Price = updateItemDto.Price
            };

            var index = items.FindIndex(item => item.Id == id);
            items[index] = updateItem;

            return NoContent();


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
             var item =  items.Where(item => item.Id == id).FirstOrDefault();
             if (item != null)
             {
                items.Remove(item);

             }
             else 
             {
                return NotFound();
             }
             return NoContent();
        }
    }
}