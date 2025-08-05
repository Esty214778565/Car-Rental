using CarRental.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarRental.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CollectionPointEntity> CollectionPoints { get; set; }
        public DbSet<InvitationEntity> Invitations { get; set; }





    }
}
