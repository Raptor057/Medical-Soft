using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientTreatmentPlan.Insert.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientTreatmentPlan.Presenters
{
    public class InsertPatientTreatmentPlanPresenter<T> : IPresenter<PatientTreatmentPlanInsertResponse>
        where T : PatientTreatmentPlanInsertResponse
    {
        private readonly GenericViewModel<PatientTreatmentPlanController> _viewModel;
        public InsertPatientTreatmentPlanPresenter(GenericViewModel<PatientTreatmentPlanController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(PatientTreatmentPlanInsertResponse notification, CancellationToken cancellationToken)
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
