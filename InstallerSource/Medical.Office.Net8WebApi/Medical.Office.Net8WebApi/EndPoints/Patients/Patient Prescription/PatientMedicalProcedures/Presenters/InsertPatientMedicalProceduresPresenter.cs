using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientMedicalProcedures.Insert.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientMedicalProcedures.Presenters
{
    public class InsertPatientMedicalProceduresPresenter<T> : IPresenter<PatientMedicalProceduresInsertResponse>
        where T : PatientMedicalProceduresInsertResponse
    {
        private readonly GenericViewModel<PatientMedicalProceduresController> _viewModel;
        public InsertPatientMedicalProceduresPresenter(GenericViewModel<PatientMedicalProceduresController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(PatientMedicalProceduresInsertResponse notification, CancellationToken cancellationToken)
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
