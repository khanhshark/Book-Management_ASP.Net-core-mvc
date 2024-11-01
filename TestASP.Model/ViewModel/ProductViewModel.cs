using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace BookASP.Model.ViewModel
{
	public class ProductViewModel
	{
		public Product product { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> CategoryList { get; set;}
	}
}
