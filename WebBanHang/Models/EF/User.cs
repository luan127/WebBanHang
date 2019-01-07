using Microsoft.AspNet.Identity;
namespace WebBanHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Orders = new HashSet<Order>();
            Comments = new HashSet<Comment>();
        }
        
        public long ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Tài khoản (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public string Username { get; set; }

        [StringLength(50)]
        [Display(Name = "Mật khẩu (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public string Name { get; set; }

        [StringLength(100)]
        [Display(Name = "Ảnh đại diện (*)")]
        public string Avatar { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public string Address { get; set; }

        [StringLength(50)]
        [Display(Name = "Email (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public string Email { get; set; }

        [StringLength(5)]
        [Display(Name = "Giới tính")]
        public string Genre { get; set; }

        [Column(TypeName = "Date")]
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public DateTime? BirthDay { get; set; }

        [StringLength(50)]
        [Display(Name = "SĐT (*)")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public string Phone { get; set; }
        [Display(Name = "Ngày tạo")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Quyền")]
        [Required(ErrorMessage = "Trường này không được rỗng!")]
        public int? Permission { get; set; }

        public bool Active { get; set; }
        public bool Block { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
    }

}