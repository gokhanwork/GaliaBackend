using Galia.Application.Common.Interfaces;
using Galia.Domain.Common;
using Galia.Shared.DTOs.Storage;

namespace Galia.Application.Storage;

public interface IFileStorageService : ITransientService
{
    public Task<string> UploadAsync<T>(FileUploadRequest request, FileType supportedFileType)
    where T : class;
}
