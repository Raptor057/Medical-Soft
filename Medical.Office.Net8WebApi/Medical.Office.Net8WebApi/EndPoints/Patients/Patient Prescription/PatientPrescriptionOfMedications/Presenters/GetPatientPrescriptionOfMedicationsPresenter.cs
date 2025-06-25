using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Get.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientPrescriptionOfMedications.Presenters
{
    public class GetPatientPrescriptionOfMedicationsPresenter<T> : IPresenter<PatientPrescriptionOfMedicationsGetResponse>
        where T : PatientPrescriptionOfMedicationsGetResponse
    {
        private readonly GenericViewModel<PatientPrescriptionOfMedicationsController> _viewModel;
        public GetPatientPrescriptionOfMedicationsPresenter(GenericViewModel<PatientPrescriptionOfMedicationsController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(PatientPrescriptionOfMedicationsGetResponse notification, CancellationToken cancellationToken)
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
