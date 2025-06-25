using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientPrescription.Update.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientPrescription.Presenters
{
    public class UpdatePatientPrescriptionPresenter<T> : IPresenter<PatientPrescriptionUpdateResponse>
        where T : PatientPrescriptionUpdateResponse
    {
        private readonly GenericViewModel<PatientPrescriptionController> _viewModel;
        public UpdatePatientPrescriptionPresenter(GenericViewModel<PatientPrescriptionController> viewModel)
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
