using System;
using System.Collections.Generic;

namespace CriadoresCaes_tA_B.Models {

   /// <summary>
   /// classe para permitir o transporte do Controller para a View, e vice-versa
   /// irá transportar os dados das Fotografias e dos IDs do Cães que pertencem 
   /// à pessoa autenticada
   /// </summary>
   public class FotosCaes {

      /// <summary>
      /// lista de todas as fotografias de todos os cães
      /// </summary>
      public ICollection<Fotografias> ListaFotografias { get; set; }

      /// <summary>
      /// lista dos IDs dos cães que pertencem à pessoa autenticada
      /// </summary>
      public ICollection<int> ListaCaes { get; set; }

   }




   public class ErrorViewModel {
      public string RequestId { get; set; }
      public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
   }

}
