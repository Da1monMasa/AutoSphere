//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoSphereApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int OrderID { get; set; }
        public Nullable<int> CarID { get; set; }
        public Nullable<int> Garanty { get; set; }
        public Nullable<System.DateTime> DateOfOrder { get; set; }
        public Nullable<int> StuffID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<int> ServID { get; set; }
        public Nullable<decimal> Sum { get; set; }
    
        public virtual Cars Cars { get; set; }
        public virtual Clients Clients { get; set; }
        public virtual Services Services { get; set; }
        public virtual Stuff Stuff { get; set; }
    }
}