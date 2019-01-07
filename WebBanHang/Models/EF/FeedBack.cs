namespace WebBanHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedBack")]
    public partial class FeedBack
    {
        public long ID { get; set; }
        [StringLength(50)]
        [Display(Name = "Tên (*)")]
        [Required(ErrorMessage = "Trường này không được trống !")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "SĐT (*)" )]
        [Required(ErrorMessage = "Trường này không được trống !")]
        public string phone { get; set; }

        [StringLength(50)]
        [Display(Name = "Email (*)")]
        [Required(ErrorMessage = "Trường này không được trống !")]
        public string Email { get; set; }

        [StringLength(250)]
        [Display(Name ="Địa chỉ")]
        public string Address { get; set; }
        [StringLength(250)]
        [Display(Name = "Nội dung (*)")]
        [Required(ErrorMessage = "Trường này không được trống !")]
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}