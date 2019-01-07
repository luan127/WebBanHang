namespace WebBanHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sale
    {
        public long ID { get; set; }
        [Display(Name = "Giá (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        [Range(0, 100)]
        public decimal? Discount { get; set; }

        [Display(Name = "Ngày bắt đầu (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }

        [Display(Name = "Ngày kết thúc (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Tên Sản phẩm (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public long? ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}