using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    // Declaração da propriedade para armazenar a instância do aplicativo
    App PropriedadeApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        // Obtém a instância atual da aplicação
        PropriedadeApp = (App)Application.Current;

        // Define a lista de quartos disponíveis no picker de seleção
        pck_quarto.ItemsSource = PropriedadeApp.lista_quartos;

        // Configuração das datas mínimas e máximas para o check-in
        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        // Configuração das datas mínimas e máximas para o check-out
        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
    }

    // Evento do botão para navegar para a página "Sobre"
    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SobrePage());
    }

    // Evento para processar a contratação da hospedagem e navegar para a página de confirmação
    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            // Criação do objeto Hospedagem com os dados preenchidos pelo usuário
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

    // Evento disparado quando uma nova data de check-in é selecionada
    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        // Obtém a data selecionada pelo usuário
        DateTime data_selecionada_checkin = elemento.Date;

        // Atualiza as datas mínimas e máximas para o check-out com base na data de check-in
        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }

    // Evento do botão para navegar para a página "SobrePousada"
    private void Button_Clicked_2(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SobrePousadaPage());
    }
}