using Microsoft.AspNetCore.Mvc.Rendering;
using SiteNews.sakila;

namespace SiteNews.ViewModels
{
	public class ConfirmViewModel
	{
		public ConfirmViewModel() {
			List<KeyValuePair<int, string>> states = new List<KeyValuePair<int, string>>() {
				new KeyValuePair<int, string>(0, "Принято"),
				new KeyValuePair<int, string>(1, "Рассматривается"),
				new KeyValuePair<int, string>(2, "Отменено"),
			};
			States = new SelectList(states, "Key", "Value", states[1]);
		}
		public News News { get; set; }
		public SelectList States {get; set;}
	}
}