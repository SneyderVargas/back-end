using WebApplicationFlatFile.Data.Entities;

namespace WebApplicationFlatFile.Services.Email
{
    public interface ISendEmailByFormService
    {
        Task<(bool succeeded, string message)> SendEmailApplication(int idAdmFomr, AdmEmployeeEntity admEmployee, string idUser, CancellationToken ct);
        Task<(bool succeeded, string message)> SendEmailApplications(int idCompany, int idAdmForm, AdmEmployeeEntity admEmployee, string idUser, string typeApplication, List<string> subApplicationName, List<string> typeEquipmentApplicationName, CancellationToken ct, string dateApplicationAffter, string idMode, string observation, string officeApplication);
        Task<(bool succeeded, string message)> SendEmailAssignments(int idCompany, int idAdmForm, AdmEmployeeEntity admEmployee, string idUser, string nameEquipment, List<string> subApplicationName, List<string> typeEquipmentApplicationName, string fileAddName, CancellationToken ct);
        Task<(bool succeeded, string message)> SendEmailReturns(int idCompany, int idAdmForm, AdmEmployeeEntity admEmployee, string idUser, string nameEquipment, List<string> subApplicationName, List<string> typeEquipmentApplicationName, string fileAddName, string typeReturn, CancellationToken ct);
        Task<(bool succeeded, string message)> SendEmailReportA(string idUser, string body, string affair, string fileAddName, CancellationToken ct);
    }
}
