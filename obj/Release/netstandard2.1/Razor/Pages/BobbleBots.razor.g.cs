#pragma checksum "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\Pages\BobbleBots.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76e3da0ce1b70f2b3c762afe9d18350a07455443"
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
#nullable restore
#line 2 "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\Pages\BobbleBots.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\Pages\BobbleBots.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\Pages\BobbleBots.razor"
using Microsoft.Scripting.Hosting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\Pages\BobbleBots.razor"
using IronPython.Hosting;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/bobblebots")]
    public partial class BobbleBots : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<div id=""unity-container"" class=""unity-desktop"">
    <canvas id=""unity-canvas"" style=""box-shadow: 0 0 10px black;""></canvas>
    <div id=""unity-loading-bar"">
        <div id=""unity-logo""></div>
        <div id=""unity-progress-bar-empty"">
            <div id=""unity-progress-bar-full""></div>
        </div>
    </div>
    <div id=""unity-warning""></div>
    <div id=""unity-footer"">
        <div id=""unity-webgl-logo""></div>
        <div id=""unity-fullscreen-button""></div>
        <div id=""unity-build-title""></div>
    </div>
</div>");
        }
        #pragma warning restore 1998
#nullable restore
#line 27 "C:\Users\brady\Documents\GitHub\bradylangdale.github.io\Pages\BobbleBots.razor"
  
    [System.Serializable]
    public struct Float2
    {
        public float x;
        public float y;
    }

    [System.Serializable]
    public struct RadarData
    {
        public string name;
        public Float2 vec;
        public float mag;
        public float angle;

        public dynamic this[int key]
        {
            get => GetValue(key);
            set => SetValue(key, value);
        }

        private dynamic GetValue(int key)
        {
            switch (key)
            {
                case 0:
                    return name;
                case 1:
                    return vec;
                case 2:
                    return mag;
                case 3:
                    return angle;
            }

            return -1;
        }

        private void SetValue(int key, dynamic value)
        {
            switch (key)
            {
                case 0:
                    name = value;
                    return;
                case 1:
                    vec = value;
                    return;
                case 2:
                    mag = value;
                    return;
                case 3:
                    angle = value;
                    return;
            }
        }
    }

    [System.Serializable]
    public struct BotScope
    {
        public string name;
        public Float2 center;
        public float mag;
        public float ang;
        public float throttleValue;
        public float rotateValue;
        public bool canShoot;
        public bool shoot;
        public List<string> output;
        public List<RadarData> radar;
    }

    public object unityInstance = 0;
    ScriptEngine engine1;
    dynamic scope1;
    dynamic botScript1;

    ScriptEngine engine2;
    dynamic scope2;
    dynamic botScript2;

    public void Start()
    {
        try
        {
            JSRuntime.InvokeVoidAsync("cleanup");
            unityInstance = JSRuntime.InvokeAsync<object>("launchBobbleBots");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }

    protected override async Task OnInitializedAsync()
    {
        var lDotNetReference = DotNetObjectReference.Create(this);
        JSRuntime.InvokeVoidAsync("GLOBAL.SetDotnetReference", lDotNetReference);
        var response = await Http.GetAsync("Scripts/test_bot.py");
        string script = await response.Content.ReadAsStringAsync();

        Console.WriteLine(script);

        setupPython(script);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        if (firstRender) Start();
    }

    private void setupPython(string script)
    {
        engine1 = Python.CreateEngine();
        scope1 = engine1.CreateScope();
        engine1.CreateScriptSourceFromString(script).Execute(scope1);

        engine2 = Python.CreateEngine();
        scope2 = engine2.CreateScope();
        engine2.CreateScriptSourceFromString(script).Execute(scope2);

        InitializeVariables();

        botScript1 = scope1.Bot();
        botScript2 = scope2.Bot();
    }

    private void InitializeVariables()
    {
        Float2 center;
        center.x = 0;
        center.y = 0;
        scope1.centerVector = center;
        scope1.centerDistance = 0;
        scope1.centerDirection = 0;
        scope1.throttleValue = 0;
        scope1.rotateValue = 0;
        scope1.canShoot = true;
        scope1.shoot = false;
        scope1.output = new List<string>();
        scope1.radar = new List<RadarData>();

        scope2.centerVector = center;
        scope2.centerDistance = 0.0f;
        scope2.centerDirection = 0.0f;
        scope2.throttleValue = 0.0f;
        scope2.rotateValue = 0.0f;
        scope2.canShoot = true;
        scope2.shoot = false;
        scope2.output = new List<string>();
        scope2.radar = new List<RadarData>();
        scope2.busy = false;
    }

    private BotScope UpdateBotScope(BotScope bot)
    {
        if (bot.name == "Bot1")
        {
            scope1.centerVector = bot.center;
            scope1.centerDistance = bot.mag;
            scope1.centerDirection = bot.ang;
            scope1.canShoot = bot.canShoot;
            scope1.shoot = bot.shoot;
            scope1.output = new List<string>();
            scope1.radar = bot.radar;

            try
            {
                botScript1.update();
            }
            catch (Exception e) { }

            bot.throttleValue = (float)scope1.throttleValue * 10;
            bot.rotateValue = (float)scope1.rotateValue * 5;
            bot.shoot = scope1.shoot;
            bot.output = scope1.output;
        }
        else
        if (bot.name == "Bot2")
        {
            scope2.centerVector = bot.center;
            scope2.centerDistance = bot.mag;
            scope2.centerDirection = bot.ang;
            scope2.canShoot = bot.canShoot;
            scope2.shoot = bot.shoot;
            scope2.output = new List<string>();
            scope2.radar = bot.radar;

            try
            {
                botScript2.update();
            }
            catch (Exception e) { }

            bot.throttleValue = (float)scope2.throttleValue * 10;
            bot.rotateValue = (float)scope2.rotateValue * 5;
            bot.shoot = scope2.shoot;
            bot.output = scope2.output;

            if (scope2.output.Count > 0) Console.WriteLine(scope2.output[0]);
        }

        return bot;
    }

    [JSInvokable("ReceiveMessageFromUnity")]
    public string ReceiveMessageFromUnity(string txt)
    {
        BotScope bot = JsonConvert.DeserializeObject<BotScope>(txt);
        return JsonConvert.SerializeObject(UpdateBotScope(bot));
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
