#pragma checksum "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Contrato\Filtrados.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06e90530a2df3923bad48160a3406fe282149019"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contrato_Filtrados), @"mvc.1.0.view", @"/Views/Contrato/Filtrados.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Contrato/Filtrados.cshtml", typeof(AspNetCore.Views_Contrato_Filtrados))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06e90530a2df3923bad48160a3406fe282149019", @"/Views/Contrato/Filtrados.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98da2a5ed6980aa45d88554554f46a5baa683ac4", @"/Views/_ViewImports.cshtml")]
    public class Views_Contrato_Filtrados : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProyectoInmobiliaria.Models.Contrato>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(58, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Contrato\Filtrados.cshtml"
  
    ViewData["Title"] = "Filtrados";

#line default
#line hidden
            BeginContext(105, 33, true);
            WriteLiteral("\r\n<h2>Filtrados</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(138, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c34ff0ccf534453086b1089b43064be0", async() => {
                BeginContext(161, 10, true);
                WriteLiteral("Create New");
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
            BeginContext(175, 760, true);
            WriteLiteral(@"
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>
                <label>ID Contrato</label>
            </th>
            <th>
                <label>Inquilino</label>
            </th>
            <th>
                <label>Direccion Inmueble</label>
            </th>
            <th>
                <label>Tipo Inmueble</label>
            </th>
            <th>
                <label>Fecha Inicio</label>
            </th>
            <th>
                <label>Fecha Cierra</label>
            </th>
            <th>
                <label>Monto</label>
            </th>
            <th>
                <label>Vigente</label>
            </th>
           
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 43 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Contrato\Filtrados.cshtml"
 foreach (var item in (IList<Contrato>)ViewBag.Filtrados) {

#line default
#line hidden
            BeginContext(996, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1045, 12, false);
#line 46 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Contrato\Filtrados.cshtml"
           Write(item.IdContr);

#line default
#line hidden
            EndContext();
            BeginContext(1057, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1114, 53, false);
#line 49 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Contrato\Filtrados.cshtml"
            Write(item.Inquilino.Nombre + " " + item.Inquilino.Apellido);

#line default
#line hidden
            EndContext();
            BeginContext(1168, 57, true);
            WriteLiteral("\r\n\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1226, 23, false);
#line 53 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Contrato\Filtrados.cshtml"
           Write(item.Inmueble.Direccion);

#line default
#line hidden
            EndContext();
            BeginContext(1249, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1305, 18, false);
#line 56 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Contrato\Filtrados.cshtml"
           Write(item.Inmueble.Tipo);

#line default
#line hidden
            EndContext();
            BeginContext(1323, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1379, 16, false);
#line 59 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Contrato\Filtrados.cshtml"
           Write(item.FechaInicio);

#line default
#line hidden
            EndContext();
            BeginContext(1395, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1451, 16, false);
#line 62 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Contrato\Filtrados.cshtml"
           Write(item.FechaCierre);

#line default
#line hidden
            EndContext();
            BeginContext(1467, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1523, 10, false);
#line 65 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Contrato\Filtrados.cshtml"
           Write(item.Monto);

#line default
#line hidden
            EndContext();
            BeginContext(1533, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1589, 12, false);
#line 68 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Contrato\Filtrados.cshtml"
           Write(item.Vigente);

#line default
#line hidden
            EndContext();
            BeginContext(1601, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1657, 56, false);
#line 71 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Contrato\Filtrados.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new {  id=item.IdContr}));

#line default
#line hidden
            EndContext();
            BeginContext(1713, 4, true);
            WriteLiteral(" |\r\n");
            EndContext();
#line 72 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Contrato\Filtrados.cshtml"
                 if (User.IsInRole("Administrador")) {
                

#line default
#line hidden
            BeginContext(1790, 60, false);
#line 73 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Contrato\Filtrados.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { id=item.IdContr }));

#line default
#line hidden
            EndContext();
#line 73 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Contrato\Filtrados.cshtml"
                                                                             
                }

#line default
#line hidden
            BeginContext(1871, 34, true);
            WriteLiteral("            </td>\r\n        </tr>\r\n");
            EndContext();
#line 77 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Contrato\Filtrados.cshtml"
}

#line default
#line hidden
            BeginContext(1908, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProyectoInmobiliaria.Models.Contrato>> Html { get; private set; }
    }
}
#pragma warning restore 1591
