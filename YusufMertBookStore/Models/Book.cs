using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YusufMertBookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        [StringLength(512,MinimumLength =3)]//nvarchar(512),not nullable
        [Required]
        [Display(Name ="Kitap Adı")]
        public string Title { get; set; }
        public int? PageCount { get; set; }
        public string Authors { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public int PressYear { get; set; }
        public int StockCount { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public Book() 
        {
            CreatedDate = DateTime.Now;
        }
        public virtual List<BookImage> BookImages { get; set; }

    }
}
