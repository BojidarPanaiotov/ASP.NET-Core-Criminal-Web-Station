#pragma checksum "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b10882f6019d1dd7f0805b75ceb51e6bda66a853"
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
#nullable restore
#line 7 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\_ViewImports.cshtml"
using Criminal_Web_Station.Services.Implementations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\_ViewImports.cshtml"
using Criminal_Web_Station.Services.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\_ViewImports.cshtml"
using Criminal_Web_Station.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\_ViewImports.cshtml"
using Criminal_Web_Station.Areas.Admin;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b10882f6019d1dd7f0805b75ceb51e6bda66a853", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3f6b5cfe29a244079dbaa380ebee3c88443adfb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeServiceModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Item", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    .img-carousel {
        width: 100px;
        height: 460px;
        object-fit: cover;
    }
</style>

<h1 class=""text-center mb-5"">Welcome to Criminal Station</h1>
<div id=""carouselExampleIndicators"" class=""carousel slide border border-dark"" data-ride=""carousel"">
    <ol class=""carousel-indicators"">
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""2""></li>
    </ol>
    <div class=""carousel-inner"">
");
#nullable restore
#line 24 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
         if (Model.TopThreeItems.Count() >= 3 && Model != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
             for (int i = 0; i < 3; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div");
            BeginWriteAttribute("class", " class=\"", 884, "\"", 925, 2);
            WriteAttributeValue("", 892, "carousel-item", 892, 13, true);
#nullable restore
#line 28 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 905, i==0?"active":"", 906, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"carousel-caption d-none d-md-block align-bottom overflow-auto\">\r\n                        <div>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b10882f6019d1dd7f0805b75ceb51e6bda66a8538269", async() => {
                WriteLiteral("View More");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
                                                         WriteLiteral(Model.TopThreeItems[i].Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                    <img class=\"d-block w-100 img-carousel\"");
            BeginWriteAttribute("src", " src=\"", 1331, "\"", 1371, 1);
#nullable restore
#line 34 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
WriteAttributeValue("", 1337, Model.TopThreeItems[i].MainImgUrl, 1337, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"First slide\">\r\n                </div>\r\n");
#nullable restore
#line 36 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1>No items</h1>\r\n");
#nullable restore
#line 41 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
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
<div class=""jumbotron mt-4"" id=""statistics"">
    <div class=""row"">
        <h2 class=""col-md-6 text-center"">Total Users ");
#nullable restore
#line 54 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
                                                Write(Model.TotalUsers);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n        <h2 class=\"col-md-6 text-center\">Total Adds ");
#nullable restore
#line 55 "C:\Users\User\Desktop\SoftUni_Project\ASP.NET-CORE-Criminal-Web-Station\Criminal-Web-Station\Views\Home\Index.cshtml"
                                               Write(Model.TotalAdds);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<Account> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeServiceModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
