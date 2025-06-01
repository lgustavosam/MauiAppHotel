using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    // Declara��o da propriedade para armazenar a inst�ncia do aplicativo
    App PropriedadeApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        // Obt�m a inst�ncia atual da aplica��o
        PropriedadeApp = (App)Application.Current;

        // Define a lista de quartos dispon�veis no picker de sele��o
        pck_quarto.ItemsSource = PropriedadeApp.lista_quartos;

        // Configura��o das datas m�nimas e m�ximas para o check-in
        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        // Configura��o das datas m�nimas e m�ximas para o check-out
        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
    }

    // Evento do bot�o para navegar para a p�gina "Sobre"
    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SobrePage());
    }

    // Evento para processar a contrata��o da hospedagem e navegar para a p�gina de confirma��o
    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            // Cria��o do objeto Hospedagem com os dados preenchidos pelo usu�rio
            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckIn = dtpck_checkin.Date,
                DataCheckOut = dtpck_checkout.Date,
            };

            // Navega para a tela de "HospedagemContratada" com os dados vinculados ao contexto
            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h,
            });
        }
        catch (Exception ex)
        {
            // Exibe um alerta caso ocorra um erro durante o processo
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    // Evento disparado quando uma nova data de check-in � selecionada
    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        // Obt�m a data selecionada pelo usu�rio
        DateTime data_selecionada_checkin = elemento.Date;

        // Atualiza as datas m�nimas e m�ximas para o check-out com base na data de check-in
        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }

    // Evento do bot�o para navegar para a p�gina "SobrePousada"
    private void Button_Clicked_2(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SobrePousadaPage());
    }
}