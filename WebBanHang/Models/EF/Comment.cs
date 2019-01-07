namespace WebBanHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Comment")]
    public partial class Comment
    {
        public long ID { get; set; }

        [Display(Name = "Nội dung (*)")]
        [Required(ErrorMessage = "Trường này không được trống !")]
        public string Content { get; set; }
        public int? Vote { get; set; }
        public long? UserID { get; set; }
        public long? ProductID { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }

    }
}