using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Entities
{
    public class BlogDestination
    {        
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}