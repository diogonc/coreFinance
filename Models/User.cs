using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace financeApi.Models
{
    public class User
    {
        public string uuid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string propertyUuid { get; set; }
        
        public ObjectId _id {get; set;}
        public string createdAt {get; set;}
        public string updatedAt {get; set;}
    }
}