using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entities.Commons
{
    public class EntityBase
    {
       [BsonId]
        public ObjectId Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }
    }
}
