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
    using System.Collections.Generic;
    
    public partial class Offer
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdAgent { get; set; }
        public int IdRealObject { get; set; }
        public Nullable<int> MinPrice { get; set; }
        public Nullable<int> MaxPrice { get; set; }
    
        public virtual Agents Agents { get; set; }
        public virtual ApartmentOffer ApartmentOffer { get; set; }
        public virtual Client Client { get; set; }
        public virtual HouseOffer HouseOffer { get; set; }
        public virtual LandOffer LandOffer { get; set; }
        public virtual TypeObject TypeObject { get; set; }
    }
}
