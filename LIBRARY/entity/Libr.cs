using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY.entity
{
    class Libr : ItemInterface

    {
        public int INN { get; set; }
        public string ISBN { get; set; }
        public DateTime Date { get; set; }
        
    }
 }
