using System.Text;

namespace AccountControl.Resx
{
    public class SecurityMsg
    {
        public const string IdRequiredValidation = "Id requerido";
        public const string UserNameRequiredValidation = "Nombre de usuario requerido";
        public const string UserLoggedInExt = "Usuario externo se encuentra logueado en sistema";
        public const string UserNameLengthValidation = "Nombre de usuario debe tener entre 3 y 5 caracteres";
        public const string UserPasswordRequiredValidation = "Contraseña requerida";
        public const string UserPasswordLengthValidation = "Contraseña debe tener entre 5 y 100 caracteres";
        public const string AccountLoginError = "Error - Error en proceso de autenticación";
        public const string UserPasswordInvalid = "Nombre de usuario y/o contraseña inválidos";
        public const string UserInactive = "Usuario se encuentra inactivo";
        public const string UserLoggedIn = "No se puede ingresar al sistema porque usuario se encuentra con sesión iniciada en otro computador/navegador";
        public const string TokenError = "Se ha presentado un error en la generación del token";
        public const string NamesRequiredValidation = "Nombres requeridos";
        public const string DocumentCCRequiredValidation = "Documento requerido";
        public const string DocumentCCLengthValidation = "Documento debe contener entre 7 y 13 digitos";
        public const string NITCCLengthValidation = "EL NIT debe contener entre 3 y 13 digitos";
        public const string NamesLengthValidation = "Nombres deben tener entre 1 y 100 caracteres";
        public const string LastNamesRequiredValidation = "Apellidos requeridos";
        public const string LastNamesLengthValidation = "Apellidos deben tener entre 1 y 100 caracteres";
        public const string EmailRequiredValidation = "Correo electrónico requerido";
        public const string EmailFormatValidation = "Correo electrónico es incorrecto";
        public const string EmailLengthValidation = "Correo electrónico debe tener entre 1 y 200 caracteres";
        public const string RoleRequiredValidation = "Rol requerido";
        public const string RoleAdminEditValidation = "El Rol Admin no puede editarse";
        public const string RoleLengthValidation = "Rol debe tener 1 caracter";
        public const string RoleInvalidValidation = "Rol seleccionado no existe";
        public const string RoleDuplicatedValidation = "El rol ya existe en el sistema";
        public const string RoleUpdateSucceeded = "Rol actualizado satisfactoriamente";
        public const string RoleCreateSucceeded = "Rol creado satisfactoriamente";
        public const string PasswordRequiredValidation = "Contraseña requerida";
        public const string PasswordLengthValidation = "Contraseña debe tener entre 5 y 30 caracteres";
        public const string UserRegisterSucceeded = "Usuario registrado satisfactoriamente";
        public const string AccountRegisterError = "Error de seguridad";
        public const string UserNameExistsValidation = "Nombre de usuario ya se encuentra registrado";
        public const string EmailExistsValidation = "Email ya se encuentra asociado a otro usuario";
        public const string UserUpdateSucceeded = "Usuario actualizado satisfactoriamente";
        public const string UserActivateSucceeded = "Usuario activado satisfactoriamente";
        public const string UserLogoutSucceeded = "Usuario ha cerrado sesión satisfactoriamente";
        public const string ActiveRequiredValidation = "Activo/Inactivo requerido";
        public const string UserIdExistsValidation = "Id '{0}' de usuario no existe";
        //public const string RoleIdDontExistsValidation = "Ocurrio un problema, no se logro eliminar el rol Id '{0}'";
        public const string UsersDeleteSucceeded = "Usuario(s) eliminado(s) satisfactoriamente";
        public const string RolesDeleteSucceeded = "Rol(es) eliminado(s) satisfactoriamente";
        public const string CurrentPasswordRequiredValidation = "Contraseña actual requerida";
        public const string NewPasswordRequiredValidation = "Contraseña nueva requerida";
        public const string UserUpdatePasswordSucceeded = "Contraseña de usuario actualizada satisfactoriamente";
        public const string UserResetPasswordSucceeded = "Contraseña de usuario reiniciada satisfactoriamente";
        public const string ResetPasswordEmailNotificationSubject = "Surgas - Notificación de cambio contraseña";
        public const string TokenRequiredValidation = "Token requerido";
        public const string TokenInvalid = "Token inválido - JWT no está bien formado";
        public const string TokenExpired = "Token se encuentra expirado";
        public const string CategoryNameRequiredValidation = "Nombre de la categoria requerido";
        public const string CategoryNameLengthValidation = "El nombre de la categoria debe contener entre 1 y 11 caracteres";
        public const string CategoryDescRequiredValidation = "La descripcion de la categoria requerido";
        public const string CategoryInvalidValidation = "Categoria a crear invalidad";
        public const string CategoryDuplicatedValidation = "La categoria ya existe en el sistema";
        public const string CategoryRequiredValidation = "La categoria es requerida";
        public const string CatUpdateSucceeded = "La categoria se ha actualizado con exito";
        public const string CatCreateSucceeded = "La categoria se ha creado con exito";
        public const string PermitNameExistValidation = "El nombre del permiso ya existe en el sistema";
        public const string PermitCodeExistValidation = "El codigo del permiso ya existe en el sistema";
        public const string PermitNameCodeExistValidation = "La combinacion de codigo y nombre del permiso ya existen en el sistema";
        public const string PermitCreateSuccess = "El permiso ha sido creado con exito";
        public const string PermissionRequiredValidation = "El permiso no existe en el sistema";
        public const string PermissionDeleteSucceeded = "El permiso se ha desactivado exitosamente";
        public const string UserRolePermitCreateSuccess = "Los permisos han sido asignados exitosamente";
        //public const string RoleUserExist = "El rol '{0}' no debe estar asignado a ningun usuario del sistema para ser eliminado";
        public const string rtrPortalCreateSucceed = "La informacion se a publicado con exito en la informacion publica del portal";
        public const string rtrAgencyCreateSucceed = "La informacion se a cargado con exito";
        public const string reoverCreadentials = "Por favor revise el correo que inscribió en la plataforma, pues le llegara la información necesaria para la recuperación de sus credenciales.";
        public const string EmailNOExistsValidation = "Email no se encuentra asociado a un usuario";
        public const string CompanyRequiredValidation = "Empresa requerida";
        public const string CompanyInvalidValidation = "Empresa seleccionada no existe";
        public const string CargoInvalidValidation = "Cargo seleccionado no existe";

