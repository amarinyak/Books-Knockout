using System.Collections.Generic;

namespace Books.Web.ViewModels
{
	public class ModelStateErrorViewModel
	{
		public string FieldName { get; set; }

		public IEnumerable<string> Errors { get; set; }
	}
}