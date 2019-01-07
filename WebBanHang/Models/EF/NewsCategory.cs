namespace WebBanHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsCategory")]
    public partial class NewsCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NewsCategory()
        {
            Newss = new HashSet<News>();
        }
        public long ID { get; set; }
        [StringLength(500)]
        [Display(Name = " Tên (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public string Name { get; set; }

        [StringLength(250)]
        [Display(Name = "Đường dẫn (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public string MetaTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<News> Newss { get; set; }
    }
}