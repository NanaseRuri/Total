using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.Infrastructure.HelperMethod
{
    public static class CustomHelper
    {
        public static MvcHtmlString ListItem(this HtmlHelper helper, IEnumerable<string> items)
        {
            TagBuilder tag=new TagBuilder("ul");            
            foreach (var item in items)
            {
                TagBuilder itemAdd = new TagBuilder("li");
                itemAdd.SetInnerText(item);
                tag.InnerHtml += itemAdd.ToString();
            }
            return new MvcHtmlString(tag.ToString());
        }

        //public static string DisplayParagraph(this HtmlHelper helper, string text)
        //{
        //    string result = $"The message is <p>{text}</p>";
        //    return result;
        //}
        //public static MvcHtmlString DisplayParagraph(this HtmlHelper helper, string text)
        //{
        //    string result = $"The message is <p>{text}</p>";
        //    return new MvcHtmlString(result);
        //}
        public static MvcHtmlString DisplayParagraph(this HtmlHelper helper, string text)
        {
            string encodedText = helper.Encode(text);
            string result = $"The message is <p>{encodedText}</p>";
            return new MvcHtmlString(result);
        }
    }
}