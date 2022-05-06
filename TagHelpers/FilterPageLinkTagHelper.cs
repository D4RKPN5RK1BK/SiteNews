using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SiteNews.DisplayModels;

namespace SiteNews.TagHelpers
{
	public class FilterPageLinkHelper : TagHelper
	{
		private IUrlHelperFactory _urlHelperFactory;
		public FilterPageLinkHelper(IUrlHelperFactory urlHelperFactory)
		{
			_urlHelperFactory = urlHelperFactory;
		}

		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext ViewContext { get; set; }
		public PageModel PageViewModel { get; set; }
		public string PageAction { get; set; }

		[HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
		public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{

			if(PageViewModel.LastPage > 1)
			{
				IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
				output.TagName = "div";

				var tag = new TagBuilder("ul");
				tag.AddCssClass("pagination");
				tag.AddCssClass("my-3");

				for (int i = PageViewModel.CurrentPage - 4 > 1 ? PageViewModel.CurrentPage : 1; i <= (PageViewModel.CurrentPage + 4 < PageViewModel.LastPage ? PageViewModel.CurrentPage + 4 : PageViewModel.LastPage); i++)
				{
					tag.InnerHtml.AppendHtml(CreateTag(i, urlHelper));
				}

				output.Content.AppendHtml(tag);
			}

		}

		private TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
		{
			TagBuilder item = new TagBuilder("li");
			TagBuilder link = new TagBuilder("a");

			if (pageNumber == this.PageViewModel.LastPage)
			{
				item.AddCssClass("active");
			}
			else
			{
				PageUrlValues["page"] = pageNumber;
				link.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
			}
			item.AddCssClass("page-item");
			link.AddCssClass("page-link");
			link.InnerHtml.Append(pageNumber.ToString());
			item.InnerHtml.AppendHtml(link);

			return item;
		}
	}
}