using System;
namespace BabyRecords_Server.core.users.Dto
{
    public class registerDto
    {
        public int Id { get; set; }

        public string name { get; set; }

        public string account { get; set; }

        public string password { get; set; }

        public string reqpassword { get; set; }

        public string email { get; set; }
    }
}
