//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clients26
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ClientsContainer : DbContext
    {
        public ClientsContainer()
            : base("name=ClientsContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Agents> Agents { get; set; }
        public virtual DbSet<ApartmentOffer> ApartmentOffer { get; set; }
        public virtual DbSet<Apartments> Apartments { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<HouseOffer> HouseOffer { get; set; }
        public virtual DbSet<Houses> Houses { get; set; }
        public virtual DbSet<LandOffer> LandOffer { get; set; }
        public virtual DbSet<Lands> Lands { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<RealEstateObjects> RealEstateObjects { get; set; }
        public virtual DbSet<TypeObject> TypeObject { get; set; }
        public virtual DbSet<Supplies> Supplies { get; set; }
    }
}
