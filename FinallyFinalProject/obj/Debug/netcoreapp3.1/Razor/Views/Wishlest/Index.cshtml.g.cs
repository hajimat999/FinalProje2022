#pragma checksum "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\Wishlest\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "278cfdb5265cb07c246af1206424315fa4d4cdf2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Wishlest_Index), @"mvc.1.0.view", @"/Views/Wishlest/Index.cshtml")]
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
#line 3 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\_ViewImports.cshtml"
using FinallyFinalProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"278cfdb5265cb07c246af1206424315fa4d4cdf2", @"/Views/Wishlest/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7af92ac26b2ac729f56f482646c9b1ca20201bf", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Wishlest_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "wishlest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Wishlist Thumbnail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Plus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("javascript:void(0)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\Wishlest\Index.cshtml"
  
    ViewData["Title"] = "Wishlest";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""header-title"">
    <h1>Wishlist</h1>
    <ul>
        <li><a href=""index.html"">Home</a></li>
        <li><span>/</span></li>
        <li>Wishlist</li>
    </ul>
</section>
<div class=""wishlist-area section-space-y-axis-100"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "278cfdb5265cb07c246af1206424315fa4d4cdf25964", async() => {
                WriteLiteral(@"
                    <div class=""table-content table-responsive"">
                        <table class=""table"">
                            <thead>
                                <tr>
                                    <th class=""product_remove"">remove</th>
                                    <th class=""product-thumbnail1"">Image</th>
                                    <th class=""cart-product-name"">Product</th>
                                    <th class=""product-price"">Price</th>
                                    <th class=""product-stock-status"">Stock Status</th>
                                    <th>Colors</th>
                                    <th class=""cart_btn"">add to cart</th>
                                </tr>
                            </thead>
                            <tbody>
                               
");
#nullable restore
#line 33 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\Wishlest\Index.cshtml"
                                 foreach (Wishlest item in layoutService.GetWishlest())
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <tr>\r\n                                        <td class=\"product_remove\">\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "278cfdb5265cb07c246af1206424315fa4d4cdf27603", async() => {
                    WriteLiteral("\r\n                                                <i class=\"fa-solid fa-xmark\"></i>\r\n                                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\Wishlest\Index.cshtml"
                                                                                               WriteLiteral(item.ProductId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                        </td>\r\n                                        <td class=\"product-thumbnail\">\r\n                                            <a href=\"#\">\r\n                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "278cfdb5265cb07c246af1206424315fa4d4cdf210515", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 2090, "~/BrandNewImages/", 2090, 17, true);
#nullable restore
#line 43 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\Wishlest\Index.cshtml"
AddHtmlAttributeValue("", 2107, item.Product.ProductImages.FirstOrDefault(p=>p.IsMain == true)?.Name, 2107, 69, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                            </a>\r\n                                        </td>\r\n                                        <td class=\"product-name\"><a href=\"#\">");
#nullable restore
#line 46 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\Wishlest\Index.cshtml"
                                                                        Write(item.WishlestItem);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></td>\r\n                                        <td class=\"product-price\"><span class=\"amount\">$");
#nullable restore
#line 47 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\Wishlest\Index.cshtml"
                                                                                   Write(item.Product.DiscountPrice);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></td>\r\n                                        <td class=\"product-stock-status\">\r\n");
#nullable restore
#line 49 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\Wishlest\Index.cshtml"
                                             if(item.Product.ProductColors.FirstOrDefault(p=>p.ProductId == item.ProductId).ProductCount > 0){

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                <span class=\"in-stock\">\r\n                                                  in stock</span>\r\n");
#nullable restore
#line 52 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\Wishlest\Index.cshtml"
                                            }
                                            else{

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                <span class=\"in-stock\" style=\"color:red;\">\r\n                                                    out stock\r\n                                                </span>\r\n");
#nullable restore
#line 57 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\Wishlest\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        </td>\r\n                                        <td class=\"product-name\"><a href=\"#\">\r\n");
#nullable restore
#line 60 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\Wishlest\Index.cshtml"
                                                 foreach (ProductColor productColor in item.Product.ProductColors)
                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                    <span>");
#nullable restore
#line 62 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\Wishlest\Index.cshtml"
                                                     Write(productColor.Color.ColorName);

#line default
#line hidden
#nullable disable
                WriteLiteral(", </span>\r\n");
#nullable restore
#line 63 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\Wishlest\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        </a></td>\r\n                                        <td class=\"cart_btn\">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "278cfdb5265cb07c246af1206424315fa4d4cdf215903", async() => {
                    WriteLiteral("add to cart");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\Wishlest\Index.cshtml"
                                                                                                            WriteLiteral(item.ProductId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 67 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\Wishlest\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FinallyFinalProject.Services.LayoutService layoutService { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591