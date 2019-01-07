namespace WebBanHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Image")]
    public partial class Image
    {    
        public long ID { get; set; }

        [StringLength(500)]
        [Display(Name = " Nguồn (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public string Src { get; set; }

        [Display(Name = "Tên Sản phẩm (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public long? ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}