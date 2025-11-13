using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppProjetoEventos.Models
{
    public class Evento
    {
        // Propriedades preenchidas pelo usuário
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int NumeroParticipantes { get; set; }
        public string Local { get; set; }
        public decimal CustoPorParticipante { get; set; }

        // Propriedade calculada: duração em dias (usa TimeSpan internamente)
        public int DuracaoDias
        {
            get
            {
                TimeSpan diff = DataTermino - DataInicio;
                return (int)diff.TotalDays + 1; // +1 para incluir o dia inicial
            }
        }

        // Propriedade calculada: custo total
        public decimal CustoTotal => NumeroParticipantes * CustoPorParticipante;

        public static explicit operator Evento(Application? v)
        {
            throw new NotImplementedException();
        }
    }
}