using Common.Common.CleanArch;
using MediatR;
using Medical.Office.App.UseCases.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Office.Net8WebApi.EndPoints.Email;

//[Authorize]
[Route("[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly ILogger<EmailController> _logger;
    private readonly IMediator _mediator;
    private readonly GenericViewModel<EmailController> _viewModel;

    public EmailController(ILogger<EmailController> logger, IMediator mediator, GenericViewModel<EmailController> viewModel)
    {
        _logger = logger;
        _mediator = mediator;
        _viewModel = viewModel;
    }

    [HttpPost]
    [Route("/api/email/send")]
    public async Task<IActionResult> Execute([FromBody] EmailRequestBody requestBody)
    {
        var request = new EmailRequest(requestBody.Email, requestBody.Subject, requestBody.Body);

        try
        {
            _ = await _mediator.Send(request).ConfigureAwait(false);
            return _viewModel.IsSuccess ? Ok(_viewModel) : StatusCode(500, _viewModel);
        }
        catch (Exception ex)
        {
            var innerEx = ex;
            while (innerEx.InnerException != null) innerEx = innerEx.InnerException!;
            return StatusCode(500, _viewModel.Fail(innerEx.Message));
        }
    }
}