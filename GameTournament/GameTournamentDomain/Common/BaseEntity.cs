using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTournamentDomain.Common
{
    public class BaseEntity<TKey> 
    {
        public TKey Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int UserCreatedId { get; set; }
        public int UserModifiedId { get; set; }
    }
}
