#pragma checksum "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Pago\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fda8da5c1ccdc4c10a4ce5b03c9f3db2e5c91e9f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pago_Delete), @"mvc.1.0.view", @"/Views/Pago/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Pago/Delete.cshtml", typeof(AspNetCore.Views_Pago_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fda8da5c1ccdc4c10a4ce5b03c9f3db2e5c91e9f", @"/Views/Pago/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98da2a5ed6980aa45d88554554f46a5baa683ac4", @"/Views/_ViewImports.cshtml")]
    public class Views_Pago_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProyectoInmobiliaria.Models.Pago>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Pago\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(85, 235, true);
            WriteLiteral("\r\n<h2>Borrar</h2>\r\n\r\n<h3>Esta Seguro Que Quiere Eliminar este Pagos?</h3>\r\n<div>\r\n    <h4>Pago</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n           <label>ID Pago</label>\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(321, 38, false);
#line 18 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Pago\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdPago));

#line default
#line hidden
            EndContext();
            BeginContext(359, 114, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n           <label>Numero De Pago</label>\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(474, 39, false);
#line 24 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Pago\Delete.cshtml"
       Write(Html.DisplayFor(model => model.NumPago));

#line default
#line hidden
            EndContext();
            BeginContext(513, 112, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            <label>ID Contrato</label>\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(626, 39, false);
#line 30 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Pago\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdContr));

#line default
#line hidden
            EndContext();
            BeginContext(665, 113, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n           <label>Fecha De Pago</label>\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(779, 41, false);
#line 36 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Pago\Delete.cshtml"
       Write(Html.DisplayFor(model => model.FechaPago));

#line default
#line hidden
            EndContext();
            BeginContext(820, 107, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n           <label>Importe</label>\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(928, 39, false);
#line 42 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Pago\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Importe));

#line default
#line hidden
            EndContext();
            BeginContext(967, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(1005, 174, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "306888151d234afb9df5d8adf5d2ca8a", async() => {
                BeginContext(1031, 86, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Eliminar\" class=\"btn btn-default\" /> |\r\n        ");
                EndContext();
                BeginContext(1118, 47, false);
#line 48 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Pago\Delete.cshtml"
   Write(Html.ActionLink("Volver", "Index", "Inmuebles"));

#line default
#line hidden
                EndContext();
                BeginContext(1165, 7, true);
                WriteLiteral(";\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1179, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProyectoInmobiliaria.Models.Pago> Html { get; private set; }
    }
}
#pragma warning restore 1591
