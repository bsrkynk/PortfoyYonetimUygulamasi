#pragma checksum "C:\Users\hakan\source\repos\PortfoyYonetimUygulamasiEsra\PortfoyYonetimUygulamasi.MVC\Views\Login\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c306fcfe33ceaec72c309a7e4d6000b01bc01eca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Register), @"mvc.1.0.view", @"/Views/Login/Register.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c306fcfe33ceaec72c309a7e4d6000b01bc01eca", @"/Views/Login/Register.cshtml")]
    public class Views_Login_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PortfoyYonetimUygulamasi.Entity.Dtos.UserAddDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendor/bootstrap/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/userlogin.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c306fcfe33ceaec72c309a7e4d6000b01bc01eca3707", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c306fcfe33ceaec72c309a7e4d6000b01bc01eca4822", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">

<div class=""container"">
    <div class=""row justify-content-center"">
        <div class=""col-lg-5"">

            <div class=""main-panel"">
                <div class=""content-wrapper"">
                    <div class=""row"">
                        <div class=""col-md-6 grid-margin stretch-card"">
                            <div class=""card"">
                                <div class=""card-body"">
                                    <h4 class=""card-title"">Default form</h4>
                                    <p class=""card-description"">
                                        Basic form layout
                                    </p>
");
#nullable restore
#line 25 "C:\Users\hakan\source\repos\PortfoyYonetimUygulamasiEsra\PortfoyYonetimUygulamasi.MVC\Views\Login\Register.cshtml"
                                     using (Html.BeginForm("Register", "Login", FormMethod.Post))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"form-sample\">\r\n                                            <div class=\"form-group\">\r\n                                                ");
#nullable restore
#line 29 "C:\Users\hakan\source\repos\PortfoyYonetimUygulamasiEsra\PortfoyYonetimUygulamasi.MVC\Views\Login\Register.cshtml"
                                           Write(Html.LabelFor(x => x.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                ");
#nullable restore
#line 30 "C:\Users\hakan\source\repos\PortfoyYonetimUygulamasiEsra\PortfoyYonetimUygulamasi.MVC\Views\Login\Register.cshtml"
                                           Write(Html.TextBoxFor(x => x.Name, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </div>\r\n                                            <div class=\"form-group\">\r\n                                                ");
#nullable restore
#line 33 "C:\Users\hakan\source\repos\PortfoyYonetimUygulamasiEsra\PortfoyYonetimUygulamasi.MVC\Views\Login\Register.cshtml"
                                           Write(Html.LabelFor(x => x.Surname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                ");
#nullable restore
#line 34 "C:\Users\hakan\source\repos\PortfoyYonetimUygulamasiEsra\PortfoyYonetimUygulamasi.MVC\Views\Login\Register.cshtml"
                                           Write(Html.TextBoxFor(x => x.Surname, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </div>\r\n                                            <div class=\"form-group\">\r\n                                                ");
#nullable restore
#line 37 "C:\Users\hakan\source\repos\PortfoyYonetimUygulamasiEsra\PortfoyYonetimUygulamasi.MVC\Views\Login\Register.cshtml"
                                           Write(Html.LabelFor(x => x.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                ");
#nullable restore
#line 38 "C:\Users\hakan\source\repos\PortfoyYonetimUygulamasiEsra\PortfoyYonetimUygulamasi.MVC\Views\Login\Register.cshtml"
                                           Write(Html.TextBoxFor(x => x.UserName, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </div>\r\n                                            <div class=\"form-group\">\r\n                                                ");
#nullable restore
#line 41 "C:\Users\hakan\source\repos\PortfoyYonetimUygulamasiEsra\PortfoyYonetimUygulamasi.MVC\Views\Login\Register.cshtml"
                                           Write(Html.LabelFor(x => x.UserPassword));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                ");
#nullable restore
#line 42 "C:\Users\hakan\source\repos\PortfoyYonetimUygulamasiEsra\PortfoyYonetimUygulamasi.MVC\Views\Login\Register.cshtml"
                                           Write(Html.TextBoxFor(x => x.UserPassword, new { @class = "form-control", placeholder = "Parola", type = "Password" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </div>\r\n                                        </div>\r\n                                        <button class=\"btn btn-warning\">Kayıt Ol</button>\r\n");
#nullable restore
#line 46 "C:\Users\hakan\source\repos\PortfoyYonetimUygulamasiEsra\PortfoyYonetimUygulamasi.MVC\Views\Login\Register.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n                            </div>\r\n                        </div>\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PortfoyYonetimUygulamasi.Entity.Dtos.UserAddDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
