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
        /**
         * To get all preivous chat list from DB.
         * */
        List<ChatEntity> getChatList(int list_idnum);

        /**
         * To add new chat list to DB.
         * */
        bool setChatList(int list_idnum, string writtenBy, string body);
    }
}
