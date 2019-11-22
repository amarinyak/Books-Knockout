using System.Collections.Generic;

namespace Books.Web.ViewModels.API
{
	public class ModelStateErrorViewModel
	{
		/// <summary>
		/// Name of the edited field
		/// </summary>
		public string FieldName { get; set; }

		/// <summary>
		/// List of errors
		/// </summary>
		public IEnumerable<string> Errors { get; set; }
	}
}