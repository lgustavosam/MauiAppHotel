namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
    // Construtor da classe, responsável por inicializar os componentes da página
    public HospedagemContratada()
    {
        InitializeComponent();
    }

    // Evento acionado ao clicar no botão "Voltar"
    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Retorna para a página anterior na pilha de navegação
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            // Exibe um alerta caso ocorra um erro ao tentar voltar
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
