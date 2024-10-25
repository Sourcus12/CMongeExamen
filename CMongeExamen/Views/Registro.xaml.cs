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
		usuario= username;
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
            DisplayAlert("Error", "Debe seleccionar País", "OK");
            return;
        }

        if (CiudadP.SelectedIndex == -1)
        {
            DisplayAlert("Error", "Debe seleccionar Ciudad", "OK");
            return;
        }

        if (string.IsNullOrEmpty(txtNombre.Text))
        {
            DisplayAlert("Error", "Debe ingresar Nombre", "OK");
            return;
        }

        if (string.IsNullOrEmpty(txtApellido.Text))
        {
            DisplayAlert("Error", "Debe ingresar Apellido", "OK");
            return;
        }

        if (string.IsNullOrEmpty(txtEdad.Text))
        {
            DisplayAlert("Error", "Debe ingresar Edad", "OK");
            return;
        }

        if (FechaS.Date < DateTime.Now)
        {
            DisplayAlert("Error", "La fecha debe ser mayor a la actual", "OK");
            return;
        }

        if (string.IsNullOrEmpty(txtMonto.Text))
        {
            DisplayAlert("Error", "Debe calcular el pago", "OK");
            return;
        }

        decimal pagoTotal = pagoMensual * 4 + montoInicial;

        await Navigation.PushAsync(new Views.Resumen(usuario, txtMonto.Text, txtPago.Text, pagoTotal.ToString(), FechaS.Date.ToString("dd-MM-yyyy"), paisPicker.SelectedItem.ToString(), CiudadP.SelectedItem.ToString(), txtNombre.Text, txtApellido.Text, txtEdad.Text));
    }
}