using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorServerTestProject.Pages;

public partial class Index
{
    private byte[]? _bytes;
    private JSException? _exception;

    private IJSObjectReference? _jsObjectReference;

    [Inject]
    private IJSRuntime? JSRuntime { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && JSRuntime != null)
        {
            _jsObjectReference = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./pages/index.razor.js");

            try
            {
                _bytes = await _jsObjectReference.InvokeAsync<byte[]>("readByteArray");
            }
            catch (JSException ex)
            {
                _exception = ex;
            }

            StateHasChanged();
        }
    }
}