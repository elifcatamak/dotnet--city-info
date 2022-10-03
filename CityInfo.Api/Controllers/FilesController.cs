using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.Api.Controllers;

[Route("api/files")]
[Authorize]
[ApiController]
public class FilesController : ControllerBase
{
    private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

    public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
    {
        _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
                                            ?? throw new ArgumentNullException(
                                                nameof(fileExtensionContentTypeProvider));
    }

    [HttpGet("{fileId}")]
    public ActionResult GetFile(string fileId)
    {
        // Would use the fileId to fetch the correct file path
        // However, for now I hardcoded the filePath for practice purposes 
        var filePath = "blank.pdf";

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }

        if (!_fileExtensionContentTypeProvider.TryGetContentType(filePath, out var contentType))
        {
            contentType = "application/octet-stream";
        }

        var bytes = System.IO.File.ReadAllBytes(filePath);

        return File(bytes, contentType, Path.GetFileName(filePath));
    }
}