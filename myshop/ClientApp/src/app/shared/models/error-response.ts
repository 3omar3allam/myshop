export interface ErrorResponse {
    message: string;
    validationErrors: { [key: string]: string[] }
}