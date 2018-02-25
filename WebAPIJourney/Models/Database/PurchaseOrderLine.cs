//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIJourney.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseOrderLine
    {
        public int PurchaseOrderLineID { get; set; }
        public int PurchaseOrderID { get; set; }
        public int StockItemID { get; set; }
        public int OrderedOuters { get; set; }
        public string Description { get; set; }
        public int ReceivedOuters { get; set; }
        public int PackageTypeID { get; set; }
        public Nullable<decimal> ExpectedUnitPricePerOuter { get; set; }
        public Nullable<System.DateTime> LastReceiptDate { get; set; }
        public bool IsOrderLineFinalized { get; set; }
        public int LastEditedBy { get; set; }
        public System.DateTime LastEditedWhen { get; set; }
    
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
