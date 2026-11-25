using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface ITamarStore
    {
        DbSet<Category> Categories { get; set; }
      
        DbSet<Users> Users { get; set; }
        //Task<int> SaveChangesAsync();
        //DbSet<OrderItem> OrderItem { get; set; } 
        //DbSet<Product> Product { get; set; }
        //DbSet<Order> Order { get; set; }
    }
}
