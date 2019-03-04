using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ChatEntity
    {
        public int idnum { get; set; }

        public int? list_idnum { get; set; }

        public string body { get; set; }

        public string writtenBy { get; set; }
    }
}
