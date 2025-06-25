using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Update.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientTreatmentPlan.Presenters
{
    public class UpdatePatientTreatmentPlanPresenter<T> : IPresenter<PatientTreatmentPlanUpdateResponse>
        where T : PatientTreatmentPlanUpdateResponse
    {
        private readonly GenericViewModel<PatientTreatmentPlanController> _viewModel;
        public UpdatePatientTreatmentPlanPresenter(GenericViewModel<PatientTreatmentPlanController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(PatientTreatmentPlanUpdateResponse notification, CancellationToken cancellationToken)
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
