namespace CMongeExamen.Views;

public partial class Registro : ContentPage
{
    string usuario;
    string connectedUser;
    decimal pagoMensual;
    decimal montoInicial;

    public Registro(string username)
    {
        InitializeComponent();
        usuario = username;
        txtuser.Text = "Usuario conectado: " + usuario;
    }

    private void btnPago_Clicked(object sender, EventArgs e)
    {
        if (decimal.TryParse(txtMonto.Text, out montoInicial))
        {
            if (montoInicial < 1 || montoInicial > 1499)
            {
                DisplayAlert("Error", "El monto inicial debe estar entre 1 y 1499", "OK");
                return;
            }
        }
        else
        {
            DisplayAlert("Error", "Ingrese un monto inicial válido", "OK");
            return;
        }

        decimal porcentaje = 1500 * 0.04m;
        pagoMensual = (1500 - montoInicial) / 4 + porcentaje;
        txtPago.Text = pagoMensual.ToString("F2");
    }

    private async void btnIniciar_Clicked(object sender, EventArgs e)
    {
        if (paisPicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Debe seleccionar País", "OK");
            return;
        }

        if (ciudadPicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Debe seleccionar Ciudad", "OK");
            return;
        }
    }
}
