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
    
    public partial class UserReply
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserReply()
        {
            this.UserReply1 = new HashSet<UserReply>();
        }
    
        public int Reply_id { get; set; }
        public string Users_id { get; set; }
        public string ReplyContent { get; set; }
        public Nullable<System.DateTime> ReplyTime { get; set; }
        public Nullable<int> ReReply_id { get; set; }
        public string U_id { get; set; }
    
        public virtual UserInfo UserInfo { get; set; }
        public virtual UserInfo UserInfo1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserReply> UserReply1 { get; set; }
        public virtual UserReply UserReply2 { get; set; }
    }
}
