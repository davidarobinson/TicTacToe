using System;
using Xamarin.Forms;

namespace TicTacToe
{
    public partial class MainPage : ContentPage
    {
        private Button[] buttons = new Button[9];
        private TicTacToeGameEngine game = new TicTacToeGameEngine();

        public MainPage()
        {
            InitializeComponent();

            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;
        }

        protected void Button_Clicked(object sender, EventArgs e)
        {
            game.SetButton((Button)sender);
            if (game.CheckWinner(buttons))
            {
                GameOverStackLayout.IsVisible = true;
                ITextToSpeech speech = DependencyService.Get<ITextToSpeech>();
                if (speech != null)
                {
                    speech.Speak("Game Over!");
                }
            }
        }

        protected void PlayAgain_Clicked(object sender, EventArgs e)
        {
            game.ResetGame(buttons);
            GameOverStackLayout.IsVisible = false;
        }
    }
}
