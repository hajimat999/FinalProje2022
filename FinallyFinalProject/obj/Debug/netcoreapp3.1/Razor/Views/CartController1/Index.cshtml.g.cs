#pragma checksum "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\CartController1\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c05958eff41975e8767d7398a027911a2ee5e86"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CartController1_Index), @"mvc.1.0.view", @"/Views/CartController1/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c05958eff41975e8767d7398a027911a2ee5e86", @"/Views/CartController1/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7af92ac26b2ac729f56f482646c9b1ca20201bf", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_CartController1_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Cart Thumbnail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\CartController1\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""header-title"">
    <h1>Cart</h1>
    <ul>
        <li><a href=""index.html"">Cart</a></li>
        <li><span></span></li>
        <li></li>
    </ul>

</section>
<div class=""container"">
    <div class=""row"">
        <div class=""col-md-12 cart"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c05958eff41975e8767d7398a027911a2ee5e865302", async() => {
                WriteLiteral(@"
                <table class=""table"">
                    <thead>
                        <tr>
                            <th class=""product_remove"">remove</th>
                            <th class=""product-thumbnail1"">images</th>
                            <th class=""cart-product-name"">Product</th>
                            <th class=""product-price"">Price</th>
                            <th class=""product-quantity"">Quantity</th>
                            <th class=""product-subtotal"">Color</th>
                        </tr>
                    </thead>
                    <tbody>
                       


");
#nullable restore
#line 34 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\CartController1\Index.cshtml"
                         if (layoutService.Getbasket() != null)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\CartController1\Index.cshtml"
                             foreach (BasketItem basketItem in layoutService.Getbasket().BasketItems)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <tr>\r\n                                    <td class=\"product_remove\">\r\n                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c05958eff41975e8767d7398a027911a2ee5e867037", async() => {
                    WriteLiteral("\r\n                                            <i class=\"fa-solid fa-xmark\"></i>\r\n                                        ");
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
#line 40 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\CartController1\Index.cshtml"
                                                                                         WriteLiteral(basketItem.Id);

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
                WriteLiteral("\r\n                                    </td>\r\n                                    <td class=\"product-thumbnail\">\r\n                                        <a href=\"#\">\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1c05958eff41975e8767d7398a027911a2ee5e869925", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 1838, "~/BrandNewImages/", 1838, 17, true);
#nullable restore
#line 46 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\CartController1\Index.cshtml"
AddHtmlAttributeValue("", 1855, basketItem.Product.ProductImages.FirstOrDefault(p=>p.IsMain==true)?.Name, 1855, 73, false);

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
                WriteLiteral("\r\n                                        </a>\r\n                                    </td>\r\n                                    <td class=\"product-name\"><a href=\"#\">");
#nullable restore
#line 49 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\CartController1\Index.cshtml"
                                                                    Write(basketItem.Product.Model);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></td>\r\n                                    <td class=\"product-price\"><span class=\"amount\">$");
#nullable restore
#line 50 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\CartController1\Index.cshtml"
                                                                               Write(basketItem.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></td>\r\n                                    <td class=\"quantity\">\r\n                                        ");
#nullable restore
#line 52 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\CartController1\Index.cshtml"
                                   Write(basketItem.Quantity);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        \r\n                                    </td>\r\n                                    <td class=\"product-subtotal\"><span class=\"amount\">");
#nullable restore
#line 55 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\CartController1\Index.cshtml"
                                                                                 Write(basketItem.Color.ColorName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></td>\r\n                               </tr>\r\n");
#nullable restore
#line 57 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\CartController1\Index.cshtml"

                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\CartController1\Index.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </tbody>\r\n                </table>\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-5 ml-auto\">\r\n                        <div class=\"cart-page-total\">\r\n                            <h2>Cart totals</h2>\r\n");
#nullable restore
#line 66 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\CartController1\Index.cshtml"
                              
                                int count = 0;
                            

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <ul>\r\n                                <li>Subtotal <span>$");
#nullable restore
#line 70 "C:\Users\Baku\Desktop\ASP.NETCoreTask\FinallyFinalProject\FinallyFinalProject\Views\CartController1\Index.cshtml"
                                                Write(layoutService.Getbasket() == null ? count : layoutService.Getbasket().TotalPrice);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></li>\r\n                                \r\n                            </ul>\r\n                            <a href=\"#\">Proceed to checkout</a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
