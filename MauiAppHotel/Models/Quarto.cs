using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppHotel.Models
{
    // Classe que representa um quarto disponível na hospedagem
    public class Quarto
    {
        // Descrição do quarto (exemplo: "Suite Luxo", "Quarto Econômico", etc.)
        public string Descricao { get; set; }

        // Valor da diária para adultos
        public double ValorDiariaAdulto { get; set; }

        // Valor da diária para crianças
        public double ValorDiariaCrianca { get; set; } // Referenciado no minuto 00:22:00 do vídeo.
    }
}