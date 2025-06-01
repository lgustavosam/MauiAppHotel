using MauiAppHotel.Models;

namespace MauiAppHotel
{
    public partial class App : Application
    {
        // Lista de quartos disponíveis na aplicação
        public List<Quarto> lista_quartos = new List<Quarto>()
        {
            new Quarto()
            {
                Descricao = "Suite Super Luxo",
                ValorDiariaAdulto = 110.00,
                ValorDiariaCrianca = 55.00
            },
            new Quarto()
            {
                Descricao = "Suite Luxo",
                ValorDiariaAdulto = 80.00,
                ValorDiariaCrianca = 40.00
            },
            new Quarto()
            {
                Descricao = "Suite Single",
                ValorDiariaAdulto = 50.00,
                ValorDiariaCrianca = 25.00
            },
            new Quarto()
            {
                Descricao = "Suite Crise",
                ValorDiariaAdulto = 25.00,
                ValorDiariaCrianca = 12.50
            }
        };

        // Construtor da classe principal do aplicativo
        public App()
        {
            InitializeComponent();

            // Define a página inicial da aplicação
            MainPage = new NavigationPage(new Views.ContratacaoHospedagem());
        }

        // Configuração da janela principal da aplicação
        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            // Define as dimensões da janela ao iniciar o aplicativo
            window.Width = 400;
            window.Height = 800;

            return window;
        }
    }
}