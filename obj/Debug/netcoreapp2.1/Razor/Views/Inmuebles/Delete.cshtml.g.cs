#pragma checksum "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "997253827f604f0234c2b3cc4c95e0daa04903c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Inmuebles_Delete), @"mvc.1.0.view", @"/Views/Inmuebles/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Inmuebles/Delete.cshtml", typeof(AspNetCore.Views_Inmuebles_Delete))]
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
#line 1 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\_ViewImports.cshtml"
using ProyectoInmobiliaria.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"997253827f604f0234c2b3cc4c95e0daa04903c1", @"/Views/Inmuebles/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98da2a5ed6980aa45d88554554f46a5baa683ac4", @"/Views/_ViewImports.cshtml")]
    public class Views_Inmuebles_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProyectoInmobiliaria.Models.Inmueble>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(45, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(89, 177, true);
            WriteLiteral("\r\n<h2>Eliminar</h2>\r\n\r\n<h3>Esta seguro que quiere borrar est inmueble?</h3>\r\n<div>\r\n    <h4>Inmueble</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(267, 41, false);
#line 15 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IdInm));

#line default
#line hidden
            EndContext();
            BeginContext(308, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(352, 37, false);
#line 18 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdInm));

#line default
#line hidden
            EndContext();
            BeginContext(389, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(433, 42, false);
#line 21 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IdProp));

#line default
#line hidden
            EndContext();
            BeginContext(475, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(519, 38, false);
#line 24 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdProp));

#line default
#line hidden
            EndContext();
            BeginContext(557, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(601, 45, false);
#line 27 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Direccion));

#line default
#line hidden
            EndContext();
            BeginContext(646, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(690, 41, false);
#line 30 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Direccion));

#line default
#line hidden
            EndContext();
            BeginContext(731, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(775, 40, false);
#line 33 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Tipo));

#line default
#line hidden
            EndContext();
            BeginContext(815, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(859, 36, false);
#line 36 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Tipo));

#line default
#line hidden
            EndContext();
            BeginContext(895, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(939, 39, false);
#line 39 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Uso));

#line default
#line hidden
            EndContext();
            BeginContext(978, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1022, 35, false);
#line 42 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Uso));

#line default
#line hidden
            EndContext();
            BeginContext(1057, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1101, 49, false);
#line 45 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CantAmbientes));

#line default
#line hidden
            EndContext();
            BeginContext(1150, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1194, 45, false);
#line 48 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CantAmbientes));

#line default
#line hidden
            EndContext();
            BeginContext(1239, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1283, 41, false);
#line 51 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Costo));

#line default
#line hidden
            EndContext();
            BeginContext(1324, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1368, 37, false);
#line 54 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Costo));

#line default
#line hidden
            EndContext();
            BeginContext(1405, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1449, 46, false);
#line 57 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Disponible));

#line default
#line hidden
            EndContext();
            BeginContext(1495, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1539, 42, false);
#line 60 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Inmuebles\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Disponible));

#line default
#line hidden
            EndContext();
            BeginContext(1581, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(1619, 161, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a9fe43340a02413088541fdfdc7e8d3c", async() => {
                BeginContext(1645, 84, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n        ");
                EndContext();
                BeginContext(1729, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f75d8237789e45a5a59c31da37c56dc1", async() => {
                    BeginContext(1751, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1767, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1780, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProyectoInmobiliaria.Models.Inmueble> Html { get; private set; }
    }
}
#pragma warning restore 1591
