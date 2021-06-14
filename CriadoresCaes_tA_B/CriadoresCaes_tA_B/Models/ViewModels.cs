using System;
using System.Collections.Generic;

namespace CriadoresCaes_tA_B.Models {


   /// <summary>
   /// ViewModel para transportar os dados das Fotografias
   /// dos c�es, na API
   /// </summary>
   public class FotosAPIViewModel {
      /// <summary>
      /// id da Foto
      /// </summary>
      public int IdFoto { get; set; }

      /// <summary>
      /// nome do ficheiro da foto
      /// </summary>
      public string NomeFoto { get; set; }

      /// <summary>
      /// local onde a foto foi tirada
      /// </summary>
      public string LocalFoto { get; set; }

      /// <summary>
      /// data em que a foto foi tirada
      /// </summary>
      public string DataFoto { get; set; }

      /// <summary>
      /// nome do C�o
      /// </summary>
      public string NomeCao { get; set; }
   }




   /// <summary>
   /// classe para permitir o transporte do Controller para a View, e vice-versa
   /// ir� transportar os dados das Fotografias e dos IDs do C�es que pertencem 
   /// � pessoa autenticada
   /// </summary>
   public class FotosCaes {

      /// <summary>
      /// lista de todas as fotografias de todos os c�es
      /// </summary>
      public ICollection<Fotografias> ListaFotografias { get; set; }

      /// <summary>
      /// lista dos IDs dos c�es que pertencem � pessoa autenticada
      /// </summary>
      public ICollection<int> ListaCaes { get; set; }

   }




   public class ErrorViewModel {
      public string RequestId { get; set; }
      public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
   }

}
