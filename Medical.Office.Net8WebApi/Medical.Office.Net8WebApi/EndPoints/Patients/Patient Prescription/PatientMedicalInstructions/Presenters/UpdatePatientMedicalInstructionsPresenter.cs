using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Update.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientMedicalInstructions.Presenters
{
    public class UpdatePatientMedicalInstructionsPresenter<T> : IPresenter<PatientMedicalInstructionsUpdateResponse>
        where T : PatientMedicalInstructionsUpdateResponse
    {
        private readonly GenericViewModel<PatientMedicalInstructionsController> _viewModel;
        public UpdatePatientMedicalInstructionsPresenter(GenericViewModel<PatientMedicalInstructionsController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(PatientMedicalInstructionsUpdateResponse notification, CancellationToken cancellationToken)
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
