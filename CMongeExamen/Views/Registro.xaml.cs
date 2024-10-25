namespace CMongeExamen.Views;

public partial class Registro : ContentPage
{
	string usuario;
	public Registro(string username)
	{
		InitializeComponent();
		usuario= username;
		txtuser.Text = usuario;
	}

    private void btnPago_Clicked(object sender, EventArgs e)
    {

    }
    private void btnIniciar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.Resumen(usuario))
    }
}