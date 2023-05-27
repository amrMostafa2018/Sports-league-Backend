namespace Task.Shared.API
{
    public enum HttpErrorCode
    {
        None,
        InvalidInput = 400,
        NotAuthenticated = 401,                     // Not Authorized
        NotAuthorized = 403,                        // Forbidden
        NotFound = 404,
        BusinessRuleViolation = 422,                // Unprocessable Entity
        Conflict = 409,
        IntegrationCommunicationError = 502,         // Bad Gateway
        ServerError = 500
    }
}
