using Hackathon.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder orderRepo;
        public OrderController(IOrder _orderRepo)
        {
            this.orderRepo = _orderRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrder()
        {
            try
            {
                return Ok(await orderRepo.GetOrder());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            try
            {
                var result = await orderRepo.GetOrder(id);
                if (result == null)
                    return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest();
                }

                var createdOrder= await orderRepo.AddOrder(order);
                return CreatedAtAction(nameof(GetOrder),
                    new { id = createdOrder.Id }, createdOrder
                    );
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating new Customer record");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            try
            {
                var orderToDelete = await orderRepo.GetOrder(id);
                if (orderToDelete == null)
                {
                    return NotFound($"Customer with Id={id} not found");
                }

                return await orderRepo.DeleteOrder(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Order>> UpdateOrder(int id, Order order)
        {
            try
            {
                if (id != order.Id)
                    return BadRequest("Customer ID mismatch");

                var orderToUpdate = await orderRepo.GetOrder(id);

                if (orderToUpdate == null)
                    return NotFound($"Customer with Id = {id} not found");

                return await orderRepo.UpdateOrder(order);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}
