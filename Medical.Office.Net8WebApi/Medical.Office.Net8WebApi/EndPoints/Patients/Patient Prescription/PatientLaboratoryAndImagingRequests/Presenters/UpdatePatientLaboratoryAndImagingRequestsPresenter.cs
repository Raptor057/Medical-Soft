using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Update.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientLaboratoryAndImagingRequests.Presenters
{
    public class UpdatePatientLaboratoryAndImagingRequestsPresenter<T> : IPresenter<PatientLaboratoryAndImagingRequestsUpdateResponse>
        where T : PatientLaboratoryAndImagingRequestsUpdateResponse
    {
        private readonly GenericViewModel<PatientLaboratoryAndImagingRequestsController> _viewModel;

        public UpdatePatientLaboratoryAndImagingRequestsPresenter(GenericViewModel<PatientLaboratoryAndImagingRequestsController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(PatientLaboratoryAndImagingRequestsUpdateResponse notification, CancellationToken cancellationToken)
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
