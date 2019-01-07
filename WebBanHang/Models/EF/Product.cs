namespace WebBanHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Sales = new HashSet<Sale>();
            Images = new HashSet<Image>();
            Comments = new HashSet<Comment>();
        }

        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public string Name { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã sản phẩm (*)")]
        public string Code { get; set; }

        [StringLength(250)]
        [Display(Name = "Đường dẫn (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public string MetaTitle { get; set; }

        [Display(Name = "Giá (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public decimal? Price { get; set; }

        [AllowHtml]
        [Display(Name = "Mô tả (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public string Description { get; set; }

        [Display(Name = "Số lượng tồn (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public int Quantity { get; set; }

        [AllowHtml]
        [Display(Name = "Chi tiết (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public string Detail { get; set; }

        public bool IsHot { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name="Ngày tạo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        public bool Status { get; set; }

        [Display(Name = "Nhà sản xuất")]
        public long? ProducerID { get; set; }

        [Display(Name = "Danh mục")]
        public long? ProductCategoryID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Images { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Producer Producer { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

  
    }
}