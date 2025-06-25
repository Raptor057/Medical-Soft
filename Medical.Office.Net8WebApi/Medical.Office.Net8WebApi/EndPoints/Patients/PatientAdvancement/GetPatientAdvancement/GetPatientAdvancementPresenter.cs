using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.PatientAdvancement.GetPatientAdvancement.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.PatientAdvancement.GetPatientAdvancement;

public class GetPatientAdvancementPresenter<T>: IPresenter<GetPatientAdvancementResponse>
    where T : GetPatientAdvancementResponse
{
    private readonly GenericViewModel<GetPatientAdvancementController> _viewModel;

    public GetPatientAdvancementPresenter(GenericViewModel<GetPatientAdvancementController> viewModel)
    {
        _viewModel = viewModel;
    }
    public async Task Handle(GetPatientAdvancementResponse notification, CancellationToken cancellationToken)
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