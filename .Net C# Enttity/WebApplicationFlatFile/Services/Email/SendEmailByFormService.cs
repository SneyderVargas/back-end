using AutoMapper;
using DotLiquid;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Security.Policy;
using AccountControl.Data;
using AccountControl.Data.Entities;
using AccountControl.Dtos.Email;
using AccountControl.Resx;
using Hash = DotLiquid.Hash;

namespace AccountControl.Services.Email
{
    public class SendEmailByFormService: ISendEmailByFormService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;
        //private readonly AspNetRoleManager<RoleEntity> _roleManager;
        private readonly TecSolGroupDbContext _context;
        private readonly IEmailService _emailService;

        public SendEmailByFormService(IMapper mapper, IConfiguration configuration, SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, TecSolGroupDbContext context, IEmailService emailService)
        {
            _mapper = mapper;
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _emailService = emailService;
        }

        public async Task<(bool succeeded, string message)> SendEmailApplication(int idAdmForm, AdmEmployeeEntity admEmployee, string idUser, CancellationToken ct)
        {
            var userExists = await _userManager.FindByIdAsync(idUser);
            //if (userExists == null)
            //    return (false, SecurityMsg.EmailNOExistsValidation);

            //var emailsExists_form = await _context.adm_correos.Where(s => s.fk_form == Id_admForm).Select(k => k.email).ToListAsync();


            var emailsExists_form = await(from a in _context.AdmEmailEntities
                                          join b in _context.Users on a.idUser equals b.Id
                                          where a.idForm == idAdmForm && a.status == true
                                          select b.Email).ToListAsync();



            foreach (var email in emailsExists_form)
            {

                var (succeeded, message) = await SendEmailApplicationEmployee(email, admEmployee, userExists.FirstName + " " + (userExists.LastName == null || userExists.LastName == "" ? "" : userExists.LastName), ct);
                if (!succeeded)
                    return (true, SecurityMsg.rtrAgencyCreateSucceed);
            }

            return (true, SecurityMsg.rtrAgencyCreateSucceed);
        }

