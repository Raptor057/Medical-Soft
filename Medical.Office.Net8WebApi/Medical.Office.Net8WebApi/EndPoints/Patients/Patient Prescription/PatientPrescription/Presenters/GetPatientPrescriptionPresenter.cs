using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientPrescription.Get.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientPrescription.Presenters
{
    public class GetPatientPrescriptionPresenter<T> : IPresenter<PatientPrescriptionGetResponse>
        where T : PatientPrescriptionGetResponse
    {
        private readonly GenericViewModel<PatientPrescriptionController> _viewModel;
        public GetPatientPrescriptionPresenter(GenericViewModel<PatientPrescriptionController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(PatientPrescriptionGetResponse notification, CancellationToken cancellationToken)
        {
            if (notification is IFailure failure)
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
}
