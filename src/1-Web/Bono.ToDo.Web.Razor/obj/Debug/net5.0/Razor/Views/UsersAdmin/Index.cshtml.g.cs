#pragma checksum "C:\Bono.ToDo\src\1-Web\Bono.ToDo.Web.Razor\Views\UsersAdmin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0bd92450f9558646a6dc5b26336b4f46c77f84df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UsersAdmin_Index), @"mvc.1.0.view", @"/Views/UsersAdmin/Index.cshtml")]
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
#line 1 "C:\Bono.ToDo\src\1-Web\Bono.ToDo.Web.Razor\Views\_ViewImports.cshtml"
using Bono.ToDo.Web.Razor.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Bono.ToDo\src\1-Web\Bono.ToDo.Web.Razor\Views\UsersAdmin\Index.cshtml"
using Bono.ToDo.Infrastructure.Resources;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0bd92450f9558646a6dc5b26336b4f46c77f84df", @"/Views/UsersAdmin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76633552c56ff2341c680b47120422a8911e8b6a", @"/Views/_ViewImports.cshtml")]
    public class Views_UsersAdmin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bono.ToDo.Web.Razor.Models.RegisterViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Bono.ToDo\src\1-Web\Bono.ToDo.Web.Razor\Views\UsersAdmin\Index.cshtml"
  
    ViewBag.Title = Resources.UserList;

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>");
#nullable restore
#line 7 "C:\Bono.ToDo\src\1-Web\Bono.ToDo.Web.Razor\Views\UsersAdmin\Index.cshtml"
Write(Resources.UserList);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<p style=\"float: right\">\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 221, "\"", 263, 1);
#nullable restore
#line 9 "C:\Bono.ToDo\src\1-Web\Bono.ToDo.Web.Razor\Views\UsersAdmin\Index.cshtml"
WriteAttributeValue("", 228, Url.Action("Create", "UsersAdmin"), 228, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-success btn-sm\">\r\n        <i class=\"fa fa-plus\"></i> ");
#nullable restore
#line 10 "C:\Bono.ToDo\src\1-Web\Bono.ToDo.Web.Razor\Views\UsersAdmin\Index.cshtml"
                              Write(Resources.CreateNew);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </a>\r\n</p>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Bono.ToDo\src\1-Web\Bono.ToDo.Web.Razor\Views\UsersAdmin\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 24 "C:\Bono.ToDo\src\1-Web\Bono.ToDo.Web.Razor\Views\UsersAdmin\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td style=\"width: 80%;\">\r\n                    ");
#nullable restore
#line 28 "C:\Bono.ToDo\src\1-Web\Bono.ToDo.Web.Razor\Views\UsersAdmin\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td style=\"text-align: center\">\r\n                    ");
#nullable restore
#line 31 "C:\Bono.ToDo\src\1-Web\Bono.ToDo.Web.Razor\Views\UsersAdmin\Index.cshtml"
               Write(Html.ActionLink(Resources.Edit, "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 34 "C:\Bono.ToDo\src\1-Web\Bono.ToDo.Web.Razor\Views\UsersAdmin\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        $(document).ready(function() {\r\n            $(\'.table\').dataTable( {\r\n");
                WriteLiteral("            });\r\n        });\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bono.ToDo.Web.Razor.Models.RegisterViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
