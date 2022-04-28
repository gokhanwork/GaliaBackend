using Galia.Shared.DTOs.General.Requests;

namespace Galia.Application.Common.Interfaces;

public interface IMailService : ITransientService
{
    Task SendAsync(MailRequest request);
}
