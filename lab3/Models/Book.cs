namespace lab3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "ID Không được để trống")]
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Số ký tự không quá 100.")]
        [Display(Name = "Tựa sách")]
        [Required(ErrorMessage = "Tiêu đề Không được để trống")]
        public string Title { get; set; }

        
        [Required(ErrorMessage = "Nội dung Không được để trống")]
        public string Description { get; set; }

        [StringLength(30, ErrorMessage = "Số ký tự không quá 30.")]
        [Display(Name = "Tên tác giả")]
        [Required(ErrorMessage = "Tên tác giả Không được để trống")]
        public string Author { get; set; }

        
        [Required(ErrorMessage = "Hình Không được để trống")]
        public string Image { get; set; }

        [Range(1000, 1000000, ErrorMessage = "Giá sách từ 1000- 1000000")]
        [Required(ErrorMessage = "Giá Không được để trống")]
        public int Price { get; set; }
    }
}
