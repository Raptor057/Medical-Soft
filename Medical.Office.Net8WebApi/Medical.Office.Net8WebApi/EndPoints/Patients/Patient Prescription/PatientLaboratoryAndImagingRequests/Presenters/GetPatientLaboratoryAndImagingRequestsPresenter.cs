using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Prescription.PatientLaboratoryAndImagingRequests.Get.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.Patient_Prescription.PatientLaboratoryAndImagingRequests.Presenters
{
    public class GetPatientLaboratoryAndImagingRequestsPresenter<T> : IPresenter<PatientLaboratoryAndImagingRequestsGetResponse>
        where T : PatientLaboratoryAndImagingRequestsGetResponse
    {
        private readonly GenericViewModel<PatientLaboratoryAndImagingRequestsController> _viewModel;

        public GetPatientLaboratoryAndImagingRequestsPresenter(GenericViewModel<PatientLaboratoryAndImagingRequestsController> viewModel)
        {
            _viewModel = viewModel;
        }
        public async Task Handle(PatientLaboratoryAndImagingRequestsGetResponse notification, CancellationToken cancellationToken)
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
