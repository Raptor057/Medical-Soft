using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientPrescription.Update.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientPrescriptionOfMedications.Presenters
{
    public class UpdatePatientPrescriptionOfMedicationsPresenter<T> : IPresenter<PatientPrescriptionUpdateResponse>
        where T : PatientPrescriptionUpdateResponse
    {
        private readonly GenericViewModel<PatientPrescriptionOfMedicationsController> _viewModel;

        public UpdatePatientPrescriptionOfMedicationsPresenter(GenericViewModel<PatientPrescriptionOfMedicationsController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(PatientPrescriptionUpdateResponse notification, CancellationToken cancellationToken)
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
