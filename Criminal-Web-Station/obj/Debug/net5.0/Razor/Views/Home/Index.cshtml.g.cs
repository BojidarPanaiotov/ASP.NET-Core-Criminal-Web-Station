#pragma checksum "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33b2dda78f1334cbfb8fcf7c2a95618a70b4bcf5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\_ViewImports.cshtml"
using Criminal_Web_Station;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\_ViewImports.cshtml"
using Criminal_Web_Station.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\_ViewImports.cshtml"
using Criminal_Web_Station.Data.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\_ViewImports.cshtml"
using Criminal_Web_Station.Models.Item;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\_ViewImports.cshtml"
using Criminal_Web_Station.Services.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33b2dda78f1334cbfb8fcf7c2a95618a70b4bcf5", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"607345eb747c52d1f655cc880af21a25159152da", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<HomeItemModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome</h1>
    <p>Learn about <a href=""https://docs.microsoft.com/aspnet/core"">building Web apps with ASP.NET Core</a>.</p>
</div>
<style>
    img {
        width: 100px;
        height: 460px;
        object-fit: cover;
    }
</style>
<div id=""carouselExampleIndicators"" class=""carousel slide border border-dark"" data-ride=""carousel"">
    <ol class=""carousel-indicators"">
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""2""></li>
    </ol>
    <div class=""carousel-inner"">
");
#nullable restore
#line 25 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
         if (Model.Count != 0 && Model != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
             for (int i = 0; i < 3; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div");
            BeginWriteAttribute("class", " class=\"", 948, "\"", 989, 2);
            WriteAttributeValue("", 956, "carousel-item", 956, 13, true);
#nullable restore
#line 29 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 969, i==0?"active":"", 970, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"carousel-caption d-none d-md-block align-bottom\">\r\n                        <div>\r\n                            <h5 class=\"text-dark container-fluid\">");
#nullable restore
#line 32 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
                                                             Write(Model[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            <p class=\"text-dark \">$");
#nullable restore
#line 33 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
                                              Write(Model[i].Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <button class=\"btn-primary\">View More</button>\r\n                        </div>\r\n                    </div>\r\n                    <img class=\"d-block w-100\"");
            BeginWriteAttribute("src", " src=\"", 1448, "\"", 1474, 1);
#nullable restore
#line 37 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
WriteAttributeValue("", 1454, Model[i].MainImgUrl, 1454, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"First slide\">\r\n                </div>\r\n");
#nullable restore
#line 39 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
    <a class=""carousel-control-prev text-danger"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Previous</span>
    </a>
    <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Next</span>
    </a>
</div>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<HomeItemModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
