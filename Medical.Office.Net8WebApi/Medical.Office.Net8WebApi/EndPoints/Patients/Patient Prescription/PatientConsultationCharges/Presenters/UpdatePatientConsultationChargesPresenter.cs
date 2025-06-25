using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Get.Responses;
using Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Insert.Responses;
using Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Update.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientConsultationCharges.Get;

public sealed class UpdatePatientConsultationChargesPresenter<T> : IPresenter<PatientConsultationChargesUpdateResponse>
where T : PatientConsultationChargesUpdateResponse
{
    private readonly GenericViewModel<PatientConsultationChargesController> _viewModel;

    public UpdatePatientConsultationChargesPresenter(GenericViewModel<PatientConsultationChargesController> viewModel)
    {
        _viewModel = viewModel;
    }
    public async Task Handle(PatientConsultationChargesUpdateResponse notification, CancellationToken cancellationToken)
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