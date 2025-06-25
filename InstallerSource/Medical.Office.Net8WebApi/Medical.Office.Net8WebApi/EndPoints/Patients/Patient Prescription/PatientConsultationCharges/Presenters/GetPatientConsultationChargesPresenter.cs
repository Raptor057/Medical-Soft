using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientConsultationCharges.Get.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientConsultationCharges.Get;

public sealed class GetPatientConsultationChargesPresenter<T> : IPresenter<PatientConsultationChargesGetResponse>
where T : PatientConsultationChargesGetResponse
{
    private readonly GenericViewModel<PatientConsultationChargesController> _viewModel;

    public GetPatientConsultationChargesPresenter(GenericViewModel<PatientConsultationChargesController> viewModel)
    {
        _viewModel = viewModel;
    }
    public async Task Handle(PatientConsultationChargesGetResponse notification, CancellationToken cancellationToken)
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