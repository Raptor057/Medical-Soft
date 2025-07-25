using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.PatientAdvancement.InsertPatientAdvancement;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.PatientAdvancement.InsertPatientAdvancement;

public class InsertPatientAdvancementPresenter<T> : IPresenter<InsertPatientAdvancementResponse>
    where T : InsertPatientAdvancementResponse
{
    private readonly GenericViewModel<InsertPatientAdvancementController> _viewModel;

    public InsertPatientAdvancementPresenter(GenericViewModel<InsertPatientAdvancementController> viewModel)
    {
        _viewModel=viewModel;
    }

    public async Task Handle(InsertPatientAdvancementResponse notification, CancellationToken cancellationToken)
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