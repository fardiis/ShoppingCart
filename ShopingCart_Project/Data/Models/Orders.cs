using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ShopingCart_Project.Data.Models
{
    public class Orders
    {

        [Key]
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "نام را وارد نمایید")]
        [StringLength(50)]
        [Display(Name = "نام")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "نام خانوادگی را وارد نمایید")]
        [StringLength(50)]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "آدرس را وارد نمایید")]
        [StringLength(200)]
        [Display(Name = "آدرس")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Required(ErrorMessage = "موبایل را وارد نمایید")]
        [StringLength(15)]
        [Display(Name = "موبایل")]
        public string Mobile { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }
        public DateTime OrderTime { get; set; }
        public List<OrderDetails> OrderList { get; set; }
    }
}
