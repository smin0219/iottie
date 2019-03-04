using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Abstract
{
    public interface IDetail
    {
        List<ChatEntity> getChatList(int list_idnum);
        bool setChatList(int list_idnum, string writtenBy, string body);
    }
}
