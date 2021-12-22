using Microsoft.EntityFrameworkCore;
using BabyRecords_Server.Entities;


namespace BabyRecords_Server.Model
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions <MyDbContext> options) : base(options)
        {
        }
        public DbSet<User_Entity> Users { get; set; }
        public DbSet<Baby_info_Entity> BabyInfo { get; set; }
        public DbSet<Family_Group_Entity> familyGroup { get; set; }
        public DbSet<Family_Group_Member_Entity> familyGroupMember { get; set; }
        public DbSet<Baby_Record_Entity> babyRecord { get; set; }
        public DbSet<Baby_FaceCover_Entity> babyFaceCover { get; set; }
        public DbSet<Baby_Area_Entity> babyArea { get; set; }
        public DbSet<temp_and_humidity_Entity> TempAndHumidity { get; set; }
    }
}