        public const string ihs_atributos_editar_Validation = "El atributo que desea editar no existe.";
        public const string ihs_atributos_editarNameAtributo_Validation = "El campo atributo es requerido.";
        public const string ihs_atributos_UpdateSucceeded = "El atributo se actualizo con éxito.";
        public const string ihs_atributos_UpdateError = "Error en el proceso de edición.";
        public const string ihs_atributos_CreateSucceeded = "El atributo se creo con éxito.";
        public const string ihs_atributos_crear_Validation = "El atributo que desea crear ya existe.";
        public const string ihs_atributos_CreateError = "Error en el proceso de creación de un nuevo atributo.";

        public const string ihs_clase_editar_Validation = "La clase que desea editar no existe.";
        public const string ihs_clase_editarNameClase_Validation = "El campo clase es requerido.";
        public const string ihs_clase_UpdateSucceeded = "La clase se actualizo con éxito.";
        public const string ihs_clase_UpdateError = "Error en el proceso de edición.";
        public const string ihs_clase_CreateSucceeded = "La clase se creo con éxito.";
        public const string ihs_clase_crear_Validation = "La clase que desea crear ya existe.";
        public const string ihs_clase_CreateError = "Error en el proceso de creación de una nueva clase.";

        public const string ihs_subclase_editar_Validation = "La subclase que desea editar no existe.";
        public const string ihs_subclase_editarNamesubClase_Validation = "El campo subclase es requerido.";
        public const string ihs_subclase_UpdateSucceeded = "La subclase se actualizo con éxito.";
        public const string ihs_subclase_UpdateError = "Error en el proceso de edición.";
        public const string ihs_subclase_CreateSucceeded = "La subclase se creo con éxito.";
        public const string ihs_subclase_crear_Validation = "La subclase que desea crear ya existe.";
        public const string ihs_subclase_editar_Validation_existe = "El nombre que está agregando al campo subclase, ya existe.";
        public const string ihs_subclase_CreateError = "Error en el proceso de creación de una nueva subclase.";


