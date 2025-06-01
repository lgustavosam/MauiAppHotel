namespace MauiAppHotel.Models
{
    // Classe que representa uma hospedagem, contendo detalhes sobre o quarto e os hóspedes
    public class Hospedagem
    {
        // Propriedade que armazena o quarto selecionado pelo usuário
        public Quarto QuartoSelecionado { get; set; }

        // Quantidade de adultos na hospedagem
        public int QntAdultos { get; set; }

        // Quantidade de crianças na hospedagem
        public int QntCriancas { get; set; }

        // Data de entrada (check-in) da hospedagem
        public DateTime DataCheckIn { get; set; }

        // Data de saída (check-out) da hospedagem
        public DateTime DataCheckOut { get; set; }

        // Propriedade calculada que retorna o número de dias da estadia
        public int Estadia
        {
            get => DataCheckOut.Subtract(DataCheckIn).Days;
        }

        // Propriedade calculada que retorna o valor total da hospedagem
        public double ValorTotal
        {
            get
            {
                // Cálculo do valor total considerando adultos e crianças
                double valor_adultos = QntAdultos * QuartoSelecionado.ValorDiariaAdulto;
                double valor_criancas = QntCriancas * QuartoSelecionado.ValorDiariaCrianca;
                double total = (valor_adultos + valor_criancas) * Estadia;
                return total;
            }
        }
    }
}