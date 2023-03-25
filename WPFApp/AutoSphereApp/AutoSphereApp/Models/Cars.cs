//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoSphereApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cars
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cars()
        {
            this.Orders = new HashSet<Orders>();
            this.TestDrive = new HashSet<TestDrive>();
        }
    
        public int CarID { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public string VIN { get; set; }
        public Nullable<int> DriveID { get; set; }
        public string Actuality { get; set; }
    
        public virtual Drives Drives { get; set; }
        public virtual Countrys Countrys { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestDrive> TestDrive { get; set; }
    }
}
