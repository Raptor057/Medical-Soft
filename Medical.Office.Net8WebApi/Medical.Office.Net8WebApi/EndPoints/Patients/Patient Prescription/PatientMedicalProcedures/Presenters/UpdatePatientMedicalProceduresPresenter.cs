using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Update.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientMedicalProcedures.Presenters
{
    public class UpdatePatientMedicalProceduresPresenter<T> : IPresenter<PatientMedicalProceduresUpdateResponse>
        where T : PatientMedicalProceduresUpdateResponse
    {
        private readonly GenericViewModel<PatientMedicalProceduresController> _viewModel;
        public UpdatePatientMedicalProceduresPresenter(GenericViewModel<PatientMedicalProceduresController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(PatientMedicalProceduresUpdateResponse notification, CancellationToken cancellationToken)
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
