﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.ViewModels;

namespace WebStore.TagHelpers
{
    public class Paging : TagHelper
    {
        //private readonly IUrlHelperFactory _UrlHelperFactory;

        [ViewContext, HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new(StringComparer.OrdinalIgnoreCase);

        //public Paging(IUrlHelperFactory UrlHelperFactory) => _UrlHelperFactory = UrlHelperFactory;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");

            //var url_helper = _UrlHelperFactory.GetUrlHelper(ViewContext);
            for (int i = 1; i <= PageViewModel.TotalPages; i++)
                ul.InnerHtml.AppendHtml(CreateElement(i/*, url_helper*/));

            output.Content.AppendHtml(ul);
        }

        private TagBuilder CreateElement(int PageNumber/*, IUrlHelper Url*/)
        {
            var li = new TagBuilder("li");
            var a = new TagBuilder("a");

            if (PageNumber == PageViewModel.Page)
            {
                li.AddCssClass("active");
                a.MergeAttribute("data-page", PageNumber.ToString());
            }
            else
            {
                PageUrlValues["page"] = PageNumber;
                //a.Attributes["href"] = Url.Action(PageAction, PageUrlValues);
                a.Attributes["href"] = "#";
                foreach (var (key, value) in PageUrlValues.Where(v => v.Value is { }))
                    a.MergeAttribute($"data-{key}", value.ToString());
            }

            a.InnerHtml.AppendHtml(PageNumber.ToString());
            li.InnerHtml.AppendHtml(a);

            return li;
        }
    }
}