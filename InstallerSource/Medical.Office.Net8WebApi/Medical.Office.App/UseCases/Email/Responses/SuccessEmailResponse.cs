using Common.Common;

namespace Medical.Office.App.UseCases.Email.Responses;

public record SuccessEmailResponse(string Message) : EmailResponse, ISuccess;