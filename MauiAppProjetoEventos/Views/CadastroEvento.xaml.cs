using MauiAppProjetoEventos.Models;

namespace MauiAppProjetoEventos.Views
{
    public partial class CadastroEvento : ContentPage
    {
        private Evento evento;

        public CadastroEvento()
        {
            InitializeComponent();

            // Cria nova instância do evento
            evento = new Evento
            {
                DataInicio = DateTime.Today,
                DataTermino = DateTime.Today.AddDays(1)
            };

            // Define limites de datas válidas
            dtpck_inicio.MinimumDate = DateTime.Today;
            dtpck_inicio.MaximumDate = DateTime.Today.AddMonths(6);

            dtpck_termino.MinimumDate = evento.DataInicio.AddDays(1);
            dtpck_termino.MaximumDate = DateTime.Today.AddMonths(6);

            // Define o contexto de binding
            BindingContext = evento;
        }

        // Atualiza limites do término quando o início muda
        private void dtpck_inicio_DataSelected(object sender, DateChangedEventArgs e)
        {
            dtpck_termino.MinimumDate = e.NewDate.AddDays(1);
            evento.DataInicio = e.NewDate;
        }

        private void dtpck_termino_DataSelected(object sender, DateChangedEventArgs e)
        {
            evento.DataTermino = e.NewDate;
        }

        private async void OnCadastrarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(evento.Nome))
            {
                await DisplayAlert("Aviso", "Por favor, insira o nome do evento.", "OK");
                return;
            }

            if (evento.DataTermino < evento.DataInicio)
            {
                await DisplayAlert("Aviso", "A data de término não pode ser anterior à data de início.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(evento.Local))
            {
                await DisplayAlert("Aviso", "Informe o local do evento.", "OK");
                return;
            }

            if (evento.NumeroParticipantes <= 0)
            {
                await DisplayAlert("Aviso", "O número de participantes deve ser maior que zero.", "OK");
                return;
            }

            if (evento.CustoPorParticipante <= 0)
            {
                await DisplayAlert("Aviso", "O custo por participante deve ser maior que zero.", "OK");
                return;
            }

            // Navega para a tela de resumo
            await Navigation.PushAsync(new ResumoEvento(evento));
        }
    }
}
