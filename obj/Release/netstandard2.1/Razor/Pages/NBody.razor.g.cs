#pragma checksum "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\Pages\NBody.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7dbeaae7093a3d2b442295a721b297cdcc57728b"
// <auto-generated/>
#pragma warning disable 1591
namespace MyWebsite.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\_Imports.razor"
using MyWebsite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\_Imports.razor"
using MyWebsite.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/nbody")]
    public partial class NBody : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<div class=\"webgl-content\" style=\"margin-left: auto; margin-right: auto;\"></div>\r\n<div id=\"unityContainer\" style=\"margin-left: auto; margin-right: auto;\"></div>");
        }
        #pragma warning restore 1998
#nullable restore
#line 7 "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\Pages\NBody.razor"
       
    public object unityInstance = 0;

    public void Start()
    {
        try
        {
            unityInstance = JSRuntime.InvokeAsync<object>("UnityLoader.instantiate", "unityContainer", "css/Games/Build/WebGL.json");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }

    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        if (firstRender) Start();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
