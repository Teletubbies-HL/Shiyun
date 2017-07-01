//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Goods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Goods()
        {
            this.OrdersDetails = new HashSet<OrdersDetails>();
            this.ShopCar = new HashSet<ShopCar>();
        }
    
        public int Goods_id { get; set; }
        public string GoodsName { get; set; }
        public string GoodsImage { get; set; }
        public string GoodsJianjie { get; set; }
        public string GoodsDetails { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Count { get; set; }
        public string GoodsK_id { get; set; }
        public Nullable<int> flag { get; set; }
    
        public virtual GoodsK GoodsK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersDetails> OrdersDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShopCar> ShopCar { get; set; }
    }
}
