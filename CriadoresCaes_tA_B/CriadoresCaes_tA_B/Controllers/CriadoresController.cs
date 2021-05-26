using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CriadoresCaes_tA_B.Data;
using CriadoresCaes_tA_B.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CriadoresCaes_tA_B.Controllers {


   [Authorize]
   public class CriadoresController : Controller {
      /// <summary>
      /// referência à base de dados
      /// </summary>
      private readonly CriadoresCaesDB _context;

      /// <summary>
      /// objeto que sabe interagir com os dados do utilizador q se autentica
      /// </summary>
      private readonly UserManager<ApplicationUser> _userManager;



      public CriadoresController(
         CriadoresCaesDB context,
         UserManager<ApplicationUser> userManager) {
         _context = context;
         _userManager = userManager;
      }

      // GET: Criadores
      public async Task<IActionResult> Index() {
         return View(await _context.Criadores.ToListAsync());
      }

      // GET: Criadores/Details/5
      public async Task<IActionResult> Details(int? id) {
         if (id == null) {
            return NotFound();
         }

         var criadores = await _context.Criadores
             .FirstOrDefaultAsync(m => m.Id == id);
         if (criadores == null) {
            return NotFound();
         }

         return View(criadores);
      }






      //// GET: Criadores/Create
      //public IActionResult Create()
      //{
      //    return View();
      //}

      //// POST: Criadores/Create
      //// To protect from overposting attacks, enable the specific properties you want to bind to.
      //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      //[HttpPost]
      //[ValidateAntiForgeryToken]
      //public async Task<IActionResult> Create([Bind("Id,Nome,NomeComercial,Morada,CodPostal,Telemovel,Email")] Criadores criadores)
      //{
      //    if (ModelState.IsValid)
      //    {
      //        _context.Add(criadores);
      //        await _context.SaveChangesAsync();
      //        return RedirectToAction(nameof(Index));
      //    }
      //    return View(criadores);
      //}


      /// <summary>
      /// Método para apresentar os dados dos Criadores a autorizar
      /// </summary>
      /// <returns></returns>
      [HttpGet]
      [Authorize(Roles = "Gestor")]
      public async Task<IActionResult> ListaCriadoresPorAutorizar() {

         // quais os Criadores ainda não autorizados a aceder ao Sistema?
         // lista com os utilizadores bloqueados
         var listaDeUtilizadores = _userManager.Users.Where(u => u.LockoutEnd > DateTime.Now);
         // lista com os dados dos Criadores
         var listaCriadores = _context.Criadores
                                      .Where(c => listaDeUtilizadores.Select(u => u.Id)
                                                                    .Contains(c.UserName));
         /* Em SQL seria algo deste género
          * SELECT c.*
          * FROM Criadores c, Users u
          * WHERE c.UserName = u. Id AND
          *       u.LockoutEnd > Data Atual          * 
          */

         // Enviar os dados para a View
         return View(await listaCriadores.ToListAsync());
      }


      /// <summary>
      /// método que recebe os dados dos utilizadores a desbloquear
      /// </summary>
      /// <param name="utilizadores">lista desses utilizadores</param>
      /// <returns></returns>
      [HttpPost]
      [Authorize(Roles = "Gestor")]
      /*
       [Authorize(Roles = "Gestor")]  -->  só permite que pessoas com esta permissão entrem
     
       [Authorize(Roles = "Gestor,Cliente")]  --> permite acesso a pessoas com uma das duas roles
       
       [Authorize(Roles = "Gestor")]     -->
       [Authorize(Roles = "Cliente")]    -->  Neste caso, a pessoa tem de pertencer aos dois roles
      */
      public async Task<IActionResult> ListaCriadoresPorAutorizar(string[] utilizadores) {

         // será que algum utilizador foi selecionado?
         if (utilizadores.Count() != 0) {
            // há users selecionados
            // para cada um, vamos desbloqueá-los
            foreach (string u in utilizadores) {
               try {
                  // procurar o 'utilizador' na tabela dos Users
                  var user = await _userManager.FindByIdAsync(u);
                  // desbloquear o utilizador
                  await _userManager.SetLockoutEndDateAsync(user, DateTime.Now.AddDays(-1));
                  // como não se pediu ao User para validar o seu email
                  // é preciso aqui validar esse email
                  string codigo = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                  await _userManager.ConfirmEmailAsync(user, codigo);

                  // eventualmente, poderá ser enviado um email para o utilizador a avisar que 
                  // a sua conta foi desbloqueada
               }
               catch (Exception) {
                  // deveria haver aqui uma mensagem de erro para o utilizador,
                  // se assim o entender
               }
            }
         }

         return RedirectToAction("Index");
      }


      // GET: Criadores/Edit/5
      public async Task<IActionResult> Edit(int? id) {
         if (id == null) {
            return NotFound();
         }

         var criadores = await _context.Criadores.FindAsync(id);
         if (criadores == null) {
            return NotFound();
         }
         return View(criadores);
      }

      // POST: Criadores/Edit/5
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,NomeComercial,Morada,CodPostal,Telemovel,Email")] Criadores criadores) {
         if (id != criadores.Id) {
            return NotFound();
         }

         if (ModelState.IsValid) {
            try {
               _context.Update(criadores);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
               if (!CriadoresExists(criadores.Id)) {
                  return NotFound();
               }
               else {
                  throw;
               }
            }
            return RedirectToAction(nameof(Index));
         }
         return View(criadores);
      }

      // GET: Criadores/Delete/5
      public async Task<IActionResult> Delete(int? id) {
         if (id == null) {
            return NotFound();
         }

         var criadores = await _context.Criadores
             .FirstOrDefaultAsync(m => m.Id == id);
         if (criadores == null) {
            return NotFound();
         }

         return View(criadores);
      }

      // POST: Criadores/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id) {
         var criadores = await _context.Criadores.FindAsync(id);
         _context.Criadores.Remove(criadores);
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private bool CriadoresExists(int id) {
         return _context.Criadores.Any(e => e.Id == id);
      }
   }
}