        public const string ihs_componente_editar_Validation = "El componente que desea editar no existe.";
        public const string ihs_componente_editarNameComponente_Validation = "El campo componente es requerido.";
        public const string ihs_componente_UpdateSucceeded = "El componente se actualizo con éxito.";
        public const string ihs_componente_UpdateError = "Error en el proceso de edición.";
        public const string ihs_componente_CreateSucceeded = "El componente se creo con éxito.";
        public const string ihs_componente_crear_Validation = "El componente que desea crear ya existe.";
        public const string ihs_componente_CreateError = "Error en el proceso de creación de una nuevo componente.";




        public const string ihs_compo_atributos_editar_Validation = "El atributo del componente que desea editar no existe.";
        public const string ihs_compo_atributos_editarNameComponente_Validation = "El campo es requerido.";
        public const string ihs_compo_atributos_UpdateSucceeded = "El atributo del componente se actualizo con éxito.";
        public const string ihs_compo_atributos_UpdateError = "Error en el proceso de edición.";
        public const string ihs_compo_atributos_CreateSucceeded = "El atributo del componente se creo con éxito.";
        public const string ihs_compo_atributos_crear_Validation = "El atributo que desea crear ya existe en el copmponente.";
        public const string ihs_compo_atributos_CreateError = "Error en el proceso de creación de una nuevo atributo para el componente.";


        public const string ihs_tipo_equipo_editar_Validation = "El tipo equipo que desea editar no existe.";
        public const string ihs_tipo_equipo_editarNametipoEquipo_Validation = "El campo tipo equipo es requerido.";
        public const string ihs_tipo_equipo_UpdateSucceeded = "El tipo equipo se actualizo con éxito.";
        public const string ihs_tipo_equipo_UpdateError = "Error en el proceso de edición.";
        public const string ihs_tipo_equipo_CreateSucceeded = "El tipo equipo se creo con éxito.";
        public const string ihs_tipo_equipo_crear_Validation = "El tipo equipo ya existe.";
        public const string ihs_tipo_equipo_CreateError = "Error en el proceso de creación de un nuevo tipo equipo.";


        public const string ihs_sede_editar_Validation = "La sede que desea editar no existe.";
        public const string ihs_sede_editarNamesede_Validation = "El campo sede es requerido.";
        public const string ihs_sede_UpdateSucceeded = "La sede se actualizo con éxito.";
        public const string ihs_sede_UpdateError = "Error en el proceso de edición.";
        public const string ihs_sede_CreateSucceeded = "La sede se creo con éxito.";
        public const string ihs_sede_crear_Validation = "La sede ya existe para la empresa seleccionada.";
        public const string ihs_sede_CreateError = "Error en el proceso de creación de una nueva sede.";


        public const string ihs_responsable_editar_Validation = "El responsable que desea editar no existe.";
        public const string ihs_responsable_editarNameresponsable_Validation = "El campo responsable es requerido.";
        public const string ihs_responsable_UpdateSucceeded = "El responsable se actualizo con éxito.";
        public const string ihs_responsable_UpdateError = "Error en el proceso de edición.";
        public const string ihs_responsable_CreateSucceeded = "El responsable se creo con éxito.";
        public const string ihs_responsable_crear_Validation = "El responsable que desea crear ya existe.";
        public const string ihs_responsable_CreateError = "Error en el proceso de creación de un nuevo responsable.";


