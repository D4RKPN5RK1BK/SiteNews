using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SiteNews.DisplayModels;

namespace SiteNews.TagHelpers
{
	public class PageLinkTagHelper : TagHelper
	{
		protected IUrlHelperFactory _urlHelperFactory;
		public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
		{
			_urlHelperFactory = urlHelperFactory;
		}

		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext ViewContext { get; set; }
		public PageModel PageViewModel { get; set; }
		public string PageAction { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

			output.TagName = "div";
			
			TagBuilder tag = new TagBuilder("ul");
			if (PageViewModel.LastPage > 1)
			{
				tag.AddCssClass("pagination");

				TagBuilder currentItem = CreateTag(PageViewModel.CurrentPage, urlHelper);

				if (PageViewModel.HavePreviousPage)
				{
					TagBuilder prevItem = CreateTag(PageViewModel.CurrentPage - 1, urlHelper);
					tag.InnerHtml.AppendHtml(prevItem);
				}

				tag.InnerHtml.AppendHtml(currentItem);

				if (PageViewModel.HaveNextPage)
				{
					TagBuilder nextItem = CreateTag(PageViewModel.CurrentPage + 1, urlHelper);
					tag.InnerHtml.AppendHtml(nextItem);
				}

			}


			output.Content.AppendHtml(tag);
		}

		TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
		{
			TagBuilder item = new TagBuilder("li");
			TagBuilder link = new TagBuilder("a");
			if (pageNumber == this.PageViewModel.CurrentPage)
			{
				item.AddCssClass("active");
			}
			else
			{
				link.Attributes["href"] = urlHelper.Action(PageAction, new { page = pageNumber });
			}

			item.AddCssClass("page-item");
			link.AddCssClass("page-link");

			link.InnerHtml.Append(pageNumber.ToString());
			item.InnerHtml.AppendHtml(link);

			return item;
		}

	}
}