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
    
    public partial class Lands
    {
        public int Id { get; set; }
        public Nullable<decimal> TotalArea { get; set; }
    
        public virtual RealEstateObjects RealEstateObjects { get; set; }
    }
}
