using App3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3.View_Models
{
    public class PrimeiraTelaViewModel : BaseViewModel
    {
        public Command DoneCommand { get; set; }
        public Command DoneCommand2 { get; set; }
        public string Nome { get; set; }

        public PrimeiraTelaViewModel()
        {
            DoneCommand = new Command(ExecuteDoneCommand);
            DoneCommand2 = new Command(ExecuteDoneCommand2);
        }

        private async void ExecuteDoneCommand2(object obj)
        {
            await PushAsync<SegundaPaginaViewModel>();
        }

        private async void ExecuteDoneCommand()
        {           
            await App.Current.MainPage.DisplayAlert("Confirmar Dados", "Tarefa " + Nome + "criada com sucesso", "OK");
        }
    }
}
