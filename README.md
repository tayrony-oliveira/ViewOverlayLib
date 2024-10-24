
# ViewOverlayLib - Flexible Overlays for UI Interaction

**ViewOverlayLib** é uma biblioteca leve e flexível que permite adicionar e gerenciar sobreposições de interface de usuário (UI) em projetos .NET MAUI. Ela facilita o controle de interações em cards ou outros elementos visuais, com componentes personalizáveis e fáceis de integrar.

## Funcionalidades

- Adicione sobreposições interativas em elementos da interface de usuário.
- Bloqueie ou permita interações com base no estado da aplicação.
- Integração fácil com `BindableProperty` e eventos.
- Personalizável e pronto para usar em projetos .NET MAUI.

## Instalação

Você pode instalar o pacote **ViewOverlayLib** via NuGet Package Manager ou .NET CLI.

### NuGet Package Manager:

```bash
Install-Package ViewOverlayLib
```

### .NET CLI:

```bash
dotnet add package ViewOverlayLib
```

## Como Usar

Aqui está um exemplo básico de como usar o componente **CardInteractionOverlay** em um projeto .NET MAUI.

### Exemplo no XAML

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:overlay="clr-namespace:ViewOverlayLib"
             x:Class="YourProject.MainPage">

    <Grid>
        <!-- Card Content -->
        <Frame CornerRadius="10" Padding="10" BackgroundColor="LightGray" HasShadow="True">
            <StackLayout>
                <Label Text="Título do Card" FontAttributes="Bold" />
                <Entry Placeholder="Digite algo aqui" />
            </StackLayout>
        </Frame>

        <!-- CardInteractionOverlay Sobrepondo o Card -->
        <overlay:CardInteractionOverlay IsBlocked="{Binding IsBlocked}" CardTapped="OnCardTapped" />
    </Grid>

</ContentPage>
```

### Exemplo no Code-Behind (MainPage.xaml.cs)

```csharp
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();  // Exemplo de BindingContext
    }

    // Evento chamado quando o CardInteractionOverlay é clicado
    private void OnCardTapped(object sender, TappedEventArgs e)
    {
        DisplayAlert("Card Tapped", "Você clicou no card!", "OK");
    }
}
```

### Exemplo do ViewModel

```csharp
public class MainViewModel : INotifyPropertyChanged
{
    private bool _isBlocked = true;

    public bool IsBlocked
    {
        get => _isBlocked;
        set
        {
            _isBlocked = value;
            OnPropertyChanged(nameof(IsBlocked));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```

## Contribuições

Se você quiser contribuir com o **ViewOverlayLib**, fique à vontade para fazer um fork deste repositório e enviar pull requests. Toda contribuição é bem-vinda!

1. Faça o fork do repositório.
2. Crie um branch para a sua feature: `git checkout -b minha-feature`.
3. Envie as alterações: `git commit -m 'Adiciona nova feature'`.
4. Faça o push do branch: `git push origin minha-feature`.
5. Abra um pull request.

## Licença

Este projeto é licenciado sob a [MIT License](LICENSE).
