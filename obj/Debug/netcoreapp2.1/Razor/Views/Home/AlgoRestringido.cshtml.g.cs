#pragma checksum "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Home\AlgoRestringido.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "658f0077f9e145668e792e6c54784f20b5f6123d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AlgoRestringido), @"mvc.1.0.view", @"/Views/Home/AlgoRestringido.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/AlgoRestringido.cshtml", typeof(AspNetCore.Views_Home_AlgoRestringido))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"658f0077f9e145668e792e6c54784f20b5f6123d", @"/Views/Home/AlgoRestringido.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98da2a5ed6980aa45d88554554f46a5baa683ac4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AlgoRestringido : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Home\AlgoRestringido.cshtml"
  
    ViewData["Title"] = "AlgoRestringido";

#line default
#line hidden
            BeginContext(53, 17, true);
            WriteLiteral("\r\n<h4>\r\n    <b>\r\n");
            EndContext();
#line 8 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Home\AlgoRestringido.cshtml"
         foreach (var u in User.Claims)
        {
            

#line default
#line hidden
            BeginContext(135, 7, false);
#line 10 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Home\AlgoRestringido.cshtml"
       Write(u.Value);

#line default
#line hidden
            EndContext();
            BeginContext(142, 6, true);
            WriteLiteral("<br />");
            EndContext();
#line 10 "C:\Users\educacion 3.0\source\repos\Proyecto-Inmobiliaria\Views\Home\AlgoRestringido.cshtml"
                          }

#line default
#line hidden
            BeginContext(151, 498, true);
            WriteLiteral(@"    </b>
</h4>
<li><a class=""nav-link"" href=""../Contrato/Index"">Administrar Contratos</a></li>
<li><a class=""nav-link"" href=""../Inmuebles/Index"">Administrar Inmuebles</a></li>
<li><a class=""nav-link"" href=""../Inquilinos/Index"">Administrar Inquilinos</a></li>
<li><a class=""nav-link"" href=""../Pago/Index"">Administrar Pagos</a></li>
<li><a class=""nav-link"" href=""../Propietarios/Index"">Administrar Propietarios</a></li>
<li><a class=""nav-link"" href=""../Usuario/Logout"">Cerrar Sesion</a></li>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
