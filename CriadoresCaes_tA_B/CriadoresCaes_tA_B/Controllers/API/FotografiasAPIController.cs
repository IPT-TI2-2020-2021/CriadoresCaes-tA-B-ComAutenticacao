using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CriadoresCaes_tA_B.Data;
using CriadoresCaes_tA_B.Models;

namespace CriadoresCaes_tA_B.Controllers.API {
   [Route("api/[controller]")]
   [ApiController]
   public class FotografiasAPIController : ControllerBase {
      private readonly CriadoresCaesDB _context;

      public FotografiasAPIController(CriadoresCaesDB context) {
         _context = context;
      }

      // GET: api/FotografiasAPI
      /// <summary>
      /// 'Endpoint' a apresentar os dados da Fotografias,
      ///  para integrar com a app REACT
      ///  Naturalmente, este 'endpoint' poderá ser acedido por outra aplicação qualquer...
      /// </summary>
      /// <returns></returns>
      [HttpGet]
      public async Task<ActionResult<IEnumerable<FotosAPIViewModel>>> GetFotografias() {
         return await _context.Fotografias
                              .Include(f => f.Cao)
                              .Select(f => new FotosAPIViewModel {
                                 IdFoto = f.Id,
                                 NomeFoto = f.Fotografia,
                                 LocalFoto = f.Local,
                                 DataFoto = f.DataFoto.ToShortDateString(),
                                 NomeCao = f.Cao.Nome
                              })
                              .ToListAsync();
      }

      // GET: api/FotografiasAPI/5
      [HttpGet("{id}")]
      public async Task<ActionResult<Fotografias>> GetFotografias(int id) {
         var fotografias = await _context.Fotografias.FindAsync(id);

         if (fotografias == null) {
            return NotFound();
         }

         return fotografias;
      }

      // PUT: api/FotografiasAPI/5
      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      [HttpPut("{id}")]
      public async Task<IActionResult> PutFotografias(int id, Fotografias fotografias) {
         if (id != fotografias.Id) {
            return BadRequest();
         }

         _context.Entry(fotografias).State = EntityState.Modified;

         try {
            await _context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException) {
            if (!FotografiasExists(id)) {
               return NotFound();
            }
            else {
               throw;
            }
         }

         return NoContent();
      }

      // POST: api/FotografiasAPI
      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      [HttpPost]
      public async Task<ActionResult<Fotografias>> PostFotografias(Fotografias fotografias) {
         _context.Fotografias.Add(fotografias);
         await _context.SaveChangesAsync();

         return CreatedAtAction("GetFotografias", new { id = fotografias.Id }, fotografias);
      }

      // DELETE: api/FotografiasAPI/5
      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteFotografias(int id) {
         var fotografias = await _context.Fotografias.FindAsync(id);
         if (fotografias == null) {
            return NotFound();
         }

         _context.Fotografias.Remove(fotografias);
         await _context.SaveChangesAsync();

         return NoContent();
      }

      private bool FotografiasExists(int id) {
         return _context.Fotografias.Any(e => e.Id == id);
      }
   }
}
