namespace WebBanHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("News")]
    public partial class News
    {
        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name = "Tiêu đề (*)")]
        [Required(ErrorMessage = "Trường này không được trống !")]
        public string Title { get; set; }
        
        [AllowHtml]
        [Display(Name = "Nội dung (*)")]
        [Required(ErrorMessage = "Trường này không được trống !")]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy hh:mm:ss tt}",ApplyFormatInEditMode =true)]
        public DateTime CreateDate { get; set; }

        [StringLength(250)]
        [Display(Name = "Đường dẫn (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public string MetaTitle { get; set; }

        public virtual NewsCategory NewsCategory { get; set; }

    }
}