        public const string ihs_equipos_editar_Validation = "El equipo que desea editar no existe.";
        public const string ihs_equipos_editarNameequipos_Validation = "El campo equipo es requerido.";
        public const string ihs_equipos_UpdateSucceeded = "El equipo se actualizo con éxito.";
        public const string ihs_equipos_UpdateError = "Error en el proceso de edición.";
        public const string ihs_equipos_CreateSucceeded = "El equipo se creo con éxito.";
        public const string ihs_equipos_crear_Validation = "El equipo que desea crear ya existe.";
        public const string ihs_equipos_CreateError = "Error en el proceso de creación de un nuevo equipo.";


        public const string ihs_tipo_novedad_editar_Validation = "El tipo novedad que desea editar no existe.";
        public const string ihs_tipo_novedad_editarNametiponovedad_Validation = "El campo tipo novedad es requerido.";
        public const string ihs_tipo_novedad_UpdateSucceeded = "El tipo novedad se actualizo con éxito.";
        public const string ihs_tipo_novedad_UpdateError = "Error en el proceso de edición.";
        public const string ihs_tipo_novedad_CreateSucceeded = "El tipo novedad se creo con éxito.";
        public const string ihs_tipo_novedad_crear_Validation = "El tipo novedad ya existe.";
        public const string ihs_tipo_novedad_CreateError = "Error en el proceso de creación de un nuevo tipo novedad.";


        public const string ihs_novedades_equipo_editar_Validation = "La novedad equipo que desea editar no existe.";
        public const string ihs_novedades_equipo_editarNameequipos_Validation = "El campo novedad equipo es requerido.";
        public const string ihs_novedades_equipo_UpdateSucceeded = "La novedad equipo se actualizo con éxito.";
        public const string ihs_novedades_equipo_UpdateError = "Error en el proceso de edición.";
        public const string ihs_novedades_equipo_CreateSucceeded = "La novedad equipo se creo con éxito.";
        public const string ihs_novedades_equipo_crear_Validation = "La novedad equipo que desea crear ya existe.";
        public const string ihs_novedades_equipo_CreateError = "Error en el proceso de creación de un nueva novedad equipo.";


        public const string ihs_novedades_componente_editar_Validation = "La novedad componente que desea editar no existe.";
        public const string ihs_novedades_componente_editarNamecomponentes_Validation = "El campo novedad componente es requerido.";
        public const string ihs_novedades_componente_UpdateSucceeded = "La novedad componente se actualizo con éxito.";
        public const string ihs_novedades_componente_UpdateError = "Error en el proceso de edición.";
        public const string ihs_novedades_componente_CreateSucceeded = "La novedad componente se creo con éxito.";
        public const string ihs_novedades_componente_crear_Validation = "La novedad componente que desea crear ya existe.";
        public const string ihs_novedades_componente_CreateError = "Error en el proceso de creación de un nueva novedad componente.";


        public const string ihs_solicitud_subclases_editar_Validation = "La subclase de la solicitud que desea editar no existe.";
        public const string ihs_solicitud_subclases_editarNameSolicitud_Validation = "La solicitud es requerida.";
        public const string ihs_solicitud_subclases_UpdateSucceeded = "La subclase de la solicitud se actualizo con éxito.";
        public const string ihs_solicitud_subclases_UpdateError = "Error en el proceso de edición.";
        public const string ihs_solicitud_subclases_CreateSucceeded = "La subclase de la solicitud se creo con éxito.";
        public const string ihs_solicitud_subclases_crear_Validation = "La subclase que desea crear ya existe en la solicitud.";
        public const string ihs_solicitud_subclases_CreateError = "Error en el proceso de creación de una nueva subclase para la solicitud.";

