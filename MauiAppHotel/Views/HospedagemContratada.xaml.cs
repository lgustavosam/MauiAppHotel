namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
    // Construtor da classe, respons�vel por inicializar os componentes da p�gina
    public HospedagemContratada()
    {
        InitializeComponent();
    }

    // Evento acionado ao clicar no bot�o "Voltar"
    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Retorna para a p�gina anterior na pilha de navega��o
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            // Exibe um alerta caso ocorra um erro ao tentar voltar
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
