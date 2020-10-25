using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Blog.WebUI.Areas.Admin.CustomHelpers
{
    [HtmlTargetElement("a", Attributes = "type")]
    public class ActionButtonTagHelper : TagHelper
    {
        public string Type { get; set; }

        private string IconName
        {
            get => Type switch
            { 
                "edit" => "pen",
                "delete" => "trash",
                "details" => "search",
                _ => "cog"    // Kullanıcın farklı bir action adı girerse, bu icon geriye teslim edilir.
            };
        }

        private string Color
        {
            get => Type switch
            {
                "edit" => "warning",
                "delete" => "danger",
                "details" => "primary",
                _ => "black", // Kullanıcı bir renk değeri girmezse, siyah renk teslim et
            };
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string template = $@"<a class='btn btn-sm shadow-sm'>
                                    <i class='fas fa-{IconName} text-{Color}'></i>
                                 </a>";

            output.Content.SetHtmlContent(template);
            return base.ProcessAsync(context, output);
        }
    }
}





