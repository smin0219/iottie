using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entity;
using Domain.Context;

namespace Domain.Concrete
{
    public class Detail : IDetail
    {
        public List<ChatEntity> getChatList(int list_idnum)
        {
            List <ChatEntity> list = new List<ChatEntity>();

            using (DBContext context = new DBContext())
            {
                try
                {
                    list = (from a in context.Chat
                            where a.list_idnum == list_idnum
                            select new ChatEntity
                            {
                                idnum = a.idnum,
                                list_idnum = a.list_idnum,
                                body = a.body,
                                writtenBy = a.writtenBy
                            }).ToList();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            } 

                return list;
        }

        public bool setChatList(int list_idnum, string writtenBy, string body)
        {
            var result = false;

            Chat chat = new Chat
            {
                list_idnum = list_idnum,
                body = body,
                writtenBy = writtenBy
            };

            try
            {
                DBContext context = new DBContext();
                context.Chat.Add(chat);
                context.SaveChanges();

                result = true;

                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return result;
            }
        }
    }
}
