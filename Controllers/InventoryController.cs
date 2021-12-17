using BAL.Service;
using DAL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ShopBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        private readonly IRepository<Inventory> _Inventory;
        public InventoryController(IRepository<Inventory> Inventory, InventoryService InventoryService)
        {
            _inventoryService = InventoryService;
            _Inventory = Inventory;

        }
        //Add Inventory  
        [HttpPost("AddInventory")]
        public async Task<Object> AddInventory([FromBody] Inventory Inventory)
        {
            try
            {
                await _inventoryService.AddInventory(Inventory);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete Inventory  
        [HttpDelete("DeleteInventory")]
        public bool DeleteInventory(int id)
        {
            try
            {
                _inventoryService.DeleteInventory(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Update Inventory  
        [HttpPut("UpdateInventory")]
        public bool UpdateInventory(Inventory Object)
        {
            try
            {
                _inventoryService.UpdateInventory(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //GET All Inventory  
        [HttpGet("GetAllInventory")]
        public Object GetAllPersons()
        {
            var data = _inventoryService.GetAllInventory();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}
