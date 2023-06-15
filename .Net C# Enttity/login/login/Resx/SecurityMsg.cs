namespace login.Resx
{
    public class SecurityMsg
    {
        public const string UserNameRequiredValidation = "Nombre de usuario requerido";
        public const string PasswordRequiredValidation = "Contraseña requerida";
        public const string UserNameLengthValidation = "Nombre de usuario debe tener entre 3 y 50 caracteres";
        public const string PasswordLengthValidation = "Contraseña debe tener entre 5 y 100 caracteres";
        public const string UserPasswordInvalid = "Nombre de usuario y/o contraseña inválidos";
        public const string UserInactive = "Usuario se encuentra inactivo";
        public const string UserLoggedIn = "No se puede ingresar al sistema porque usuario se encuentra con sesión iniciada en otro computador/navegador";
        public const string AccountLoginError = "Error - Error en proceso de autenticación";
        public const string TokenError = "Se ha presentado un error en la generación del token";
        public const string UserLogoutSucceeded = "Usuario ha cerrado sesión satisfactoriamente";
    }
}
