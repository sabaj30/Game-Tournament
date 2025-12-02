using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTournamentApplication.Base
{
    public record BaseDto<TKey>
    {
        public TKey Id { get; set; }
    }
}
