using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Email.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Email;

public class EmailPresenter<T> : IPresenter<EmailResponse>
    where T : EmailResponse
{
    private readonly GenericViewModel<EmailController> _viewModel;

    public EmailPresenter(GenericViewModel<EmailController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(EmailResponse notification, CancellationToken cancellationToken)
    {
        if (notification is IFailure failure)
        {
            _viewModel.Fail(failure.Message);
            await Task.CompletedTask;
        }
        else if (notification is ISuccess response)
        {
            _viewModel.OK(response);
            await Task.CompletedTask;
        }
    }
}