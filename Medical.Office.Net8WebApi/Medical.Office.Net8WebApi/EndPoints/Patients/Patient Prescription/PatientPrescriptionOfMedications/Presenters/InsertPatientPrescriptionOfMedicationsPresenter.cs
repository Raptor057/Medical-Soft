using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientPrescriptionOfMedications.Insert.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientPrescriptionOfMedications.Presenters
{
    public class InsertPatientPrescriptionOfMedicationsPresenter<T> : IPresenter<PatientPrescriptionOfMedicationsInsertResponse>
        where T : PatientPrescriptionOfMedicationsInsertResponse
    {
        private readonly GenericViewModel<PatientPrescriptionOfMedicationsController> _viewModel;
        public InsertPatientPrescriptionOfMedicationsPresenter(GenericViewModel<PatientPrescriptionOfMedicationsController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(PatientPrescriptionOfMedicationsInsertResponse notification, CancellationToken cancellationToken)
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
