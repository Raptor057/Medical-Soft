using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientPrescription.Insert.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientPrescription.Presenters
{
    public class InsertPatientPrescriptionPresenter<T> : IPresenter<PatientPrescriptionInsertResponse>
        where T : PatientPrescriptionInsertResponse
    {
        private readonly GenericViewModel<PatientPrescriptionController> _viewModel;
        public InsertPatientPrescriptionPresenter(GenericViewModel<PatientPrescriptionController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(PatientPrescriptionInsertResponse notification, CancellationToken cancellationToken)
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
