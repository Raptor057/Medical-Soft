using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Get.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientDiagnostics.Presenters;

public sealed class GetPatientDiagnosticsPresenter<T> : IPresenter<PatientDiagnosticsGetResponse>
where T : PatientDiagnosticsGetResponse
{
    private readonly GenericViewModel<PatientDiagnosticsController> _viewModel;

    public GetPatientDiagnosticsPresenter(GenericViewModel<PatientDiagnosticsController> viewModel)
    {
        _viewModel = viewModel;
    }
    public async Task Handle(PatientDiagnosticsGetResponse notification, CancellationToken cancellationToken)
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