        private async Task<(bool Succeeded, string Message)> SendEmailApplicationEmployee(string emailUser, AdmEmployeeEntity admEmployee, string quienLoCreo, CancellationToken ct)
        {
            try
            {



                var emailsToSendParameter = emailUser;

                if (emailsToSendParameter == null)
                    return (false, DomainMsg.RecoverAccountEmailNotificationSubjectError);


                // Definir el template a usar
                string templateSource = DomainMsg.EmailTemplate_Solicitud_Create;
                Template bodyTemplate = Template.Parse(templateSource);


                //var userExists = await _context.;

                // Create DTO for the renderer
                var bodyDto = new
                {
                    Tittle = "Creación de solicitud.",
                    Now = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    Creator = quienLoCreo,

                    Message = "Empleado de la solicitud:",

                    nombre = admEmployee.nombreCompleto,
                    admEmployee.nit,
                    admEmployee.email,


                    Year = DateTime.Now.Year.ToString()
                };
                string bodyText = bodyTemplate.Render(Hash.FromAnonymousObject(bodyDto));


                List<EmailAddres> emailsFromParameter = new List<EmailAddres>();
                emailsFromParameter = new List<EmailAddres>(
                new EmailAddres[] {
                    new EmailAddres { address = Convert.ToString(_configuration["EmailConfiguration:SmtpUsername"]) }
                });

                List<EmailAddres> toAddresses = new List<EmailAddres>();
                toAddresses = new List<EmailAddres>(
                new EmailAddres[] {
                    new EmailAddres { address = emailUser }
                });

                var emailMessage = new EmailMessage
                {
                    subject = DomainMsg.RecoverAccountEmailNotificationSubject,
                    content = bodyText,
                    fromAdress = emailsFromParameter,
                    toAddress = toAddresses
                };
                await _emailService.SendAsync(emailMessage, true, null, "", ct);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

            return (true, SecurityMsg.reoverCreadentials);
        }

        public async Task<(bool succeeded, string message)> SendEmailApplications(int idCompany, int idAdmForm, AdmEmployeeEntity admEmployee, string idUser, string typeApplication, List<string> subApplicationName, List<string> typeEquipmentApplicationName, CancellationToken ct, string dateApplicationAffter, string idMode, string observation, string officeApplication)
        {
            try
            {
                var dfr = _configuration["EmailConfiguration:SmtpUsername"];

                var userExists = await _userManager.FindByIdAsync(idUser);
                //if (userExists == null)
                //    return (false, SecurityMsg.EmailNOExistsValidation);

                //var emailsExists_form = await _context.adm_correos.Where(s => s.fk_form == Id_admForm).Select(k => k.email).ToListAsync();

                var emailsExists_form = await(from a in _context.AdmEmailEntities
                                              join b in _context.Users on a.idUser equals b.Id
                                              join c in _context.userCompanyEntities on b.Id equals c.idUser
                                              where a.idForm == idAdmForm && a.status == true && c.idCompany == idCompany
                                              select b.Email).ToListAsync();


                foreach (var email in emailsExists_form)
                {

                    var (succeeded, message) = await SendEmailApplicationEmployee(email, admEmployee, userExists.FirstName + " " + (userExists.LastName == null || userExists.LastName == "" ? "" : userExists.LastName), typeApplication, subApplicationName, typeEquipmentApplicationName, ct, dateApplicationAffter, idMode, observation, officeApplication);
                    if (!succeeded)
                        return (true, SecurityMsg.rtrAgencyCreateSucceed);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

            return (true, SecurityMsg.rtrAgencyCreateSucceed);
        }

        private async Task<(bool Succeeded, string Message)> SendEmailApplicationEmployee(string email, AdmEmployeeEntity admEmployee, string quienLoCreo, string typeApplication, List<string> subApplicationName, List<string> typeEquipmentApplicationName, CancellationToken ct, string dateApplicationAffter, string idMode, string observation, string officeApplication)
        {
            try
            {




                var emailsToSendParameter = email;

                if (emailsToSendParameter == null)
                    return (false, DomainMsg.RecoverAccountEmailNotificationSubjectError);


                // Definir el template a usar

                string templateSource = "";

                if (dateApplicationAffter == "")
                {
                    templateSource = DomainMsg.EmailTemplate_Solicitud_CreateC;
                }
                else
                {
                    templateSource = DomainMsg.EmailTemplate_Solicitud_Update;
                }

                Template bodyTemplate = Template.Parse(templateSource);


                //var userExists = await _context.;
                string tipoEqui = "No Contiene";
                if (typeEquipmentApplicationName.Count() > 0)
                {
                    tipoEqui = string.Join(", ", typeEquipmentApplicationName);
                }

                string subsol = "No Contiene";
                if (subApplicationName.Count() > 0)
                {
                    subsol = string.Join(", ", subApplicationName);
                }

                if (dateApplicationAffter == "")
                {

                }

                // Create DTO for the renderer
                var bodyDto = new
                {
                    Tittle = "Creación de solicitud.",
                    Now = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),

                    Creator = quienLoCreo,
                    Confidencial = idMode,
                    Tipo = typeApplication,
                    Empleado = admEmployee.nombreCompleto,
                    dateApplicationAffter,


                    CaracteristicasH = tipoEqui,
                    CaracteristicasS = subsol,


                    Sede = officeApplication,
                    Observacion = observation == "" ? "Sin observación." : observation,



                    Year = DateTime.Now.Year.ToString()
                };
                string bodyText = bodyTemplate.Render(Hash.FromAnonymousObject(bodyDto));


                List<EmailAddres> emailsFromParameter = new List<EmailAddres>();
                emailsFromParameter = new List<EmailAddres>(
                new EmailAddres[] {
                    new EmailAddres { address = Convert.ToString(_configuration["EmailConfiguration:SmtpUsername"]) }
                });

                List<EmailAddres> toAddresses = new List<EmailAddres>();
                toAddresses = new List<EmailAddres>(
                new EmailAddres[] {
                    new EmailAddres { address = email }
                });

                var emailMessage = new EmailMessage
                {
                    subject = dateApplicationAffter == "" ? "Surgas - Notificación de Solicitud" : "Surgas - Notificación Actualización de la Solicitud",
                    content = bodyText,
                    fromAdress = emailsFromParameter,
                    toAddress = toAddresses
                };

                await _emailService.SendAsync(emailMessage, true, null, "", ct);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
            return (true, SecurityMsg.reoverCreadentials);
        }

        public async Task<(bool succeeded, string message)> SendEmailAssignments(int idCompany, int idAdmForm, AdmEmployeeEntity admEmployee, string idUser, string nameEquipment, List<string> subApplicationName, List<string> typeEquipmentApplicationName, string fileAddName, CancellationToken ct)
        {
            var userExists = await _userManager.FindByIdAsync(idUser);
            //if (userExists == null)
            //    return (false, SecurityMsg.EmailNOExistsValidation);

            //var emailsExists_form = await _context.adm_correos.Where(s => s.fk_form == Id_admForm).Select(k => k.email).ToListAsync();

            var emailsExists_form = await(from a in _context.AdmEmailEntities
                                          join b in _context.Users on a.idUser equals b.Id
                                          join c in _context.userCompanyEntities on b.Id equals c.idUser
                                          where a.idForm == idAdmForm && a.status == true && c.idCompany == idCompany
                                          select b.Email).ToListAsync();


            foreach (var email in emailsExists_form)
            {
                var (succeeded, message) = await SendEmailAssignmentsEmployee(email, admEmployee, userExists.FirstName + " " + (userExists.LastName == null || userExists.LastName == "" ? "" : userExists.LastName), nameEquipment, subApplicationName, typeEquipmentApplicationName, fileAddName, ct);
                if (!succeeded)
                    return (true, message);
            }

            return (true, SecurityMsg.rtrAgencyCreateSucceed);
        }

        private async Task<(bool Succeeded, string Message)> SendEmailAssignmentsEmployee(string email, AdmEmployeeEntity empleado, string quienLoCreo, string nameEquipment, List<string> subApplicationName, List<string> typeEquipmentApplicationName, string fileAddName, CancellationToken ct)
        {
            try
            {
                var emailsToSendParameter = email;

                if (emailsToSendParameter == null)
                    return (false, DomainMsg.RecoverAccountEmailNotificationSubjectError);


                // Definir el template a usar
                string templateSource = DomainMsg.EmailTemplate_Asignacion;
                Template bodyTemplate = Template.Parse(templateSource);


                //var userExists = await _context.;
                string tipoEqui = "No Contiene";
                if (typeEquipmentApplicationName.Count() > 0)
                {
                    tipoEqui = string.Join(", ", typeEquipmentApplicationName);
                }

                string subsol = "No Contiene";
                if (subApplicationName.Count() > 0)
                {
                    subsol = string.Join(", ", subApplicationName);
                }


                //var userExists = await _context.;

                // Create DTO for the renderer
                var bodyDto = new
                {
                    Tittle = "Asignación de solicitud.",
                    Now = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),

                    Creator = quienLoCreo,
                    Equipo = nameEquipment,
                    Empleado = empleado.nombreCompleto + " con número de cédula " + empleado.nit,


                    CaracteristicasH = tipoEqui,
                    CaracteristicasS = subsol,



                    Year = DateTime.Now.Year.ToString()
                };
                string bodyText = bodyTemplate.Render(Hash.FromAnonymousObject(bodyDto));


                List<EmailAddres> emailsFromParameter = new List<EmailAddres>();
                emailsFromParameter = new List<EmailAddres>(
                new EmailAddres[] {
                    new EmailAddres { address = Convert.ToString(_configuration["EmailConfiguration:SmtpUsername"]) }
                });

                List<EmailAddres> toAddresses = new List<EmailAddres>();
                toAddresses = new List<EmailAddres>(
                new EmailAddres[] {
                    new EmailAddres { address = email }
                });

                var emailMessage = new EmailMessage
                {
                    subject = "Surgas - Notificación de Asignación de Equipo",
                    content = bodyText,
                    fromAdress = emailsFromParameter,
                    toAddress = toAddresses
                };
                await _emailService.SendAsync(emailMessage, true, null, fileAddName, ct);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
            return (true, SecurityMsg.reoverCreadentials);
        }


        public async Task<(bool succeeded, string message)> SendEmailReturns(int idCompany, int idAdmForm, AdmEmployeeEntity admEmployee, string idUser, string nameEquipment, List<string> subApplicationName, List<string> typeEquipmentApplicationName, string fileAddName, string typeReturn, CancellationToken ct)
        {
            var userExists = await _userManager.FindByIdAsync(idUser);
            //if (userExists == null)
            //    return (false, SecurityMsg.EmailNOExistsValidation);

            //var emailsExists_form = await _context.adm_correos.Where(s => s.fk_form == Id_admForm).Select(k => k.email).ToListAsync();

            var emailsExists_form = await(from a in _context.AdmEmailEntities
                                          join b in _context.Users on a.idUser equals b.Id
                                          join c in _context.userCompanyEntities on b.Id equals c.idUser
                                          where a.idForm == idAdmForm && a.status == true && c.idCompany == idCompany
                                          select b.Email).ToListAsync();

            foreach (var email in emailsExists_form)
            {
                var (succeeded, message) = await SendEmailReturnEmployee(email, admEmployee, userExists.FirstName + " " + (userExists.LastName == null || userExists.LastName == "" ? "" : userExists.LastName), nameEquipment, subApplicationName, typeEquipmentApplicationName, fileAddName, typeReturn, ct);
                if (!succeeded)
                    return (true, SecurityMsg.rtrAgencyCreateSucceed);
            }

            return (true, SecurityMsg.rtrAgencyCreateSucceed);
        }

        private async Task<(bool Succeeded, string Message)> SendEmailReturnEmployee(string emailUser, AdmEmployeeEntity empleado, string quienLoCreo, string nombreEquipo, List<string> SubSoli_name, List<string> TipoEquipoSoli_name, string archivoAdjunto_nombre, string tipoDevolucion, CancellationToken ct)
        {
            try
            {
                var emailsToSendParameter = emailUser;

                if (emailsToSendParameter == null)
                    return (false, DomainMsg.RecoverAccountEmailNotificationSubjectError);


                // Definir el template a usar
                string templateSource = DomainMsg.EmailTemplate_Devoluciones;
                Template bodyTemplate = Template.Parse(templateSource);


                //var userExists = await _context.;
                string tipoEqui = "No Contiene";
                if (TipoEquipoSoli_name.Count() > 0)
                {
                    tipoEqui = string.Join(", ", TipoEquipoSoli_name);
                }

                string subsol = "No Contiene";
                if (SubSoli_name.Count() > 0)
                {
                    subsol = string.Join(", ", SubSoli_name);
                }


                //var userExists = await _context.;

                // Create DTO for the renderer
                var bodyDto = new
                {
                    Tittle = "Devolución tipo: (" + tipoDevolucion + ").",
                    Now = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),

                    Creator = quienLoCreo,
                    TipoDevolucion = tipoDevolucion,
                    Equipo = nombreEquipo,
                    Empleado = empleado.nombreCompleto + " con número de cédula " + empleado.nit,


                    CaracteristicasH = tipoEqui,
                    CaracteristicasS = subsol,



                    Year = DateTime.Now.Year.ToString()
                };
                string bodyText = bodyTemplate.Render(Hash.FromAnonymousObject(bodyDto));


                List<EmailAddres> emailsFromParameter = new List<EmailAddres>();
                emailsFromParameter = new List<EmailAddres>(
                new EmailAddres[] {
                    new EmailAddres { address = Convert.ToString(_configuration["EmailConfiguration:SmtpUsername"]) }
                });

                List<EmailAddres> toAddresses = new List<EmailAddres>();
                toAddresses = new List<EmailAddres>(
                new EmailAddres[] {
                    new EmailAddres { address = emailUser }
                });

                var emailMessage = new EmailMessage
                {
                    subject = "Surgas - Devolución tipo: (" + tipoDevolucion + ")",
                    content = bodyText,
                    fromAdress = emailsFromParameter,
                    toAddress = toAddresses
                };
                await _emailService.SendAsync(emailMessage, true, null, archivoAdjunto_nombre, ct);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

            return (true, SecurityMsg.reoverCreadentials);
        }

        public async Task<(bool succeeded, string message)> SendEmailReportA(string idUser, string body, string affair, string fileAddName, CancellationToken ct)
        {
            var userExists = await _userManager.FindByIdAsync(idUser);
            //if (userExists == null)
            //    return (false, SecurityMsg.EmailNOExistsValidation);


            var emailsExists_form = await(from b in _context.Users
                                          where b.Id == idUser
                                          select b.Email).ToListAsync();


            foreach (var email in emailsExists_form)
            {
                var (succeeded, message) = await SendEmailReportFile(email, idUser, body, affair, fileAddName, ct);
                if (!succeeded)
                    return (true, SecurityMsg.rtrAgencyCreateSucceed);
            }

            return (true, SecurityMsg.rtrAgencyCreateSucceed);
        }
        private async Task<(bool Succeeded, string Message)> SendEmailReportFile(string emailUser, string IdUser, string body, string asunto, string archivoAdjunto_nombre, CancellationToken ct)
        {
            try
            {
                var emailsToSendParameter = emailUser;

                if (emailsToSendParameter == null)
                    return (false, DomainMsg.RecoverAccountEmailNotificationSubjectError);


                // Definir el template a usar
                string templateSource = DomainMsg.EmailTemplate_Reporte_a;
                Template bodyTemplate = Template.Parse(templateSource);


                //var userExists = await _context.;



                //var userExists = await _context.;

                // Create DTO for the renderer
                var bodyDto = new
                {
                    Tittle = "Reporte de: (" + asunto + ").",
                    Now = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),

                    Reporte = asunto,


                    Year = DateTime.Now.Year.ToString()
                };
                string bodyText = bodyTemplate.Render(Hash.FromAnonymousObject(bodyDto));


                List<EmailAddres> emailsFromParameter = new List<EmailAddres>();
                emailsFromParameter = new List<EmailAddres>(
                new EmailAddres[] {
                    new EmailAddres { address = Convert.ToString(_configuration["EmailConfiguration:SmtpUsername"]) }
                });

                List<EmailAddres> toAddresses = new List<EmailAddres>();
                toAddresses = new List<EmailAddres>(
                new EmailAddres[] {
                    new EmailAddres { address = emailUser }
                });

                var emailMessage = new EmailMessage
                {
                    subject = "Surgas - Reporte: (" + asunto + ")",
                    content = bodyText,
                    fromAdress = emailsFromParameter,
                    toAddress = toAddresses
                };
                await _emailService.SendRportAsync(emailMessage, true, null, archivoAdjunto_nombre, ct);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

            return (true, SecurityMsg.reoverCreadentials);
        }
    }
}