        public const string ihs_solicitud_editar_Validation = "La solicitud que desea editar no existe.";
        public const string ihs_solicitud_editarNameSolicitud_Validation = "El campo solicitud es requerido.";
        public const string ihs_solicitud_UpdateSucceeded = "La solicitud se actualizo con éxito.";
        public const string ihs_solicitud_UpdateError = "Error en el proceso de edición.";
        public const string ihs_solicitud_CreateSucceeded = "La solicitud se creo con éxito.";
        public const string ihs_solicitud_crear_Validation = "La solicitud que desea crear ya existe.";
        public const string ihs_solicitud_CreateError = "Error en el proceso de creación de una nueva solicitud.";

        public const string adm_empleados_editar_Validation = "El empleado que desea editar no existe.";
        public const string adm_empleados_editarNameEmpleado_Validation = "El campo empleado es requerido.";
        public const string adm_empleados_UpdateSucceeded = "El empleado se actualizo con éxito.";
        public const string adm_empleados_UpdateError = "Error en el proceso de edición.";
        public const string adm_empleados_CreateSucceeded = "El empleado se creo con éxito.";
        public const string adm_empleados_crear_Validation = "El empleado que desea crear ya existe.";
        public const string adm_empleados_crear_Validation2 = "El empleado ya está registrado en ésta empresa.";
        public const string adm_empleados_CreateError = "Error en el proceso de creación de un nuevo empleado.";
        public const string adm_empleados_Create_Validatio_Cargo = "El cargo que dese asignar al empleado ya ha sido ocupado.";
        public const string adm_empleados_crear_Validation_email = "El E-Mail del nuevo empleado ya a sido asignado.";

        public const string cargo_crear_Validation = "El cargo que desea crear ya existe.";
        public const string cargo_CreateSucceeded = "El cargo se creo con éxito.";
        public const string cargo_editarNameCargo_Validation = "El campo cargo es requerido.";
        public const string cargo_CreateError = "Error en el proceso de creación de un nuevo cargo.";
        public const string cargo_UpdateError = "Error en el proceso de edición.";

        public const string area_crear_Validation = "El area que desea crear ya existe.";
        public const string area_CreateSucceeded = "El area se creo con éxito.";
        public const string area_editarNameArea_Validation = "El campo area es requerido.";
        public const string area_CreateError = "Error en el proceso de creación de una nueva area.";
        public const string area_UpdateError = "Error en el proceso de edición.";




        public const string adm_empleados_crear_respnsable_Validation = "El empleado no existe.";
        public const string restriccion_cuenta_multi_empresa = "Su cuenta pertenece a más de una empresa, para poder proceder necesita una cuenta común.";



        public static string GetResetPasswordNotificationContent(string newPassword)
        {
            var content = new StringBuilder();
            content.AppendLine("Se ha realizado un reinicio de contraseña.");
            content.Append(Environment.NewLine);
            content.AppendLine($"La nueva contraseña es: {newPassword}");
            content.Append(Environment.NewLine);

            return content.ToString();
        }


        public static string GetchangePasswordNotificationContent(string newPassword)
        {
            var content = new StringBuilder();
            content.AppendLine("Se ha cambiado la contraseña por la que usted incluyo.");
            content.Append(Environment.NewLine);
            content.AppendLine($"La nueva contraseña es: {newPassword}");
            content.Append(Environment.NewLine);

            return content.ToString();
        }


        public static string RoleUserExist(string roleName)
        {
            return string.Format("El rol '{0}' no debe estar asignado a ningun usuario del sistema para ser eliminado", roleName);
        }

        public static string RoleIdDontExistsValidation(string roleName)
        {
            return string.Format("Ocurrio un problema, no se logro eliminar el rol Id '{0}'", roleName);
        }

        public static string CategoryDeleteConstraintValidation(string category)
        {
            return string.Format("La categoria '{0}' no se puede eliminar porque existen permisos relacionados en el sistema", category);
        }
    }
}
