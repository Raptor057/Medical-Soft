using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Get.Responses;
using Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Insert.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientConsultationCharges.Get;

public sealed class InsertPatientConsultationChargesPresenter<T> : IPresenter<PatientConsultationChargesInsertResponse>
where T : PatientConsultationChargesInsertResponse
{
    private readonly GenericViewModel<PatientConsultationChargesController> _viewModel;

    public InsertPatientConsultationChargesPresenter(GenericViewModel<PatientConsultationChargesController> viewModel)
    {
        _viewModel = viewModel;
    }
    public async Task Handle(PatientConsultationChargesInsertResponse notification, CancellationToken cancellationToken)
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