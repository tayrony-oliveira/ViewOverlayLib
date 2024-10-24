using Xamarin.Forms;

namespace ViewOverlayLib.Interfaces
{
    public interface ICardInteractionOverlay
    {
        bool IsBlocked { get; set; }

        event EventHandler<TappedEventArgs>? CardTapped;
    }
}