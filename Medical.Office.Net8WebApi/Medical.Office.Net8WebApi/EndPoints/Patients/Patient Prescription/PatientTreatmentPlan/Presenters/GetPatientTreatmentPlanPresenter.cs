using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Get.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientTreatmentPlan.Presenters
{
    public class GetPatientTreatmentPlanPresenter<T> : IPresenter<PatientTreatmentPlanGetResponse>
        where T : PatientTreatmentPlanGetResponse
    {
        private readonly GenericViewModel<PatientTreatmentPlanController> _viewModel;
        public GetPatientTreatmentPlanPresenter(GenericViewModel<PatientTreatmentPlanController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(PatientTreatmentPlanGetResponse notification, CancellationToken cancellationToken)
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
