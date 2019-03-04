using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class DashboardEntity
    {
        public int idnum { get; set; }

        public string title { get; set; }

        public string createdBy { get; set; }

        public string assignee { get; set; }

        public DateTime? deadline { get; set; }

        public string status { get; set; }

        public string priority { get; set; }

        public List<ChatEntity> chatList { get; set; }
    }
}
