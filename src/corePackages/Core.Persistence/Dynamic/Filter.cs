using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Dynamic
{
    public class Filter
    {
        public string Field {  get; set; } // filtreleme kriterleri, bu field'e göre filtreleme
        public string Operator { get; set; } // == >= <= gibi operatörler
        public string? Value { get; set; } // operatöre göre karşılaştırılacak değerler

        public string? Logic { get; set; } // and or gibi mantıksal bağlar
        public IEnumerable<Filter>? Filters { get; set;} // iç içe geçmiş filtre koleksiyonu
        public Filter()
        {
            
        }

        public Filter(string field, string @operator, string? value, string? logic, IEnumerable<Filter>? filters)
            :this()
        {
            Field = field;
            Operator = @operator;
            Value = value;
            Logic = logic;
            Filters = filters;
        }
    }
}
