using Common.Common;

namespace Medical.Office.App.UseCases.Email.Responses;

public record FailureEmailResponse(string Message) : EmailResponse, IFailure;