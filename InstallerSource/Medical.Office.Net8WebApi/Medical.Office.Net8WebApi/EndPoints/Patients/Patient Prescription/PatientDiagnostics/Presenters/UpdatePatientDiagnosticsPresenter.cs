using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Update.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientDiagnostics.Presenters;

public sealed class UpdatePatientDiagnosticsPresenter<T> : IPresenter<PatientDiagnosticsUpdateResponse>
where T : PatientDiagnosticsUpdateResponse
{
    private readonly GenericViewModel<PatientDiagnosticsController> _viewModel;
    public UpdatePatientDiagnosticsPresenter(GenericViewModel<PatientDiagnosticsController> viewModel)
    {
        _viewModel = viewModel;
    }
    public async Task Handle(PatientDiagnosticsUpdateResponse notification, CancellationToken cancellationToken)
    {
        if(notification is IFailure failure)
        {
            _viewModel.Fail(failure.Message);
            await Task.CompletedTask;
        }
        else if (notification is ISuccess success)
        {
            _viewModel.OK(success);
            await Task.CompletedTask;
        }
    }
}