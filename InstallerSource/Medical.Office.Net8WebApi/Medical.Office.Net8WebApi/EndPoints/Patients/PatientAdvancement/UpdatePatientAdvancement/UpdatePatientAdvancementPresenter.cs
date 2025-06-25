using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.PatientAdvancement.UpdatePatientAdvancement.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.PatientAdvancement.UpdatePatientAdvancement;

public class UpdatePatientAdvancementPresenter<T>: IPresenter<UpdatePatientAdvancementResponse>
    where T : UpdatePatientAdvancementResponse
{
    private readonly GenericViewModel<UpdatePatientAdvancementController> _viewModel;

    public UpdatePatientAdvancementPresenter(GenericViewModel<UpdatePatientAdvancementController> viewModel)
    {
        _viewModel=viewModel;
    }
    public async Task Handle(UpdatePatientAdvancementResponse notification, CancellationToken cancellationToken)
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