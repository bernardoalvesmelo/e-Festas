using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Festas.Dominio.ModuloTema
{
    public class ItemTema 
    {
        public string nome;
        public decimal valorItem;

        public ItemTema(string nome,decimal valorItem)
        {
           this.nome = nome;
           this.valorItem = valorItem;
        }

       
    }
}
