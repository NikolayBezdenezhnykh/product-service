﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public ObjectId Id { get; set; }

        public long ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

    }
}
