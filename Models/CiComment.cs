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
    
    public partial class CiComment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CiComment()
        {
            this.CiReply = new HashSet<CiReply>();
        }
    
        public int CiComment_id { get; set; }
        public int Ci_id { get; set; }
        public string ComContent { get; set; }
        public System.DateTime ComTime { get; set; }
        public string Users_id { get; set; }
    
        public virtual Ci Ci { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CiReply> CiReply { get; set; }
    }
}
