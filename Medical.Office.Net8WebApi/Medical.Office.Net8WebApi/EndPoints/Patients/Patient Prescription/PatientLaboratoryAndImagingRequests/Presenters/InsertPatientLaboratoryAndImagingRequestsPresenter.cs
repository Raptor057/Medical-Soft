using Common.Common.CleanArch;
using Common.Common;
using Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Insert.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientLaboratoryAndImagingRequests.Presenters
{
    public class InsertPatientLaboratoryAndImagingRequestsPresenter<T> : IPresenter<PatientLaboratoryAndImagingRequestsInsertResponse>
        where T : PatientLaboratoryAndImagingRequestsInsertResponse
    {
        private readonly GenericViewModel<PatientLaboratoryAndImagingRequestsController> _viewModel;

        public InsertPatientLaboratoryAndImagingRequestsPresenter(GenericViewModel<PatientLaboratoryAndImagingRequestsController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(PatientLaboratoryAndImagingRequestsInsertResponse notification, CancellationToken cancellationToken)
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
