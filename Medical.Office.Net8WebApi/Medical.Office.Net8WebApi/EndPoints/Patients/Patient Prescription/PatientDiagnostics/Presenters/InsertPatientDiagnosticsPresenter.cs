using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientDiagnostics.Insert.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientDiagnostics.Presenters;

public class InsertPatientDiagnosticsPresenter<T>: IPresenter<PatientDiagnosticsInsertResponse>
where T : PatientDiagnosticsInsertResponse
{
    private readonly GenericViewModel<PatientDiagnosticsController> _viewModel;
    public InsertPatientDiagnosticsPresenter(GenericViewModel<PatientDiagnosticsController> viewModel)
    {
        _viewModel = viewModel;
    }
    
    public async Task Handle(PatientDiagnosticsInsertResponse notification, CancellationToken cancellationToken)
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