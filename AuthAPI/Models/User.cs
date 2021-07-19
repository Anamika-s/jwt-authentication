using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthAPI.Models
{
    public class User
    {
        [BsonId]
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
