using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Get.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientMedicalProcedures.Presenters
{
    public class GetPatientMedicalProceduresPresenter<T> : IPresenter<PatientMedicalProceduresGetResponse>
        where T : PatientMedicalProceduresGetResponse
    {
        private readonly GenericViewModel<PatientMedicalProceduresController> _viewModel;
        public GetPatientMedicalProceduresPresenter(GenericViewModel<PatientMedicalProceduresController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(PatientMedicalProceduresGetResponse notification, CancellationToken cancellationToken)
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
