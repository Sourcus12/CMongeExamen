namespace CMongeExamen.Views;

public partial class Login : ContentPage
{

    private string[,] userCredentials =
    {
            { "estudiante", "moviles" },
            { "uisrael", "2024" },
        };
    public Login()
	{
		InitializeComponent();

	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            messageLabel.Text = "Por favor, completa todos los campos.";
            return;
        }

        // Recorrer la matriz y verificar las credenciales
        for (int i = 0; i < userCredentials.GetLength(0); i++)
        {
            if (userCredentials[i, 0].Equals(username, StringComparison.OrdinalIgnoreCase) &&
                userCredentials[i, 1] == password)
            {
                messageLabel.TextColor = Colors.Green;
                messageLabel.Text = "¡Inicio de sesión exitoso!";

                await Navigation.PushAsync(new Views.Registro(username));
                return;
            }
        }

        messageLabel.TextColor = Colors.Red;
        messageLabel.Text = "Usuario o contraseña incorrectos.";
        await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
    }
}