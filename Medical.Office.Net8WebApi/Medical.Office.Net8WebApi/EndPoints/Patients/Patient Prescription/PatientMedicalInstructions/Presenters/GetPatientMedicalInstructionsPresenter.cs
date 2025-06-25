using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientMedicalInstructions.Get.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientMedicalInstructions.Presenters
{
    public class GetPatientMedicalInstructionsPresenter<T> : IPresenter<PatientMedicalInstructionsGetResponse>
        where T : PatientMedicalInstructionsGetResponse
    {
        private readonly GenericViewModel<PatientMedicalInstructionsController> _viewModel;
        public GetPatientMedicalInstructionsPresenter(GenericViewModel<PatientMedicalInstructionsController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(PatientMedicalInstructionsGetResponse notification, CancellationToken cancellationToken)
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
