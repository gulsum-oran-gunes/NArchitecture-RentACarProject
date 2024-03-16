using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Dynamic
{
    public class Sort
    {
        public string Field { get; set; } // sıralama alanı, hangi alan sıralanacak
        public string Dir { get; set; } // asc ya da desc hangi sırayla sıralanacak

        public Sort()
        {
            
        }
        public Sort(string field, string dir)
        {
            Field = field;
            Dir = dir;
        }
    }
}
