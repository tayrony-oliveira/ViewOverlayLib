using ViewOverlayLib.Interfaces;
using Xamarin.Forms;

namespace ViewOverlayLib.Classes
{
    public sealed class CardInteractionOverlay : BoxView, ICardInteractionOverlay
    {
        public event EventHandler<TappedEventArgs>? CardTapped;

        // Propriedade Bindable para controlar se o BoxView está bloqueando ou não
        public static readonly BindableProperty IsBlockedProperty = BindableProperty.Create(
            nameof(IsBlocked),
            typeof(bool),
            typeof(CardInteractionOverlay),
            true,
            BindingMode.TwoWay,
            propertyChanged: OnIsBlockedChanged);

        // Propriedade que determina se o BoxView está bloqueando
        public bool IsBlocked
        {
            get => (bool)GetValue(IsBlockedProperty);
            set => SetValue(IsBlockedProperty, value);
        }

        public CardInteractionOverlay()
        {
            // Configurações do BoxView
            BackgroundColor = Color.Transparent;
            HorizontalOptions = LayoutOptions.Fill;
            VerticalOptions = LayoutOptions.Fill;
            InputTransparent = false;  // Não deixa os toques passarem

            // Adicionando o GestureRecognizer para capturar toques
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += OnCardTapped;
            //tapGesture.Tapped += OnCardTapped;  // Evento disparado ao tocar
            GestureRecognizers.Add(tapGesture);
        }

        // Método chamado quando o valor de IsBlocked muda
        private static void OnIsBlockedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CardInteractionOverlay)bindable;
            bool isBlocked = (bool)newValue;

            // Controla a visibilidade com base em IsBlocked
            control.IsVisible = isBlocked;
        }

        private void OnCardTapped(object? sender, EventArgs e)
        {
            // Invoca o evento CardTapped, usando "this" como sender, pois o BoxView foi clicado
            CardTapped?.Invoke(this, (TappedEventArgs)e);
        }
    }
}