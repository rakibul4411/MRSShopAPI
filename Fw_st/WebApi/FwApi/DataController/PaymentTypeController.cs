using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FwCore.DBContext;
using FwCore.DBContext.Model;

namespace FwApi.DataController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private readonly AppDataDbContext _context;

        public PaymentTypeController(AppDataDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentType>>> GetpaymentType()
        {
            return await _context.paymentType.ToListAsync();
        }

        // GET: api/PaymentType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentType>> GetPaymentType(int id)
        {
            var paymentType = await _context.paymentType.FindAsync(id);

            if (paymentType == null)
            {
                return NotFound();
            }

            return paymentType;
        }

        // PUT: api/PaymentType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentType(int id, PaymentType paymentType)
        {
            if (id != paymentType.PaymentTypeID)
            {
                return BadRequest();
            }

            _context.Entry(paymentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymentType
        [HttpPost]
        public async Task<ActionResult<PaymentType>> PostPaymentType(PaymentType paymentType)
        {
            _context.paymentType.Add(paymentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentType", new { id = paymentType.PaymentTypeID }, paymentType);
        }

        // DELETE: api/PaymentType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentType>> DeletePaymentType(int id)
        {
            var paymentType = await _context.paymentType.FindAsync(id);
            if (paymentType == null)
            {
                return NotFound();
            }

            _context.paymentType.Remove(paymentType);
            await _context.SaveChangesAsync();

            return paymentType;
        }

        private bool PaymentTypeExists(int id)
        {
            return _context.paymentType.Any(e => e.PaymentTypeID == id);
        }
    }
}
